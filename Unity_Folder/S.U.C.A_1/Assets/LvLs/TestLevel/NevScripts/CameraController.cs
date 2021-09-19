using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform camera;  //  Змінна самої камери яка є в середені батьківського елемента CenterOfCameraRotate

    private void Start()
    {
        endRotatorPos = transform.rotation;
        camera = transform.GetChild(1);
    }

    public void Controller(IController icontroller)
    {
        RotateAroundLvL(icontroller);
    }

    /*Змінні які використовуються для повороту камери навколо рівня*/
    private Quaternion endRotatorPos;
    [Space]
    [SerializeField] private WallsController wallsController;
    [SerializeField] private float rotationSpeed = 1f;  //  Відповідає за швидкість повороту камери навколо рівня

    private void RotateAroundLvL(IController icontroller)   //  система повороту камери навколо рівня
    {
        if (icontroller.Left()) //  Задання кінечної точки при повороті вліво
        {
            if ((transform.eulerAngles.y >= 345 & transform.eulerAngles.y <= 360) || (transform.eulerAngles.y >= 0 & transform.eulerAngles.y < 75))
            {
                endRotatorPos = Quaternion.Euler(0, 90, 0);
                wallsController.endPositionV3[0] = wallsController.downPosition[0];
                wallsController.endPositionV3[1] = wallsController.downPosition[1];
                wallsController.endPositionV3[2] = wallsController.normalPosition[2];
                wallsController.endPositionV3[3] = wallsController.normalPosition[3];
            }
            else if (transform.eulerAngles.y < 165 & transform.eulerAngles.y >= 75)
            {
                endRotatorPos = Quaternion.Euler(0, 180, 0);
                wallsController.endPositionV3[0] = wallsController.normalPosition[0];
                wallsController.endPositionV3[1] = wallsController.downPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.normalPosition[3];
            }
            else if (transform.eulerAngles.y < 255 & transform.eulerAngles.y >= 165)
            {
                endRotatorPos = Quaternion.Euler(0, 270, 0);
                wallsController.endPositionV3[0] = wallsController.normalPosition[0];
                wallsController.endPositionV3[1] = wallsController.normalPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
            else
            {
                endRotatorPos = Quaternion.Euler(0, 360, 0);
                wallsController.endPositionV3[0] = wallsController.downPosition[0];
                wallsController.endPositionV3[1] = wallsController.normalPosition[1];
                wallsController.endPositionV3[2] = wallsController.normalPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
        }

        if (icontroller.Right())    //  Задання кінечної точки при повороті вправо
        {
            if (transform.eulerAngles.y <= 105 & transform.eulerAngles.y > 15)
            {
                endRotatorPos = Quaternion.Euler(0, 0, 0);
                wallsController.endPositionV3[0] = wallsController.downPosition[0];
                wallsController.endPositionV3[1] = wallsController.normalPosition[1];
                wallsController.endPositionV3[2] = wallsController.normalPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
            else if (transform.eulerAngles.y <= 195 & transform.eulerAngles.y > 95)
            {
                endRotatorPos = Quaternion.Euler(0, 90, 0);
                wallsController.endPositionV3[0] = wallsController.downPosition[0];
                wallsController.endPositionV3[1] = wallsController.downPosition[1];
                wallsController.endPositionV3[2] = wallsController.normalPosition[2];
                wallsController.endPositionV3[3] = wallsController.normalPosition[3];
            }
            else if (transform.eulerAngles.y <= 285 & transform.eulerAngles.y > 195)
            {
                endRotatorPos = Quaternion.Euler(0, 180, 0);
                wallsController.endPositionV3[0] = wallsController.normalPosition[0];
                wallsController.endPositionV3[1] = wallsController.downPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.normalPosition[3];
            }
            else
            {
                endRotatorPos = Quaternion.Euler(0, 270, 0);
                wallsController.endPositionV3[0] = wallsController.normalPosition[0];
                wallsController.endPositionV3[1] = wallsController.normalPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
        }

        if (transform.rotation != endRotatorPos || wallsController.Walls[0].transform.position != wallsController.endPositionV3[0])    //  Поворот камери навколо рівня
        {
            Debug.Log("Зациклення");
            transform.rotation = Quaternion.Slerp(transform.rotation, endRotatorPos, rotationSpeed * Time.deltaTime);
            wallsController.WallsNormalizade(rotationSpeed);
            //if (transform.rotation.eulerAngles.y < 0.5 && transform.rotation.eulerAngles.y > -0.5)
            //    transform.rotation = endRotatorPos;
            //if (transform.rotation.eulerAngles.y < 90 + 0.5 && transform.rotation.eulerAngles.y > 90 - 0.5)
            //    transform.rotation = endRotatorPos;
            //if (transform.rotation.eulerAngles.y < -180 + 0.5 && transform.rotation.eulerAngles.y > 180 - 0.5)
            //    transform.rotation = endRotatorPos;
            //if (transform.rotation.eulerAngles.y < -90 + 0.5 && transform.rotation.eulerAngles.y > -90 - 0.5)
            //    transform.rotation = endRotatorPos;
        }
        //else if (transform.rotation != endRotatorPos)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, endRotatorPos, Time.deltaTime * CameraRotateScale);
        //    wallController.WallsNormalizade(CameraRotateScale);
        //}
    }

    private void RotateAround(IController icontroller)  //  Обертання камери навколо Обєкта
    {

    }

    private void Bac(IController icontroller)   // повернення камери на першопочаткову точку навколо рівня
    {

    }
    private void MoveTo(IController icontroller)    //  Рух камери до обєкта на який було нажато
    {

    }
    private void MoveInSpace(IController icontroller)   //  Рух камери в площинні яка обмежена певними гранями(значеннями X,Y)
    {

    }
}
