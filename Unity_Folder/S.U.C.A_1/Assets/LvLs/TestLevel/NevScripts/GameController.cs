using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType
{
    Finger_Control,
    Ceybourd_Control
}

public class GameController : MonoBehaviour
{ 
    public ControlType myController;

    private IControlToDo iController;
    private FingerControl fingerControl;

    public CameraControl mainCamera;

    private void Start()
    {
        ControlTypeSelection();
    }

    private void Update()
    {
        mainCamera.CameraController(iController);
    }

    private void ControlTypeSelection()
    {
        if (myController == ControlType.Finger_Control) iController = fingerControl;
    }
}
