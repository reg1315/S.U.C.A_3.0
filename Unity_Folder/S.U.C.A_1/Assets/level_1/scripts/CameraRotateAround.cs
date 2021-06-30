using UnityEngine;
using System.Collections;

public class CameraRotateAround : MonoBehaviour
{

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limit = 80; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	public float X, Y;
	public float ClampX, ClampY, ClampZ;
	public Quaternion ClampRotation;

	public bool bRotate = false;

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
		if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		Y += Input.GetAxis("Mouse Y") * sensitivity;
		Y = Mathf.Clamp(Y, -limit, limit);
		transform.localEulerAngles = new Vector3(-Y, X, 0);
		transform.position = transform.parent.rotation * transform.localRotation * offset + target.position;

		RaycastHit hit;
		Debug.DrawLine(target.position, transform.position, Color.blue);
		if (Physics.Linecast(target.position, transform.position, out hit))
		{
			float tempDistance = Vector3.Distance(target.position, hit.point);
            if (tempDistance == zoomMin)
            {

			}
            else if (tempDistance < zoomMin - 0.05f)
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
}