using MyLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteAlways]
public class MuveTo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    private CameraController centerOfCameraRotate;

    public bool clic = false;
    public Vector3 offset = new Vector3(0, 0, 0);
    public Vector2 limit = new Vector2(0, 0);
    private WallsController wallsController;
    public CameraControllerLyer NextLier = CameraControllerLyer.LierMoveInSpace;

    private void Start()
    {
        centerOfCameraRotate = GameObject.Find("CenterOfCameraRotate").GetComponent<CameraController>();
        wallsController = GameObject.Find("floor").GetComponent<WallsController>();
        if (p2 == null)
            p2 = transform.GetChild(0);
        if(p3 == null)
            p3 = transform.GetChild(1);
    }
   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!clic && centerOfCameraRotate.gmObjToMove == null)
        {
            StartCoroutine(wallsController.WallsUp());

            centerOfCameraRotate.gmObjToMove = transform;
            centerOfCameraRotate.bRotateAroundLvL = false;
            centerOfCameraRotate.MainLier = CameraControllerLyer.LierMoveTo;
            centerOfCameraRotate.NextLier = NextLier;
            target = centerOfCameraRotate.transform.GetChild(0).position;

            clic = true;
        }
    }

    [Space]
    public Transform p2, p3;
    public Vector3 target;

    [Space]
    public bool drawGizmos = false;
    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            int sigmentsNumber = 20;
            Vector3 preveoisePoint = target;

            for (int i = 0; i < sigmentsNumber + 1; i++)
            {
                float parametr = (float)i / sigmentsNumber;
                Vector3 point = Bizue.GetPoint(target, p2.position, p3.position, transform.position + offset, parametr);
                Gizmos.DrawLine(preveoisePoint, point);
                preveoisePoint = point;
            }
        }
    }
}
