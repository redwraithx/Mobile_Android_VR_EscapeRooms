
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyPadManager : MonoBehaviour
{
    public GameObject[] buttons;
    
    public string keyEntered = "";

    private const string KeyCode = "1975";

    public Text codeText = null;

    public bool hasEnteredCode = false; // this will check for key state being true
    public bool hasFoundKey = false; // opens door if true
    public bool hasOpenedDoor = false;
    public bool hasEnteredResetCode = false;
    public bool isResettingKeyCode = false;

    //public Button button;

    public Animation doorAnimation = null;
    
    public Material GazedAtMaterial;
    public Material InactiveMaterial;
    private Renderer _myRenderer;
    
    private void Start()
    {
        keyEntered = "";
        
        codeText.text = keyEntered;

        hasEnteredCode = false;
        hasFoundKey = false;
        hasOpenedDoor = false;
        hasEnteredResetCode = false;
        isResettingKeyCode = false;

        _myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (hasFoundKey && hasOpenedDoor)
            return;

        if (hasFoundKey && !hasOpenedDoor)
        {
            
            Debug.Log("try to open door");
            
            
            
            // open door THIS IS MISSING
            OpenDoor();
        }


        if (hasEnteredCode)
            TestEnteredKey();

        if (hasEnteredResetCode && !isResettingKeyCode)
            ResetEnteredKeyCode();
    }

    public void ResetEnteredKeyCode()
    {
        if (isResettingKeyCode || keyEntered.Length == 0)
            return;
        
        isResettingKeyCode = true;

        //GetComponent<AudioSource>().Play();
        
        keyEntered = "";
        
        codeText.text = keyEntered;

        hasEnteredResetCode = false;

        isResettingKeyCode = false;
    }


    public void TestEnteredKey()
    {
        //GetComponent<AudioSource>().Play();
        
        if (keyEntered.Length == 0)
        {
            keyEntered = "";
            hasEnteredCode = false;

            return;
        }

        if (keyEntered == KeyCode)
        {
            // open door lock out keypad
            keyEntered = "";
            hasEnteredCode = false;

            hasFoundKey = true;

            
        }
        else
        {
            ResetEnteredKeyCode();

            hasEnteredCode = false;
        }
        
    }
    
    // use this to update which key was submitted from the buttons
    public void EnterKey(int key)
    {
        if (key < 0 || key > 9)
            return;

        // GetComponent<AudioSource>().Play();
        
        keyEntered += key.ToString();

        codeText.text = keyEntered;
    }
    
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
    
    

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }
    public void OnPointerExit()
    {
        SetMaterial(false);
    }
    
    
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {
       // pointerEventData.hovered[0].gameObject.GetComponent<Button>().onClick.Invoke();
        
        
        // if (Input.inputString != "")
        // {
        //     int buttonIndex;
        //     int.TryParse(Input.inputString, out buttonIndex);
        //     //buttonIndex -= 1;
        //     if (buttonIndex >= 0 && buttonIndex < buttons.Length)
        //     {
        //         //ExecuteEvents.Execute<IPointerClickHandler>(buttons[buttonIndex], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        //         
        //         
        //     }
        // }
        
    }

    private void OpenDoor()
    {
        if (hasOpenedDoor || !hasFoundKey)
            return;
        
        // lock keypad
        hasOpenedDoor = true;
        
        Debug.Log("Opening door with animation");
        
        // Open the door
        doorAnimation["OpenDoor_Anim"].wrapMode = WrapMode.Once;
        doorAnimation.Play("OpenDoor_Anim");
    }
}
