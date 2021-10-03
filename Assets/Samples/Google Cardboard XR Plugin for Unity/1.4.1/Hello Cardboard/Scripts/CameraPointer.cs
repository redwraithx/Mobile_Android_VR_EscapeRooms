//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    internal GameObject _gazedAtObject = null;

    public PlayerMovement movement = null;
    
    public GameObject moveHere = null;
    public Vector3 moveLocation = Vector3.zero;
    public bool canMoveToNewLocation = false;
    
    public Camera cam = null;
    private NavMeshAgent agent = null;

    private int currentSceneIndex;
    private int levelIndex;

    public bool isMoving = false;
    public Text testText = null;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelIndex = 1;
        
        if (currentSceneIndex == levelIndex)
        {
            if (!movement)
                movement = GetComponentInParent<PlayerMovement>();

            if (!moveHere)
                moveHere = GameObject.FindWithTag("MoveMarker").gameObject;

            cam = Camera.main;
        }
    }


    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        if (canMoveToNewLocation)
        {
            //testText.text = "moving now";

            // if (!isMoving)
            // {
            
            //if(Vector3.Distance(transform.position, moveLocation) > 0.9f)
                 agent.SetDestination(moveLocation);
            //
            //     isMoving = true;
            // }

            Vector3 trans = new Vector3(transform.position.x, 0f, transform.position.z);
            moveLocation.y = 0f;
            if (trans == moveLocation)
            {
                //testText.text = "stopped Moving reached point";
                
                canMoveToNewLocation = false;
                //moveLocation = Vector3.zero;

                isMoving = false;

            }
        }
        
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        Vector3 potentialLocation = Vector3.zero;
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            Touch touch = new Touch();
            
            if (hit.collider.CompareTag("Ground") && !canMoveToNewLocation)
            {
                if(Vector3.Distance(hit.point, transform.position) < 20f)
                {
                    if (currentSceneIndex == levelIndex)
                    {
                        //Vector3 newVec = new Vector3(hit.point.x, 0.6f, hit.point.z);
                        
                        
                        potentialLocation = hit.point;

                        canMoveToNewLocation = true;

                        isMoving = true;
                    }
                }
                
            }
            else if (hit.collider.CompareTag("BoxesButton"))  //hit.collider.CompareTag("PuzzleTwoBoxes"))
            {
                Debug.Log("test box used");
                if (_gazedAtObject != hit.transform.gameObject)
                {
                    _gazedAtObject?.SendMessage("OnPointerExit", true);
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("OnPointerEnter", false); //, hit.transform.gameObject);
                }
            }
            else if (hit.collider.CompareTag("Hammer") || hit.collider.CompareTag("ScrewDriver") || hit.collider.CompareTag("Crystal"))
            {
                Debug.Log("test box used");
                if (_gazedAtObject != hit.transform.gameObject)
                {
                    _gazedAtObject?.SendMessage("OnPointerExit", true);
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("OnPointerEnter", false); //, hit.transform.gameObject);
                }
            }
            else// if(!hit.collider.CompareTag("PuzzleTwoBoxes"))
            {
                // GameObject detected in front of the camera.
                if (_gazedAtObject != hit.transform.gameObject)
                {
                    // New GameObject.
                    _gazedAtObject?.SendMessage("OnPointerExit");
                    _gazedAtObject = hit.transform.gameObject;
                    
                    Debug.Log("hit object: " + hit.collider.name);
                    
                    _gazedAtObject.SendMessage("OnPointerEnter");
                }
            }
        }
        else
        {
            if (_gazedAtObject)
            {
                // No GameObject detected in front of the camera.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = null;
            }
        }
        
        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed && _gazedAtObject)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }


        //if (HasDoubleTapped() && !canMoveToNewLocation)
        if(!canMoveToNewLocation && isMoving)
        {
            isMoving = false;
            //testText.text = "has Double tapped";
            
            canMoveToNewLocation = true;
            moveLocation = potentialLocation;
        }

        //foreach(Touch touch in Input.touches)

    }
    
    
    public bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 0.2f;
 
        if( Input.touchCount == 1  && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch (0).deltaTime;
            float DeltaPositionLenght=Input.GetTouch (0).deltaPosition.magnitude;
 
            if ( DeltaTime> 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;                
        }
        return result;
    }
    
    // public void HandleTriggerManually()
    // {
    //     HandleTrigger();
    // }
    

    public bool HasDoubleTapped()//Vector3 potentialLocation)
    {
        bool hasDoubleTapped = false;
        
        for(int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount >= 2)
                {
                    return true;
                }
            }
        }

        return hasDoubleTapped;
    }
}
