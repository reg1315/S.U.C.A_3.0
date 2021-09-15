using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaybourdControl : MonoBehaviour, IControlToDo
{
    public bool CenIMove()
    {
        return true;
    }

    public bool LeftSwipe(GameObject rotator)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) return true;
        return false;
    }

    public void Move(GameObject rotator)
    {
        throw new System.NotImplementedException();
    }

    public bool RightSwipe(GameObject rotator)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) return true;
        return false;
    }

    public void Zoom()
    {
        throw new System.NotImplementedException();
    }
}
