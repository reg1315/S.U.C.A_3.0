using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundlvl : MonoBehaviour
{
    public float angule;
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, angule * Time.deltaTime);
    }
}
