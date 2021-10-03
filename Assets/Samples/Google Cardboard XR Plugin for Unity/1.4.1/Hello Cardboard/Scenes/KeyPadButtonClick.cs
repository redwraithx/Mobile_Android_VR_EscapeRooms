using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadButtonClick : MonoBehaviour
{

    //public KeyPadManager keyPadManager;
    public Button button;
    
    public Material GazedAtMaterial;
    public Material InactiveMaterial;
    public Image _myRenderer;
    

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
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

}
