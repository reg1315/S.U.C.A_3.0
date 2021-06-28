using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ObjectRotate()
    {
        float sensitivity = 3; // чувствительность мышки
        float X, Y = transform.localEulerAngles.x;

        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        Y += Input.GetAxis("Mouse Y") * sensitivity;
        Y = Mathf.Clamp(Y, -90, 90);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
    }
}
