using UnityEngine;
using UnityEngine.EventSystems;

public class MoveTheObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Bmovetheobject = true;
        CameraFirstPos = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
        CameraEndPos = new Vector3(transform.position.x+x, transform.position.z+y, -transform.position.y+z);
        CameraFirstRotation = Quaternion.Euler(MainCamera.transform.rotation.eulerAngles.x, MainCamera.transform.rotation.eulerAngles.y, MainCamera.transform.rotation.eulerAngles.z);
        CameraEndRotation = Quaternion.Euler(0, YRotation, 0);
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
        if (Bmovetheobject & MainCamera.transform.position != CameraEndPos)
        {
            Move(CameraEndPos,CameraEndRotation);
        }
        else if (Bmovetotheback & MainCamera.transform.position != CameraFirstPos)
        {
            Move(CameraFirstPos, CameraFirstRotation);
        }else if (Bmovetheobject & MainCamera.transform.position == CameraEndPos)
        {
            Bmovetheobject = false;
        }
        else if (Bmovetotheback & MainCamera.transform.position == CameraFirstPos)
        {
            Bmovetotheback = false;
        }

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Bmovetheobject = false;
            Bmovetotheback = true;
        }
    }

    private void Move(Vector3 endpos, Quaternion rotation)
    {
        MainCamera.transform.rotation = Quaternion.Slerp(MainCamera.transform.rotation, rotation, Time.deltaTime * speed);
        MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, endpos, speed * Time.deltaTime);
    }
}
