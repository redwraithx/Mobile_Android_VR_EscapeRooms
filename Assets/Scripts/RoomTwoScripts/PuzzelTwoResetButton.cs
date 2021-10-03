using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzelTwoResetButton : MonoBehaviour
{
    public GameObject[] boxes = null;
    public GameObject[] rewards = null;

    public bool hasOpenedABox = false;

    public bool isButtonBroken = false;

    //public Animation animation = null;
    public Animator anim = null;
    private static readonly int PushButton = Animator.StringToHash("PushButton");
    
    
    public Material GazedAtMaterial;
    public Material InactiveMaterial;
    private Renderer _myRenderer;

    public Button button = null;

    private void Start()
    {
        if(boxes.Length <= 0)
            throw new Exception("Error, boxes array is empty!");
        
        if(rewards.Length <= 0)
            throw new Exception("Error, rewards array is empty!");

        // if (!animation)
        //     throw new Exception("Error, animation reference is missing!");

        if (!anim)
            anim = GetComponent<Animator>();
        
        if(!_myRenderer)
            _myRenderer = GetComponent<Renderer>();


        if (!button)
            button = GetComponent<Button>();

        if (gameObject.CompareTag("PuzzleTwoBoxes"))
            button.onClick.AddListener(UseSelectedBox);//gameObject));
        else
            button.onClick.AddListener(UseButton);

        //ResetPuzzle();
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
        var gaze = GetComponentInChildren<CameraPointer>();

        if (gaze._gazedAtObject)
        {
            if (gaze._gazedAtObject.CompareTag("BoxesButton"))
                gaze._gazedAtObject.GetComponent<Button>().onClick.Invoke();
            else if(gaze._gazedAtObject.CompareTag("PuzzleTwoBoxes"))
                gaze._gazedAtObject.GetComponent<Button>().onClick.Invoke();
            
        }
    }

    
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
    

    public void UseButton()
    {

        if (isButtonBroken)
            return;
        
        // if (animation.isPlaying || canRunThe)
        //     return;
        //
        // animation["PuzzleTwoBoxButtonAnimation"].wrapMode = WrapMode.Once;
        // animation.Play("PuzzleTwoBoxButtonAnimation");
        
        
        
        anim.SetTrigger(PushButton);
    }

    public void UseSelectedBox()//GameObject thisBox)
    {
        if (hasOpenedABox)
            return;

        int index = gameObject.GetComponent<PuzzleTwoBoxIndex>().index;

        
        
        gameObject.SetActive(false);
        
        rewards[index].SetActive(true);

        hasOpenedABox = true;
        
        if (index == 3)
            isButtonBroken = true;
    }


    public void CheckForCrystalReward()
    {
        int counter = 0;
        foreach (GameObject reward in rewards)
        {
            if (reward.CompareTag($"Crystal"))
            {
                if (reward.activeInHierarchy)
                {
                    isButtonBroken = true;
                }
            }
            else
            {
                counter++;
            }
        }

        if (isButtonBroken)
        {
            int newCounter = 0;
            foreach (GameObject reward in rewards)
            {
                if (newCounter == counter)
                    continue;

                reward.SetActive(false);
                
                newCounter++;
            }

            foreach (GameObject box in boxes)
            {
                box.SetActive(false);
            }
        }
    }
    

    public void ResetPuzzle()
    {
        if (boxes.Length <= 0 || rewards.Length <= 0)
            throw new Exception("Error, boxes and/or rewards array(s) is/are empty!");
        
        foreach (GameObject box in boxes)
        {
            box.SetActive(true);
        }

        foreach (GameObject reward in rewards)
        {
            reward.SetActive(false);
        }

        anim.ResetTrigger(PushButton);
        
        hasOpenedABox = false;
    }
}
