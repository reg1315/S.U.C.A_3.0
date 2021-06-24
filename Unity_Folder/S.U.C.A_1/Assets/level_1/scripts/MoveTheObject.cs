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
            Bmovetheobject = true;
            CameraFirstPos = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
            CameraEndPos = new Vector3(transform.position.x + x, transform.position.z + y, -transform.position.y + z);
            CameraFirstRotation = Quaternion.Euler(MainCamera.transform.rotation.eulerAngles.x, MainCamera.transform.rotation.eulerAngles.y, MainCamera.transform.rotation.eulerAngles.z);
            CameraEndRotation = Quaternion.Euler(0, YRotation, 0);
            oneclic = true;
            gamecontroler.muveaccess = false;
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

    private bool Bmovetheobject = false;
    private bool Bmovetotheback = false;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //OnClicAnimation();
        if (Bmovetheobject)
        {
            if (MainCamera.transform.position == CameraEndPos)
            {
                Bmovetheobject = false;
            }
            else if (MainCamera.transform.position != CameraEndPos)
            {
                Bmovetotheback = false;
                Move(CameraEndPos, CameraEndRotation);
            }
        }

        if (Bmovetotheback)
        {
            if (MainCamera.transform.position == CameraFirstPos)
            {
                Bmovetotheback = false;
                gamecontroler.muveaccess = true;
            }
            else if(MainCamera.transform.position != CameraFirstPos)
            {
                Bmovetheobject = false;
                Move(CameraFirstPos, CameraFirstRotation);
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Bmovetheobject = false;
            Bmovetotheback = true;
            oneclic = false;
        }
    }

    private void OnClicAnimation()
    {
        if (Bmovetheobject)
        {
            if (MainCamera.transform.position != CameraEndPos)
            {
                Bmovetotheback = false;
                Move(CameraEndPos, CameraEndRotation);
            }
            else if (MainCamera.transform.position == CameraEndPos)
            {
                Bmovetheobject = false;
            }
        }

        if (Bmovetotheback)
        {
            if (MainCamera.transform.position != CameraFirstPos)
            {
                Bmovetheobject = false;
                Move(CameraFirstPos, CameraFirstRotation);
            }
            else if (MainCamera.transform.position == CameraFirstPos)
            {
                Bmovetotheback = false;
                gamecontroler.muveaccess = true;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Bmovetheobject = false;
            Bmovetotheback = true;
            oneclic = false;
        }
    }
    private void Move(Vector3 pos, Quaternion rotation)
    {
        MainCamera.transform.rotation = Quaternion.Slerp(MainCamera.transform.rotation, rotation, Time.deltaTime * speed);
        MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, pos,Time.deltaTime * speed);
        //StartCoroutine(waiter(pos, rotation));
    }

    IEnumerator waiter(Vector3 pos, Quaternion rotation)
    {
        yield return new WaitForSeconds(Time.deltaTime * speed * 20);
        MainCamera.transform.rotation = rotation;
        MainCamera.transform.position = pos;
    }
}
