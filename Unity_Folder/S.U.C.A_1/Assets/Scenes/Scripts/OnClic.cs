using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MyLibrary;

public class OnClic : MonoBehaviour, IPointerClickHandler
{
    public bool clic = false;
    [SerializeField] private CameraController centerOfCameraRotate;
    public Vector3 offset = new Vector3(0,0,0);
    public Vector2 limit = new Vector2(0,0);
    private WallsController wallsController;

    public CameraControllerLyer NextLier = CameraControllerLyer.LierMoveInSpace;

    private void Start() {
        centerOfCameraRotate = GameObject.Find("CenterOfCameraRotate").GetComponent<CameraController>();
        wallsController = GameObject.Find("floor").GetComponent<WallsController>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!clic)
        {
            StartCoroutine(wallsController.WallsUp());

            centerOfCameraRotate.gmObjToMove = transform;
            centerOfCameraRotate.bRotateAroundLvL = false;
            centerOfCameraRotate.MainLier = CameraControllerLyer.LierMoveTo;
            centerOfCameraRotate.NextLier = NextLier;

            clic = true;
        }
    }
}
