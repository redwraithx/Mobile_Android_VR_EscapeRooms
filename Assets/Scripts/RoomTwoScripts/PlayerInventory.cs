using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool hasGotHammer = false;
    public bool hasGotScrewDriver = false;
    public int hasCrystalKeyParts = 1;
    
    
    public Material activeGazedAtMaterial;
    public Material inActiveGazedAtMaterial;
    public MeshRenderer _myRenderer;


    public bool gazedAt = false;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        gazedAt = false;
        
        SetMaterial(activeGazedAtMaterial);
        
        Debug.Log("gazedAt true in on pointer enter");

    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        gazedAt = false;
        
        SetMaterial(inActiveGazedAtMaterial);
        
        Debug.Log("gazedAt false in on pointer exit");
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gazedAt)// && (eventData.lastPress.gameObject.CompareTag($"ScrewDriver") || eventData.lastPress.gameObject.CompareTag($"Hammer")))
        {
            if (eventData.lastPress.gameObject.CompareTag("ScrewDriver"))
                hasGotScrewDriver = true;

            if (eventData.lastPress.gameObject.CompareTag("Hammer"))
                hasGotHammer = true;
        }
            
    }
    
    private void SetMaterial(bool gazedAt)
    {
        if (inActiveGazedAtMaterial != null && activeGazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? activeGazedAtMaterial : inActiveGazedAtMaterial;
        }
    }
}
