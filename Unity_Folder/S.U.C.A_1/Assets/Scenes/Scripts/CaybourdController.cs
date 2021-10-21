using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaybourdController : MonoBehaviour, IController
{
    public bool Back()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            return true;
        return false;
    }

    public bool Left()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            return true;
        return false;
    }

    public Vector2 Move()
    {
        Vector2 vect = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
            vect.x += 1;
        if (Input.GetKey(KeyCode.A))
            vect.x -= 1;
        if (Input.GetKey(KeyCode.W))
            vect.y += 1;
        if (Input.GetKey(KeyCode.S))
            vect.y -= 1;

        return vect;
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
