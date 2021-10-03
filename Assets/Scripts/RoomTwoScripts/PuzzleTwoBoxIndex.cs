
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleTwoBoxIndex : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public PuzzelTwoResetButton buttonRef;

    public Text testText;
    
    public int index = -1;

    public bool gazedAt = false;
    public bool hasUsedBox = false;
    
    
    
    public bool playerInRange = false;

    
    
    
    
    
    
    public Material InactiveMaterial;

    public Material GazedAtMaterial;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    public void Start()
    {
        _startingPosition = transform.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    public void TeleportRandomly()
    {
        UseBox();
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
        TeleportRandomly();
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public void UseBox()
    {
        buttonRef.UseSelectedBox();
        
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
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
