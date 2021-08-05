using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void CameraMove(Camera MainCamera, Vector3 pos, float speed)
    {
        MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, pos, Time.deltaTime * speed);
    }

    public void ObjectMove()
    {

    }
}
