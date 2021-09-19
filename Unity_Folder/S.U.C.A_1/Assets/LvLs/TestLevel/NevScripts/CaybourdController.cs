using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaybourdController : MonoBehaviour, IController
{
    public bool Back()
    {
        throw new System.NotImplementedException();
    }

    public bool Left()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            return true;
        return false;
    }

    public Vector2 Move(Vector2 target)
    {
        throw new System.NotImplementedException();
    }

    public bool Right()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            return true;
        return false;
    }

    public bool tap()
    {
        throw new System.NotImplementedException();
    }
}
