using UnityEngine;
using MyLibrary;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform camera;  //  Змінна самої камери яка є в середені батьківського елемента CenterOfCameraRotate

    private void Start()
    {
        endRotatorPos = transform.rotation;

        camera = transform.GetChild(1);
        camera.GetComponent<Animation>().Play();

        StartCoroutine(ToStartLvL());
    }
    

    public CameraControllerLyer MainLier;   //  зберігає поточний шар можливостей контролю камери
    public CameraControllerLyer NextLier;   //  Зберігає наступний шар який стане головним
    public void Controller(IController icontroller) //  Головний скріпт який контролює камеру відносно її теперішнього положення
    {
        /*--------------------------------------------------------------------------------------------  Описує функціонал в залежності від MainCameraLier  --*/
        if (MainLier == CameraControllerLyer.LierBack || icontroller.Back())
        {
            MainLier = CameraControllerLyer.LierBack;
            if (icontroller.Back())
            {
                wallsController.WallsNormalizade(); //  нормаліую стіни моментально
                gmObjToMove.GetComponent<OnClic>().clic = false;
                gmObjToMove = null;
                
            }

            Back();
        }

        if (MainLier == CameraControllerLyer.Lier0)
            RotateAroundLvL(icontroller);
        else if (gmObjToMove != null && MainLier == CameraControllerLyer.LierMoveTo)
            MoveTo();
        else if (gmObjToMove != null && MainLier == CameraControllerLyer.LierRotateAround)
            RotateAround(icontroller);
        else if (gmObjToMove != null && MainLier == CameraControllerLyer.LierMoveInSpace)
            MoveInSpace(icontroller);

        
        
    }


    [Space] //  змінні для руху до обєкту
    public Transform gmObjToMove;
    public bool bMoveTo = false;
    private void MoveTo()    //  Рух камери до обєкта(target) на який було нажато
     {
        camera.position = Vector3.Lerp(camera.position, gmObjToMove.position + gmObjToMove.GetComponent<OnClic>().offset, 10*Time.deltaTime);
        camera.LookAt(gmObjToMove);
        if (camera.position == gmObjToMove.position + gmObjToMove.GetComponent<OnClic>().offset)
        {
            MainLier = NextLier;    //  набір дозволів
        }
     } 


    private void Back()   // повернення камери на першопочаткову точку навколо рівня
    {  
        if (new Comparison().CheckRange(camera.localPosition, new Vector3(3.6f, 3.6f, 3.6f), new Vector3(0.05f, 0.05f, 0.05f)) && new Comparison().CheckRange(camera.localRotation, new Vector3(30, 225, 0), new Vector3(0.05f, 0.05f, 0.05f)))
        {
            camera.localPosition = new Vector3(3.6f, 3.6f, 3.6f);               //  вказую що камера має зайняти таке положення
            camera.localRotation = Quaternion.Euler(new Vector3(30, 225, 0));   //

            /*------------------------------------------  Набір дозволів  --*/
            MainLier = CameraControllerLyer.Lier0;
        }
        else
        {
            /*--------------------------------------------------------------------------------------------------------------  повернення в сторону центра при поверненні в початкове положення  --*/
            camera.localPosition = Vector3.Lerp(camera.localPosition, new Vector3(3.6f, 3.6f, 3.6f), 10 * Time.deltaTime);
            camera.LookAt(new Vector3(0, 0.66f, 0));
            //camera.localRotation = Quaternion.Slerp(camera.localRotation, Quaternion.Euler(new Vector3(30, camera.localRotation.eulerAngles.y, camera.localRotation.eulerAngles.z)), rotationSpeed * Time.deltaTime);
        }
    }


    /*Змінні які використовуються для повороту камери навколо рівня*/
    private Quaternion endRotatorPos;
    public bool bRotateAroundLvL = false;
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
                wallsController.endPositionV3[2] = wallsController.upPosition[2];
                wallsController.endPositionV3[3] = wallsController.upPosition[3];
            }
            else if (transform.eulerAngles.y < 165 & transform.eulerAngles.y >= 75)
            {
                endRotatorPos = Quaternion.Euler(0, 180, 0);
                wallsController.endPositionV3[0] = wallsController.upPosition[0];
                wallsController.endPositionV3[1] = wallsController.downPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.upPosition[3];
            }
            else if (transform.eulerAngles.y < 255 & transform.eulerAngles.y >= 165)
            {
                endRotatorPos = Quaternion.Euler(0, 270, 0);
                wallsController.endPositionV3[0] = wallsController.upPosition[0];
                wallsController.endPositionV3[1] = wallsController.upPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
            else
            {
                endRotatorPos = Quaternion.Euler(0, 360, 0);
                wallsController.endPositionV3[0] = wallsController.downPosition[0];
                wallsController.endPositionV3[1] = wallsController.upPosition[1];
                wallsController.endPositionV3[2] = wallsController.upPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
        }

        if (icontroller.Right())    //  Задання кінечної точки при повороті вправо
        {
            if (transform.eulerAngles.y <= 105 & transform.eulerAngles.y > 15)
            {
                endRotatorPos = Quaternion.Euler(0, 0, 0);
                wallsController.endPositionV3[0] = wallsController.downPosition[0];
                wallsController.endPositionV3[1] = wallsController.upPosition[1];
                wallsController.endPositionV3[2] = wallsController.upPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
            else if (transform.eulerAngles.y <= 195 & transform.eulerAngles.y > 95)
            {
                endRotatorPos = Quaternion.Euler(0, 90, 0);
                wallsController.endPositionV3[0] = wallsController.downPosition[0];
                wallsController.endPositionV3[1] = wallsController.downPosition[1];
                wallsController.endPositionV3[2] = wallsController.upPosition[2];
                wallsController.endPositionV3[3] = wallsController.upPosition[3];
            }
            else if (transform.eulerAngles.y <= 285 & transform.eulerAngles.y > 195)
            {
                endRotatorPos = Quaternion.Euler(0, 180, 0);
                wallsController.endPositionV3[0] = wallsController.upPosition[0];
                wallsController.endPositionV3[1] = wallsController.downPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.upPosition[3];
            }
            else
            {
                endRotatorPos = Quaternion.Euler(0, 270, 0);
                wallsController.endPositionV3[0] = wallsController.upPosition[0];
                wallsController.endPositionV3[1] = wallsController.upPosition[1];
                wallsController.endPositionV3[2] = wallsController.downPosition[2];
                wallsController.endPositionV3[3] = wallsController.downPosition[3];
            }
        }

        if (transform.rotation != endRotatorPos || wallsController.Walls[0].transform.position != wallsController.endPositionV3[0])    //  Поворот камери навколо рівня
        {
            if (new Comparison().CheckRange(transform.rotation, endRotatorPos.eulerAngles) && new Comparison().CheckRange(wallsController.Walls[0].transform.position, wallsController.endPositionV3[0]))
            {
                transform.rotation = endRotatorPos;
                wallsController.WallsNormalizade();
            }
            else
            {
                Debug.Log("Зациклення");
                transform.rotation = Quaternion.Slerp(transform.rotation, endRotatorPos, rotationSpeed * Time.deltaTime);
                wallsController.WallsNormalizade(rotationSpeed);
            }
        }
    }

    private void RotateAround(IController icontroller)  //  Обертання камери навколо Обєкта
    {
        float speed = 0.3f;
        float limitY;
        if (gmObjToMove.GetComponent<OnClic>().limit.y == 0)
            limitY = 90;
        else
            limitY = gmObjToMove.GetComponent<OnClic>().limit.y;

        camera.RotateAround(gmObjToMove.localPosition, camera.right ,icontroller.Move(speed).y);
        camera.RotateAround(gmObjToMove.localPosition, Vector3.up, -icontroller.Move(speed).x);

        Ray ray = new Ray(gmObjToMove.position, camera.position);
        Debug.DrawRay(gmObjToMove.position,camera.position,Color.red);

        RotateAroandNormalizade(camera,limitY);  

        camera.LookAt(gmObjToMove);
    }

    private void RotateAroandNormalizade(Transform camera, float limity)
    {
        float x = Mathf.Clamp(camera.rotation.eulerAngles.x, -limity, limity);
        camera.rotation = Quaternion.Euler(x, camera.rotation.eulerAngles.y, camera.rotation.eulerAngles.z);
    }

    private void MoveInSpace(IController icontroller)   //  Рух камери в площинні яка обмежена певними гранями(значеннями X,Y)
    {
        float speed = 0.01f;
        float limitX = gameObject.GetComponent<OnClic>().limit.x;
        float limitY = gameObject.GetComponent<OnClic>().limit.y;

        camera.Translate(icontroller.Move(speed).x, icontroller.Move(speed).y, 0);

        
        Vector3 offset = gameObject.transform.position + gameObject.GetComponent<OnClic>().offset;
        camera.position = new Vector3(Mathf.Clamp(camera.position.x, /*offset.x - limitX*/-1, /*offset.x + limitX*/1), Mathf.Clamp(camera.position.y, /*offset.y - limitY*/-2, /*offset.y + limitY*/2),camera.position.z);
    }

    public IEnumerator ToStartLvL()    // псевдо приближення при старті гри
    {
        yield return new WaitForSeconds(1f);
        bRotateAroundLvL = true;
    }   
}