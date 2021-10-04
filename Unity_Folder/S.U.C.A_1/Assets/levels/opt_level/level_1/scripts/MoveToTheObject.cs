using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToTheObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Bmovetheobject = true;
        ObjFirstPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ObjEndPos = new Vector3(MainCamera.transform.position.x + x, MainCamera.transform.position.z + y, -MainCamera.transform.position.y + z);
        ObjFirstRotation = Quaternion.Euler(MainCamera.transform.rotation.eulerAngles.x, MainCamera.transform.rotation.eulerAngles.y, MainCamera.transform.rotation.eulerAngles.z);
        ObjEndRotation = Quaternion.Euler(0, YRotation, 0);
    }

    public float x, y, z;
    public float YRotation;

    public Camera MainCamera;

    private Vector3 ObjFirstPos;
    private Quaternion ObjFirstRotation;
    private Vector3 ObjEndPos;
    private Quaternion ObjEndRotation;

    public float speed;

    private bool Bmovetheobject = false;
    private bool Bmovetotheback = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bmovetheobject & transform.position != ObjEndPos)
        {
            Move(ObjEndPos, ObjEndRotation);
        }
        else if (Bmovetotheback & transform.position != ObjFirstPos)
        {
            Move(ObjFirstPos, ObjFirstRotation);
        }
        else if (Bmovetheobject & transform.position == ObjEndPos)
        {
            Bmovetheobject = false;
        }
        else if (Bmovetotheback & transform.position == ObjFirstPos)
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
        Debug.Log("—кр≥п запущено");
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
        transform.position = Vector3.Lerp(transform.position, endpos, speed * Time.deltaTime);
    }
}
