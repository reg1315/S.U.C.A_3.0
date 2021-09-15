using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : AllScale
{
    public GameObject rotator;

    private void Start()
    {
        rotator = GameObject.Find("CenterOfCameraRotate");
    }
    public void CameraController(IControlToDo iController)
    {
        Rotate(iController);
    }

    private Quaternion endRotatorPos;   // Зміна для корнтролю повороту камери

    private WallControll wallController = GameObject.Find("flor").GetComponent<WallControll>(); // змінна для контролю стін
    public void Rotate(IControlToDo iController)
    {
        if (iController.CenIMove())
        {
            if (iController.LeftSwipe(rotator))
            {
                if ((rotator.transform.eulerAngles.y >= 345 & rotator.transform.eulerAngles.y <= 360) || (rotator.transform.eulerAngles.y >= 0 & rotator.transform.eulerAngles.y < 75))
                {
                    endRotatorPos = Quaternion.Euler(0, 90, 0);
                }
                else if (rotator.transform.eulerAngles.y < 165 & rotator.transform.eulerAngles.y >= 75)
                {
                    endRotatorPos = Quaternion.Euler(0, 180, 0);
                }
                else if (rotator.transform.eulerAngles.y < 255 & rotator.transform.eulerAngles.y >= 165)
                {
                    endRotatorPos = Quaternion.Euler(0, 270, 0);
                }
                else
                {
                    endRotatorPos = Quaternion.Euler(0, 360, 0);
                }
            }
            if (iController.RightSwipe(rotator))
            {
                if (rotator.transform.eulerAngles.y <= 105 & rotator.transform.eulerAngles.y > 15)
                {
                    endRotatorPos = Quaternion.Euler(0, 0, 0);
                }
                else if (rotator.transform.eulerAngles.y <= 195 & rotator.transform.eulerAngles.y > 95)
                {
                    endRotatorPos = Quaternion.Euler(0, 90, 0);
                }
                else if (rotator.transform.eulerAngles.y <= 285 & rotator.transform.eulerAngles.y > 195)
                {
                    endRotatorPos = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    endRotatorPos = Quaternion.Euler(0, 270, 0);
                }
            }
        }
        else if (rotator.transform.rotation != endRotatorPos)
        {
            rotator.transform.rotation = Quaternion.Slerp(rotator.transform.rotation, endRotatorPos, Time.deltaTime * CameraRotateScale);
            wallController.WallsNormalizade(CameraRotateScale);
        }
    }
}
