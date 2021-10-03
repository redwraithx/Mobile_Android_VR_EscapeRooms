using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class HingeScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public PlayerInventory playerRef;
    
    public bool playerHasHammer = false;
    public bool playerHasScrewDriver = false;

    public bool playerInRange = false;
    
    public GameObject doorRef;
    public Animator anim;
    private static readonly int OpenRoom2Door = Animator.StringToHash("OpenRoom2Door");
    
    
    public Material InactiveMaterial;

    public Material GazedAtMaterial;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    public void Start()
    {
        _startingPosition = transform.localPosition;
        //_myRenderer = GetComponent<Renderer>();
        //SetMaterial(false);
    }

    public void TeleportRandomly()
    {
        UseDoorRoom2();
    }

    // public void OnPointerEnter()
    // {
    //     SetMaterial(true);
    // }
    //
    // public void OnPointerExit()
    // {
    //     SetMaterial(false);
    // }
    //
    public void OnPointerClick()
    {
        TeleportRandomly();
    }
    //
    // private void SetMaterial(bool gazedAt)
    // {
    //     if (InactiveMaterial != null && GazedAtMaterial != null)
    //     {
    //         _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
    //     }
    // }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //
    //
    //
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     Debug.Log("pointer clicked on: " + eventData.lastPress.name);
    //     Debug.Log("pointer clicked object: " + eventData.pointerClick.gameObject);
    //
    //     // if (!eventData.lastPress.CompareTag("Player"))
    //     //     return;
    //     
    //     // if(playerRef.GetComponent<PlayerInventory>().hasGotHammer && playerRef.GetComponent<PlayerInventory>().hasGotScrewDriver)
    //     //     Destroy(gameObject);
    //     //if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Hinge"))
    //    // {
    //         //if (playerRef.GetComponent<PlayerInventory>().hasGotHammer && playerRef.GetComponent<PlayerInventory>().hasGotScrewDriver)
    //         //{
    //             // animate door
    //             doorRef.GetComponent<Animator>().SetTrigger(OpenRoom2Door);
    //
    //             // destroy hinge gameobject
    //             Destroy(gameObject);
    //        // }
    //     //}
    //
    // }
    //

    private void Update()
    {
        if (playerInRange)
        {
            playerHasHammer = playerRef.hasGotHammer;
            playerHasScrewDriver = playerRef.hasGotScrewDriver;
        }
    }


    public void UseDoorRoom2()
    {
        doorRef.GetComponent<Animator>().SetTrigger(OpenRoom2Door);
        //Destroy(gameObject);
        
        
    }
    
    //
    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     SetMaterial(activeGazedAtMaterial);
    // }
    //
    //
    //
    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     SetMaterial(inActiveGazedAtMaterial);
    // }
    //
    // private void SetMaterial(bool gazedAt)
    // {
    //     if (inActiveGazedAtMaterial != null && activeGazedAtMaterial != null)
    //     {
    //         _myRenderer.material = gazedAt ? activeGazedAtMaterial : inActiveGazedAtMaterial;
    //     }
    // }
    //
    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     
    // }
    //
    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     
    // }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!playerInRange)
            return;
        
        if(playerHasHammer && playerHasScrewDriver)
            UseDoorRoom2();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
