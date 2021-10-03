using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    public BoxCollider box = null;
    public PlayerMovement player = null;
    

    private void Start()
    {
        box = GetComponent<BoxCollider>();

        player = GetComponentInParent<PlayerMovement>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("KeyPad"))
            return;
        
        //Debug.Log("On Enter");

        player.UpdatePlayerMovementStatus(true);
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("KeyPad"))
            return;
        
        //Debug.Log("On Exit");

        player.UpdatePlayerMovementStatus(false);
    }
}
