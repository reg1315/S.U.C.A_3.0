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

    public Vector2 Move(float speed)
    {
        Vector2 vector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
            vector.x += speed;
        if (Input.GetKey(KeyCode.A))
            vector.x -= speed;
        if (Input.GetKey(KeyCode.W))
            vector.y += speed;
        if (Input.GetKey(KeyCode.S))
            vector.y -= speed;

        return vector;
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
