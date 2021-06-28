using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveTheObject : MonoBehaviour, IPointerClickHandler
{
    public GameControler gamecontroler;

    private bool oneclic = false;
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
            Bmovetoheobject = true;
            oneclic = true;
        }
    }

    public float x, y, z;
    public float YRotation;

    public Camera MainCamera;
    public ShowMe ShowMeCamera;
    public CameraRotateAround cameraRotateAround;

    private Vector3 CameraFirstPos;
    private Vector3 CameraEndPos;

    public float speed;

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

            cameraRotateAround.bRotate = true;
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
            Bmovetotheback = false;
            gamecontroler.muveaccess = true;

            ShowMeCamera.Default();
            ShowMeCamera.speed = speed;
        }
    }

    private void Escape()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            cameraRotateAround.bRotate = false;

            Bmovetoheobject = false;
            Bmovetotheback = true;
            Bescape = false;

            ShowMeCamera.Blook = true;

            oneclic = false;
        }
    }

    private void Move(Vector3 pos)
    {
        MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, pos, Time.deltaTime * speed);
    }
}
