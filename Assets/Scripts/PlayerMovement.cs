

using System;
using System.Transactions;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    private NavMeshAgent agent = null;

    private Vector3 startPos;
    public Vector3 targetPos;
    private float moveSpeed = 5f;

    private Camera cam = null;

    public GameObject moveHere = null;

    public bool isUsingKeyPad = false;

    public bool isUpdatingPlayerMovementStatue = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
        agent = GetComponent<NavMeshAgent>();

    }


    private void Update()
    {
        if (isUsingKeyPad)
            return;
        
        //if (Input.GetMouseButtonDown(0))
        if(HasDoubleTapped() && !isUsingKeyPad)
        {
            // Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //
            // RaycastHit hit;
            //
            // if (Physics.Raycast(ray, out hit))
            // {
            //     moveHere.transform.position = hit.point;
            //     
            //     agent.SetDestination(moveHere.transform.position);
            // }
            
            MovePosition();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (true)
            return;
        
        if (targetPos == Vector3.zero)
            return;
        
        startPos = transform.position;
        movement = targetPos - startPos;
        
        // double click position
        agent.Move(movement * (Time.deltaTime * agent.speed));
        //agent.SetDestination(targetPos);
        
        // update world position to move too
        
        
        targetPos = Vector3.zero;
        movement = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            
        }
    }

    public void MovePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            moveHere.transform.position = hit.point;

            var direction = (hit.point - transform.position);
            
            //transform.LookAt(direction);
            
            
            agent.SetDestination(moveHere.transform.position);
        }
            
            
    }

    public void UpdatePlayerMovementStatus(bool value)
    {
        if (isUpdatingPlayerMovementStatue || isUsingKeyPad == value)
            return;

        isUpdatingPlayerMovementStatue = true;

        isUsingKeyPad = value;

        isUpdatingPlayerMovementStatue = false;
    }
    
    public bool HasDoubleTapped()//Vector3 potentialLocation)
    {
        bool hasDoubleTapped = false;
        
        for(int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount >= 2)
                {
                    return true;
                }
            }
        }

        return hasDoubleTapped;
    }
    
    
}
