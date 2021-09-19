using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerCintroller : MonoBehaviour, IController
{
    public bool Back()
    {
        throw new System.NotImplementedException();
    }


    public float maxSensivityDistance = 0;
    private Vector2 startTochPos = new Vector2();
    public bool Left()
    {
        var touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                startTochPos = touch.position;
                break;
            case TouchPhase.Ended:
                if (touch.position.x - startTochPos.x > maxSensivityDistance) return true;
                break;
        }
        return false;
    }

    public Vector2 Move(Vector2 target)
    {
        throw new System.NotImplementedException();
    }

    public bool Right()
    {
        var touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                startTochPos = touch.position;
                break;
            case TouchPhase.Ended:
                if (touch.position.x - startTochPos.x < -maxSensivityDistance) return true;
                break;
        }
        return false;
    }

    public bool tap()
    {
        throw new System.NotImplementedException();
    }
}
