using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotateX;
    public float rotateY;
    public float rotateZ;

    private void Update()
    {
        transform.Rotate(rotateX*Time.deltaTime, rotateY*Time.deltaTime, rotateZ*Time.deltaTime);
    }
}
