using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTouch : MonoBehaviour
{
    public Camera cam = null;
    
    private void Update()
    {
        Touch touch = new Touch();
        
        // check for valid touch
        if (touch.phase == TouchPhase.Began)
        {
            // if touch = true, get screen to world space point
            var newPos = cam.ScreenToWorldPoint(touch.position);
            
            
            // set position to point in worl space
            transform.position = newPos;
        }
    }
}
