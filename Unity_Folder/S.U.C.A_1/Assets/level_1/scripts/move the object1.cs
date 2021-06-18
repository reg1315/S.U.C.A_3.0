using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetheobject1 : MonoBehaviour
{
    public float x, y, z;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }
}
