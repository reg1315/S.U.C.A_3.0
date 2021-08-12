using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveArouand : MonoBehaviour
{
	public float sensivity;
	public Transform target;

	public float xLimit, yLimit;

	public bool bMuve;

	public Vector2 startFingerPos;
	public Vector3 startCameraPos;

	private float X, Y;

	void Start()
	{
		xLimit = Mathf.Abs(xLimit);
		yLimit = Mathf.Abs(yLimit);

	}

	void Update()
	{
		if (bMuve) Rotate();
	}

	private void Rotate()
	{
		//Zoom to PC
		//if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		//else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		//offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		//Zoom to SmartPhone device
		//if (Input.touchCount == 2) Zoom();

		//Rotation to SmartPhone device
		if (Input.touchCount > 0)
		{
			var touch = Input.GetTouch(0);

			switch (touch.phase)
			{
				case TouchPhase.Began:
					startFingerPos = touch.position;
					startCameraPos = transform.position;
					break;

				case TouchPhase.Moved:
					var dir = touch.position - startFingerPos;
					X = startCameraPos.x + dir.x * sensivity;
					Y = startCameraPos.y - dir.y * sensivity;
					X = Mathf.Clamp(X, target.position.x - xLimit, target.position.x + xLimit);
					Y = Mathf.Clamp(Y, target.position.y - yLimit, target.position.y + yLimit);

					transform.position = new Vector3(X, -Y, transform.position.z);
					break;
			}
		}

		//Вирівнювання (Не знаю як буде на англ якщо хтось знає напишіть в лапках)
		//RaycastHit hit;
		//Debug.DrawLine(target.position, transform.position, Color.blue);
		//if (Physics.Linecast(target.position, transform.position, out hit))
		//{
		//	float tempDistance = Vector3.Distance(target.position, hit.point);
		//	if (tempDistance == zoomMin)
		//	{

		//	}
		//	else if (tempDistance < zoomMin)
		//	{
		//		transform.position = new Vector3(Mathf.Clamp(transform.position.x, ClampX, ClampX), Mathf.Clamp(transform.position.y, ClampY, ClampY), Mathf.Clamp(transform.position.z, ClampZ, ClampZ));
		//		transform.rotation = ClampRotation;
		//		Debug.DrawLine(target.position, transform.position, Color.red);
		//	}
		//	else
		//	{
		//		Vector3 pos = target.position - (transform.rotation * Vector3.forward * tempDistance);
		//		transform.position = new Vector3(pos.x, pos.y + 0.02f, pos.z); // сдвиг позиции в точку контакта

		//		ClampX = transform.position.x;
		//		ClampY = transform.position.y;
		//		ClampZ = transform.position.z;

		//		ClampRotation = transform.rotation;
		//	}
		//}
	}
	//private void Zoom()
	//{
	//	Vector2 finger1 = Input.GetTouch(0).position;
	//	Vector2 finger2 = Input.GetTouch(1).position;

	//	float delta = Vector2.Distance(finger1, finger2);
	//	var touch = Input.GetTouch(1);
	//	switch (touch.phase)
	//	{
	//		case TouchPhase.Began:
	//			distance = delta;
	//			break;
	//		case TouchPhase.Moved:
	//			if (delta > distance) offset.z += zoom;
	//			else if (delta < distance) offset.z -= zoom;
	//			offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
	//			break;
	//	}
	//}
}
