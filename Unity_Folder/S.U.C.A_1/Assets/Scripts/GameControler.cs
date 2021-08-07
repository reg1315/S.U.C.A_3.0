using UnityEngine;
using System.Collections;
using System;

public class GameControler : MonoBehaviour
{
    Quaternion endPosition;

    public float rotationSpeed;

    public GameObject[] Walls = new GameObject[4];

    private Vector3[] endPositionV3 = new Vector3[4];
    private Vector3[] endPositionV3normalizade = new Vector3[4];

    private Vector3[] downPosition = new Vector3[4];
    private Vector3[] normalPosition = new Vector3[4];

    private Vector2 startPos;
    private Vector3 startCameraPos;
    public float sensivity = 0.1f;

    public float speed;

    public float down;

    public GameObject rotator;

    public void normalizade()
    {
        for (int i = 0; i < Walls.Length; i++)
            endPositionV3[i] = endPositionV3normalizade[i];
    }

    public void Up()
    {
        for (int i = 0; i < Walls.Length; i++)
            endPositionV3normalizade[i] = endPositionV3[i];

        for (int i = 0; i < Walls.Length; i++)
            endPositionV3[i] = normalPosition[i];
    }

    void Start()
    {
        for (int i = 0; i < Walls.Length; i++)
            normalPosition[i] = Walls[i].transform.position;

        for (int i = 0; i < Walls.Length; i++)
        {
            downPosition[i] = normalPosition[i];
            downPosition[i].y +=down;
        }

        endPositionV3[0] = downPosition[0];
        endPositionV3[1] = normalPosition[1];
        endPositionV3[2] = normalPosition[2];
        endPositionV3[3] = downPosition[3];

    }

    void Update()
    {
        ADMove();
    }

    public bool muveaccess = true;
    private void ADMove()
    {
        if (muveaccess)
        {
            if (LeftSwipe())
            {
                if ((rotator.transform.eulerAngles.y >= 345 & rotator.transform.eulerAngles.y <= 360) || (rotator.transform.eulerAngles.y >= 0 & rotator.transform.eulerAngles.y < 75))
                {
                    endPosition = Quaternion.Euler(0, 90, 0);
                    endPositionV3[0] = downPosition[0];
                    endPositionV3[1] = downPosition[1];
                    endPositionV3[2] = normalPosition[2];
                    endPositionV3[3] = normalPosition[3];
                }
                else if (rotator.transform.eulerAngles.y < 165 & rotator.transform.eulerAngles.y >= 75)
                {
                    endPosition = Quaternion.Euler(0, 180, 0);
                    endPositionV3[0] = normalPosition[0];
                    endPositionV3[1] = downPosition[1];
                    endPositionV3[2] = downPosition[2];
                    endPositionV3[3] = normalPosition[3];
                }
                else if (rotator.transform.eulerAngles.y < 255 & rotator.transform.eulerAngles.y >= 165)
                {
                    endPosition = Quaternion.Euler(0, 270, 0);
                    endPositionV3[0]  = normalPosition[0];
                    endPositionV3[1] = normalPosition[1];
                    endPositionV3[2] = downPosition[2];
                    endPositionV3[3] = downPosition[3];
                }
                else
                {
                    endPosition = Quaternion.Euler(0, 360, 0);
                    endPositionV3[0] = downPosition[0];
                    endPositionV3[1] = normalPosition[1];
                    endPositionV3[2] = normalPosition[2];
                    endPositionV3[3] = downPosition[3];
                }
            }

            if (RightSwipe())
            {
                if (rotator.transform.eulerAngles.y <= 105 & rotator.transform.eulerAngles.y > 15)
                {
                    endPosition = Quaternion.Euler(0, 0, 0);
                    endPositionV3[0] = downPosition[0];
                    endPositionV3[1] = normalPosition[1];
                    endPositionV3[2] = normalPosition[2];
                    endPositionV3[3] = downPosition[3];
                }
                else if (rotator.transform.eulerAngles.y <= 195 & rotator.transform.eulerAngles.y > 95)
                {
                    endPosition = Quaternion.Euler(0, 90, 0);
                    endPositionV3[0] = downPosition[0];
                    endPositionV3[1] = downPosition[1];
                    endPositionV3[2] = normalPosition[2];
                    endPositionV3[3] = normalPosition[3];
                }
                else if (rotator.transform.eulerAngles.y <= 285 & rotator.transform.eulerAngles.y > 195)
                {
                    endPosition = Quaternion.Euler(0, 180, 0);
                    endPositionV3[0] = normalPosition[0];
                    endPositionV3[1] = downPosition[1];
                    endPositionV3[2] = downPosition[2];
                    endPositionV3[3] = normalPosition[3];
                }
                else
                {
                    endPosition = Quaternion.Euler(0, 270, 0);
                    endPositionV3[0] = normalPosition[0];
                    endPositionV3[1] = normalPosition[1];
                    endPositionV3[2] = downPosition[2];
                    endPositionV3[3] = downPosition[3];
                }
            }

            if (rotator.transform.rotation != endPosition)
            {
                rotator.transform.rotation = Quaternion.Slerp(rotator.transform.rotation, endPosition, Time.deltaTime * rotationSpeed);
            }
        }
        

        if (Walls[0].transform.position != endPositionV3[0])
        {
            Walls[0].transform.position = Vector3.Lerp(Walls[0].transform.position, endPositionV3[0], speed * Time.deltaTime);
        }
        if (Walls[1].transform.position != endPositionV3[1])
        {
            Walls[1].transform.position = Vector3.Lerp(Walls[1].transform.position, endPositionV3[1], speed * Time.deltaTime);
        }
        if (Walls[2].transform.position != endPositionV3[2])
        {
            Walls[2].transform.position = Vector3.Lerp(Walls[2].transform.position, endPositionV3[2], speed * Time.deltaTime);
        }
        if (Walls[3].transform.position != endPositionV3[3])
        {
            Walls[3].transform.position = Vector3.Lerp(Walls[3].transform.position, endPositionV3[3], speed * Time.deltaTime);
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