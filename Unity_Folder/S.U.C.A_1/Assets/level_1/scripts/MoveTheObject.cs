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
            CameraEndPos = new Vector3(transform.position.x + x, transform.position.z + y, -transform.position.y + z);
            CameraFirstRotation = Quaternion.Euler(MainCamera.transform.rotation.eulerAngles.x, MainCamera.transform.rotation.eulerAngles.y, MainCamera.transform.rotation.eulerAngles.z);
            CameraEndRotation = Quaternion.Euler(0, YRotation, 0);
            
            gamecontroler.muveaccess = false;
            Bmovetoheobject = true;
            oneclic = true;
        }
    }

    public float x, y, z;
    public float YRotation;

    public Camera MainCamera;

    private Vector3 CameraFirstPos;
    private Quaternion CameraFirstRotation;
    private Vector3 CameraEndPos;
    private Quaternion CameraEndRotation;

    public float speed;

    private bool Bmovetoheobject = false;
    private bool Bmovetotheback = false;
    private bool Bescape = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Bescape) { Escape(); }
        if (Bmovetotheback) { BacAnimation(); }

        if (Bmovetoheobject) { OnClicAnimation(); }

    }

    private void OnClicAnimation()
    {
        if (MainCamera.transform.position != CameraEndPos)
        {
            Move(CameraEndPos, CameraEndRotation);
        }
        else
        {
            Bescape = true;
            Bmovetoheobject = false;
        }
    }

    private void BacAnimation()
    {
        if (MainCamera.transform.position != CameraFirstPos)
        {
            Move(CameraFirstPos, CameraFirstRotation);
        }
        else
        {
            Bmovetotheback = false;
            gamecontroler.muveaccess = true;
        }
    }

    private void Escape()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Bmovetoheobject = false;
            Bmovetotheback = true;
            Bescape = false;
            oneclic = false;
        }
    }

    private void Move(Vector3 pos, Quaternion rotation)
    {
        MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, pos, Time.deltaTime * speed);
        MainCamera.transform.rotation = Quaternion.Slerp(MainCamera.transform.rotation, rotation, Time.deltaTime * speed);
        //if(MainCamera.transform.position.x>= pos.x - 0.005 & MainCamera.transform.position.x <= pos.x + 0.005)
        //{
        //    MainCamera.transform.position = pos;
        //    MainCamera.transform.rotation = rotation;
        //}
        //StartCoroutine(waiter(pos, rotation));
    }

    //IEnumerator waiter(Vector3 pos, Quaternion rotation)
    //{
    //    yield return new WaitForSeconds(Time.deltaTime * speed * 20);
    //    MainCamera.transform.rotation = rotation;
    //    MainCamera.transform.position = pos;
    //}
}
