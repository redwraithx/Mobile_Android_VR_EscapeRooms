using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxUILookAtPlayer : MonoBehaviour
{
    private Transform RotationPoint;
    public Transform playerRef;

    private void Start()
    {
        if (!playerRef)
            playerRef = GameObject.FindWithTag("Player").transform;

    }


    private void Update()
    {
        if (Vector3.Distance(playerRef.position, transform.position) < 8f)
        {
            var lookingDirection = transform.position - playerRef.position;
            lookingDirection.y = 0f;

            var rotation = Quaternion.LookRotation(lookingDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 4);
        }
        
    }
}
