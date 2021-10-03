using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    public PlayerInventory inv;

    public BoxCollider box = null;
    
    public Text testText = null;

    
    public Material GazedAtMaterial;
    public Material InactiveMaterial;
    private Renderer _myRenderer;

    public Button button = null;
    
    private void Start()
    {
        if (!box)
            throw new Exception($"Error, box collider reference on object [{gameObject.name}] is missing");
        
        if(!_myRenderer)
            _myRenderer = GetComponent<Renderer>();

        if (!button)
            button = GetComponent<Button>();
        
        button.onClick.AddListener(AddItem);
    }
    
    public void OnPointerEnter()
    {
        SetMaterial(true);
    }
    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    public void OnPointerClick()
    {
        button.onClick.Invoke();
    }
    
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            if(gameObject.CompareTag("ScrewDriver"))
                _myRenderer.materials[2] = gazedAt ? GazedAtMaterial : InactiveMaterial;
            else
                _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    public void AddItem()
    {
        Debug.Log("Add item");
        testText.text = "Adding Item" + gameObject.name;


        if (gameObject.CompareTag("Hammer"))
        {
            inv.hasGotHammer = true;
            
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("ScrewDriver"))
        {
            inv.hasGotScrewDriver = true;
            
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Crystal"))
        {
            inv.hasCrystalKeyParts++;
            
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("PuzzleTwoBoxes"))
        {
            gameObject.GetComponent<PuzzleTwoBoxIndex>().UseBox();
            
        }

        if (gameObject.CompareTag("Hinge"))
        {
            Animator anim = gameObject.transform.parent.GetComponent<Animator>();
            
            Destroy(gameObject);
            
            anim.SetTrigger("DoorFall");
        }
        
        
    }


    private void OnTriggerEnter(Collider other)
    {
        testText.text = "On trigger";
    }
}
