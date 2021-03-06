﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 GetDirectionFromAngleInDegrees(float angleInDegrees, Vector3 transformForward, Vector3 rotationPlaneAxis)
    {
        float a = angleInDegrees * Mathf.Deg2Rad;
        return (transformForward * Mathf.Cos(a) + rotationPlaneAxis * Mathf.Sin(a)).normalized;
    }
}
