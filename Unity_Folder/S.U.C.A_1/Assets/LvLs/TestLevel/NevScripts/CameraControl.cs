using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : AllScale
{
    private GameObject rotator;

    private void Start()
    {
        rotator = GameObject.Find("CenterOfCameraRotate");
    }
    public void CameraController(IControlToDo iController)
    {
        Rotate(iController);

    }

    public void Rotate(IControlToDo iController)
    {
        if (iController.CenIMove())
        {
            iController.Left(rotator);
            iController.Right(rotator);
        }
        else if(rotator.transform.rotation.y != 225 || rotator.transform.rotation.y != 315 || rotator.transform.rotation.y != 45 || rotator.transform.rotation.y != 135)
        {
            GoToKayPosition();
        }
    }

    public void Move()
    {

    }

    private void GoToKayPosition()
    {
        if
        rotator.transform.rotation = Quaternion.Slerp(rotator.transform.rotation, endPosition, Time.deltaTime * CameraRotateScale);
    }
}
