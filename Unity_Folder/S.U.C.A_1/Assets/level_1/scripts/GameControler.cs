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
        if (Input.GetKeyDown(KeyCode.A))
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

        if (Input.GetKeyDown(KeyCode.D))
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
}