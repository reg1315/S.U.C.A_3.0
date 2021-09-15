using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerControl : AllScale, IControlToDo // клас який дозволяє керувати через телефон
{
    private Vector3 startRotatorPos;    // початкова точка повороту ценру обертання камери

    private Vector2 startTochPos;   // початкова точка дотику до екрану

    public bool CenIMove()  // реалізація IControlToDo (опис дивитися в інтерфейсі IControlToDo)
    {
        if (Input.touchCount > 0) return true;
        else return false;
    }

    public void Move(GameObject rotator)    // реалізація IControlToDo (опис дивитися в інтерфейсі IControlToDo)
    {
       
    }

    public bool LeftSwipe(GameObject rotator)   // реалізація IControlToDo (опис дивитися в інтерфейсі IControlToDo)
    {
        var touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                startTochPos = touch.position;
                startRotatorPos = rotator.transform.localEulerAngles;
                break;
            case TouchPhase.Moved:
                float X = startRotatorPos.y + (touch.position.x - startTochPos.x) * CameraRotateScale;
                rotator.transform.localEulerAngles = new Vector3(rotator.transform.localEulerAngles.x, X, rotator.transform.localEulerAngles.z);
                break;
            case TouchPhase.Ended:
                if (touch.position.x - startTochPos.x > 0) return true;
                break;
        }
        return false;
    }

    public bool RightSwipe(GameObject rotator)  // реалізація IControlToDo (опис дивитися в інтерфейсі IControlToDo)
    {
        var touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                startTochPos = touch.position;
                startRotatorPos = rotator.transform.localEulerAngles;
                break;
            case TouchPhase.Moved:
                float X = startRotatorPos.y + (touch.position.x - startTochPos.x) * CameraRotateScale;
                rotator.transform.localEulerAngles = new Vector3(rotator.transform.localEulerAngles.x, X, rotator.transform.localEulerAngles.z);
                break;
            case TouchPhase.Ended:
                if (touch.position.x - startTochPos.x < 0) return true;
                break;
        }
        return false;
    }

    public void Zoom()  // реалізація IControlToDo (опис дивитися в інтерфейсі IControlToDo)
    {
        throw new System.NotImplementedException();
    }
}
