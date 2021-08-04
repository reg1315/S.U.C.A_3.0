using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToObject : MonoBehaviour,IPointerClickHandler
{
    public GameControler gamecontroler;

    private bool oneclic = false;

    public bool cameraRotate = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!oneclic)
        {
            CameraFirstPos = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);

            ShowMeCamera.Default();
            ShowMeCamera.target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            ShowMeCamera.Blook = true;
            cameraRotateAround.target = gameObject.transform;


            gamecontroler.muveaccess = false;
            StartCoroutine(Up());
            Bmovetoheobject = true;
            oneclic = true;
        }
    }

    public float x, y, z;
    public float YRotation;

    public Camera MainCamera;
    public ShowMe ShowMeCamera;
    public PhysicsRaycaster PhysicsRaycasterCamera;
    public CameraRotateAround cameraRotateAround;

    private Vector3 CameraFirstPos;
    private Vector3 CameraEndPos;

    public float speed = 10;

    private bool Bmovetoheobject = false;
    private bool Bmovetotheback = false;
    private bool Bescape = false;

    void Start()
    {
        CameraEndPos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (Bescape) Escape();
        if (Bmovetotheback) BacAnimation();

        if (Bmovetoheobject) OnClicAnimation();

    }

    private void OnClicAnimation()
    {
        if (MainCamera.transform.position != CameraEndPos)
        {
            Move(CameraEndPos);
        }
        else
        {
            ShowMeCamera.Blook = false;

            Bescape = true;
            Bmovetoheobject = false;

            cameraRotateAround.bRotate = cameraRotate;
            //cameraRotateAround.X = MainCamera.transform.localEulerAngles.y;
            //cameraRotateAround.Y = MainCamera.transform.localEulerAngles.x;
        }
    }

    private void BacAnimation()
    {
        if (MainCamera.transform.position != CameraFirstPos)
        {
            Move(CameraFirstPos);
        }
        else
        {
            PhysicsRaycasterCamera.enabled = true;
            Bmovetotheback = false;
            gamecontroler.muveaccess = true;

            ShowMeCamera.Default();
            ShowMeCamera.speed = speed;
        }
    }

    private void Escape()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Bacswipe())
        {
            PhysicsRaycasterCamera.enabled = false;
            cameraRotateAround.bRotate = false;

            gamecontroler.normalizade();

            Bmovetoheobject = false;
            Bmovetotheback = true;
            Bescape = false;

            ShowMeCamera.Blook = true;

            oneclic = false;
        }
    }

    private float distance;
    private bool Bacswipe()
    {
        if (Input.touchCount == 3)
        {
            Vector2 finger1 = Input.GetTouch(0).position;
            Vector2 finger3 = Input.GetTouch(2).position;

            float delta = Vector2.Distance(finger1, finger3);
            var touch = Input.GetTouch(1);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    distance = delta;
                    break;
                case TouchPhase.Moved:
                    if (delta < distance) return true;
                    break;
            }
        }

        return false;
    }

    private void Move(Vector3 pos)
    {
        MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, pos, Time.deltaTime * speed);
    }

    IEnumerator Up()
    {
        yield return new WaitForSeconds(0.4f);

        gamecontroler.Up();
    }
}
