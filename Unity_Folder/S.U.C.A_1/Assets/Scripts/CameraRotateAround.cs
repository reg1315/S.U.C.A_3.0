using UnityEngine;
using System.Collections;

public class CameraRotateAround : MonoBehaviour
{

	public Transform target;
	public Vector3 offset;
	public float sensivity = 3; // чувствительность мышки
	public float limit = 80; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	public float X, Y;
	private float ClampX, ClampY, ClampZ;
	private Quaternion ClampRotation;

	public bool bRotate = false;

	private Vector2 startPos;
	private Vector3 startCameraPos;

	private float distance;

	public float deltatime0;
	public float deltatime1;

	void Start()
	{
		limit = Mathf.Abs(limit);
		if (limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax));
		transform.position = target.position + offset;
	}

	//void Moved()
 //   {
	//	if(Input.)
 //   }

	void Update()
	{
		if (bRotate) Rotate();
	}

	private void Rotate()
    {
		//Zoom to PC
		//if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		//else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		//offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		//Zoom to SmartPhone device
		if (Input.touchCount == 2) Zoom();

		//Rotation to SmartPhone device
		if (Input.touchCount == 1)
		{
			var touch = Input.GetTouch(0);
			
			switch (touch.phase)
			{
				case TouchPhase.Began:
					startPos = touch.position;
					startCameraPos = transform.localEulerAngles;
					break;

				case TouchPhase.Moved:
					var dir = touch.position - startPos;
					startPos = touch.position;
					X = startCameraPos.y + dir.x * sensivity;
					Y = startCameraPos.x - dir.y * sensivity;

					Y = Mathf.Clamp(Y, -90, limit);
					transform.localEulerAngles =  new Vector3(Y, X, 0);
					transform.position = transform.parent.rotation * transform.localRotation * offset + target.position;
					startCameraPos = transform.localEulerAngles;
					break;
			}
		}

        //Вирівнювання (Не знаю як буде на англ якщо хтось знає напишіть в лапках)
        RaycastHit hit;
        Debug.DrawLine(target.position, transform.position, Color.blue);
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            float tempDistance = Vector3.Distance(target.position, hit.point);
            if (tempDistance == zoomMin)
            {

            }
            else if (tempDistance < zoomMin)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, ClampX, ClampX), Mathf.Clamp(transform.position.y, ClampY, ClampY), Mathf.Clamp(transform.position.z, ClampZ, ClampZ));
                transform.rotation = ClampRotation;
                Debug.DrawLine(target.position, transform.position, Color.red);
            }
            else
            {
                Vector3 pos = target.position - (transform.rotation * Vector3.forward * tempDistance);
                transform.position = new Vector3(pos.x, pos.y + 0.02f, pos.z); // сдвиг позиции в точку контакта

                ClampX = transform.position.x;
                ClampY = transform.position.y;
                ClampZ = transform.position.z;

                ClampRotation = transform.rotation;
            }
        }
    }
	private void Zoom()
	{
		Vector2 finger1 = Input.GetTouch(0).position;
		Vector2 finger2 = Input.GetTouch(1).position;

		float delta = Vector2.Distance(finger1, finger2);
		var touch = Input.GetTouch(1);
        switch (touch.phase)
        {
			case TouchPhase.Began:
				distance = delta;
				break;
			case TouchPhase.Moved:
				if (delta > distance) offset.z += zoom;
				else if(delta < distance) offset.z -= zoom;
				offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
				break;
        }
	}
}