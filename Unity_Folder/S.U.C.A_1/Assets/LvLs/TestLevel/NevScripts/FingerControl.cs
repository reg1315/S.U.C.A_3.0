using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerControl : AllScale, IControlToDo
{
    private Vector3 startRotatorPos;

    private Vector2 startTochPos;

    //private float sensivity = 1f;

    public bool CenIMove()
    {
        if (Input.touchCount > 0) return true;
        else return false;
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Left(GameObject rotator)
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
                //case TouchPhase.Ended:
                //    if (touch.position.x - startTochPos.x > 0);
                //    break;
        }
    }

    public void Right(GameObject rotator)
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
            //case TouchPhase.Ended:
            //    if (touch.position.x - startTochPos.x < 0) return true;
            //    break;
        }
    }

    public void ZoomIn()
    {
        throw new System.NotImplementedException();
    }

    public void ZoomOut()
    {
        throw new System.NotImplementedException();
    }
}
