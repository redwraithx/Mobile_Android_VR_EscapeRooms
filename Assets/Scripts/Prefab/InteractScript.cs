using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public PickupObject targetObject = null;

    //private RaycastHit hit;

    private BoxCollider box;

    private void Start()
    {
        box = GetComponent<BoxCollider>();
        
        
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && targetObject)
        {
            targetObject.AddItem();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PuzzleTwoBoxes"))
        {
            targetObject = other.gameObject.GetComponent<PickupObject>();
        }
        else if (other.gameObject.CompareTag("Hammer"))
        {
            targetObject = other.gameObject.GetComponent<PickupObject>();
        }
        else if (other.gameObject.CompareTag("ScrewDriver"))
        {
            targetObject = other.gameObject.GetComponent<PickupObject>();
        }
        else if (other.gameObject.CompareTag("Hinge"))
        {
            targetObject = other.gameObject.GetComponent<PickupObject>();
        }
        else if (other.gameObject.CompareTag("Crystal"))
        {
            targetObject = other.gameObject.GetComponent<PickupObject>();
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (targetObject)
            targetObject = null;
    }
}
