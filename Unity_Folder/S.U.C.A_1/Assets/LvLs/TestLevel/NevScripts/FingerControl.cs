using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerControl : AllScale, IControlToDo // ���� ���� �������� �������� ����� �������
{
    private Vector3 startRotatorPos;    // ��������� ����� �������� ����� ��������� ������

    private Vector2 startTochPos;   // ��������� ����� ������ �� ������

    public bool CenIMove()  // ��������� IControlToDo (���� �������� � ��������� IControlToDo)
    {
        if (Input.touchCount > 0) return true;
        else return false;
    }

    public void Move(GameObject rotator)    // ��������� IControlToDo (���� �������� � ��������� IControlToDo)
    {
       
    }

    public bool LeftSwipe(GameObject rotator)   // ��������� IControlToDo (���� �������� � ��������� IControlToDo)
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

    public bool RightSwipe(GameObject rotator)  // ��������� IControlToDo (���� �������� � ��������� IControlToDo)
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

    public void Zoom()  // ��������� IControlToDo (���� �������� � ��������� IControlToDo)
    {
        throw new System.NotImplementedException();
    }
}
