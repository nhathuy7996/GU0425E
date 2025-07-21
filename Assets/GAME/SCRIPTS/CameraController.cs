using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] Vector3 offset = new Vector2(0, 1);
    
    Vector3 smoothVelocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.SmoothDamp(this.transform.position,
         playerTransform.position + offset, ref smoothVelocity, smoothTime);
    }
}
