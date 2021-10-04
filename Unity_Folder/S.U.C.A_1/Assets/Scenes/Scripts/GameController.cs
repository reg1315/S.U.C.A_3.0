using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TypeController
{
    Caybourd,
    Finger
}

public class GameController : MonoBehaviour
{
    private IController icontroller;
    private CaybourdController caybourd = new CaybourdController();
    private FingerCintroller finger = new FingerCintroller();

    [SerializeField] private TypeController typeController = TypeController.Finger;
    [Space]
    [SerializeField] private CameraController mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("CenterOfCameraRotate").GetComponent<CameraController>();
        ControlType();
    }

    void Update()
    {
        mainCamera.Controller(icontroller);
    }

    private void ControlType()
    {
        if (typeController == TypeController.Finger)
            icontroller = finger;
        else if (typeController == TypeController.Caybourd)
            icontroller = caybourd;
    }
}
