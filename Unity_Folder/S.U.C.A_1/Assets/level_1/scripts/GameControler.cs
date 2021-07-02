using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    Quaternion endPosition;

    public float rotationSpeed;

    public GameObject[] Wols = new GameObject[4];
    private Vector3[] endPositionV3 = new Vector3[4];
    private Vector3 downPosition;
    private Vector3 normalPosition;

    private Vector2 startPos;
    private Vector3 startCameraPos;
    public float sensivity = 0.1f;

    public float speed;

    public float down;

    public GameObject rotator;

    // Start is called before the first frame update
    void Start()
    {
        normalPosition = Vector3.zero;
        downPosition = new Vector3(0, down, 0);

        endPositionV3[0] = downPosition;
        endPositionV3[1] = normalPosition;
        endPositionV3[2] = normalPosition;
        endPositionV3[3] = downPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (muveaccess)
        {
            ADMove();
        }


    }

    public bool muveaccess = true;
    private void ADMove()
    {
        if (LeftSwipe())
        {
            if ((rotator.transform.eulerAngles.y >= 345 & rotator.transform.eulerAngles.y <= 360) || (rotator.transform.eulerAngles.y >= 0 & rotator.transform.eulerAngles.y < 75))
            {
                endPosition = Quaternion.Euler(0, 90, 0);
                endPositionV3[0] = downPosition;
                endPositionV3[1] = downPosition;
                endPositionV3[2] = normalPosition;
                endPositionV3[3] = normalPosition;
            }
            else if (rotator.transform.eulerAngles.y < 165 & rotator.transform.eulerAngles.y >= 75)
            {
                endPosition = Quaternion.Euler(0, 180, 0);
                endPositionV3[0] = normalPosition;
                endPositionV3[1] = downPosition;
                endPositionV3[2] = downPosition;
                endPositionV3[3] = normalPosition;
            }
            else if (rotator.transform.eulerAngles.y < 255 & rotator.transform.eulerAngles.y >= 165)
            {
                endPosition = Quaternion.Euler(0, 270, 0);
                endPositionV3[0] = normalPosition;
                endPositionV3[1] = normalPosition;
                endPositionV3[2] = downPosition;
                endPositionV3[3] = downPosition;
            }
            else
            {
                endPosition = Quaternion.Euler(0, 360, 0);
                endPositionV3[0] = downPosition;
                endPositionV3[1] = normalPosition;
                endPositionV3[2] = normalPosition;
                endPositionV3[3] = downPosition;
            }
        }

        if (RightSwipe())
        {
            if (rotator.transform.eulerAngles.y <= 105 & rotator.transform.eulerAngles.y > 15)
            {
                endPosition = Quaternion.Euler(0, 0, 0);
                endPositionV3[0] = downPosition;
                endPositionV3[1] = normalPosition;
                endPositionV3[2] = normalPosition;
                endPositionV3[3] = downPosition;
            }
            else if (rotator.transform.eulerAngles.y <= 195 & rotator.transform.eulerAngles.y > 95)
            {
                endPosition = Quaternion.Euler(0, 90, 0);
                endPositionV3[0] = downPosition;
                endPositionV3[1] = downPosition;
                endPositionV3[2] = normalPosition;
                endPositionV3[3] = normalPosition;
            }
            else if (rotator.transform.eulerAngles.y <= 285 & rotator.transform.eulerAngles.y > 195)
            {
                endPosition = Quaternion.Euler(0, 180, 0);
                endPositionV3[0] = normalPosition;
                endPositionV3[1] = downPosition;
                endPositionV3[2] = downPosition;
                endPositionV3[3] = normalPosition;
            }
            else
            {
                endPosition = Quaternion.Euler(0, 270, 0);
                endPositionV3[0] = normalPosition;
                endPositionV3[1] = normalPosition;
                endPositionV3[2] = downPosition;
                endPositionV3[3] = downPosition;
            }
        }

        if (rotator.transform.rotation != endPosition)
        {
            rotator.transform.rotation = Quaternion.Slerp(rotator.transform.rotation, endPosition, Time.deltaTime * rotationSpeed);
        }

        if (Wols[0].transform.position != endPositionV3[0])
        {
            Wols[0].transform.position = Vector3.Lerp(Wols[0].transform.position, endPositionV3[0], speed * Time.deltaTime);
        }
        if (Wols[1].transform.position != endPositionV3[1])
        {
            Wols[1].transform.position = Vector3.Lerp(Wols[1].transform.position, endPositionV3[1], speed * Time.deltaTime);
        }
        if (Wols[2].transform.position != endPositionV3[2])
        {
            Wols[2].transform.position = Vector3.Lerp(Wols[2].transform.position, endPositionV3[2], speed * Time.deltaTime);
        }
        if (Wols[3].transform.position != endPositionV3[3])
        {
            Wols[3].transform.position = Vector3.Lerp(Wols[3].transform.position, endPositionV3[3], speed * Time.deltaTime);
        }
    }

    bool LeftSwipe()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    startCameraPos = rotator.transform.localEulerAngles;
                    break;
                case TouchPhase.Moved:
                    float X = startCameraPos.y + (touch.position.x - startPos.x)* sensivity;
                    rotator.transform.localEulerAngles = new Vector3(rotator.transform.localEulerAngles.x, X, rotator.transform.localEulerAngles.z);
                    break;
                case TouchPhase.Ended:
                    if (touch.position.x - startPos.x > 0) return true;
                    break;
            }
        }
        return false;
    }

    bool RightSwipe()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    startCameraPos = rotator.transform.localEulerAngles;
                    break;
                case TouchPhase.Moved:
                    float X = startCameraPos.y + (touch.position.x - startPos.x) * sensivity;
                    rotator.transform.localEulerAngles = new Vector3(rotator.transform.localEulerAngles.x, X, rotator.transform.localEulerAngles.z);
                    break;
                case TouchPhase.Ended:
                    if (touch.position.x - startPos.x < 0) return true;
                    break;
            }
        }
        return false;
    }
}