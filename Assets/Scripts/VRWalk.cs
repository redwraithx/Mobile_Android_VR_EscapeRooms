

using UnityEngine;
using UnityEngine.UI;

public class VRWalk : MonoBehaviour
{
    public Transform camTransform = null;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward = false;

    private CharacterController cc = null;

    public Text text = null;
    
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        
        
    }

    private void Update()
    {
        if (true)
            return;
        
        if(camTransform.eulerAngles.x >= toggleAngle && camTransform.eulerAngles.x < 90.0f)
        {
            moveForward = true;

            text.text = "moving";
        }
        else
        {
            moveForward = false;

            text.text = "not moving";
        }

        if (moveForward)
        {
            Vector3 forward = camTransform.TransformDirection(Vector3.forward);

            cc.SimpleMove(forward * speed);
        }
        
    }
}
