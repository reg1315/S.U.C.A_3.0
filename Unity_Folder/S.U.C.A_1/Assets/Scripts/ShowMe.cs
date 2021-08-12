using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMe : MonoBehaviour
{
    public Transform defoultTarget;
    private float defultSpeed = 100;
    public Vector3 target;
    public float speed;

    public bool Blook = false;

    private void Start()
    {
        Default();
    }
    void Update() 
    { 
        if (Blook) { Look(); } 
    }

    private void Look()
    {
        Vector3 direction = target - transform.position;
        Quaternion rotation1 = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation1, Time.deltaTime * speed);
    }

    public void Default()
    {
        target = defoultTarget.position;
        speed = defultSpeed;
    }
}
