using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    public Vector3[] endPositionV3 = new Vector3[4];

    public Vector3[] downPosition = new Vector3[4];
    public Vector3[] upPosition = new Vector3[4];

    [Space]
    [SerializeField] private GameObject CenterOfCameraRotate;

    [Space]
    public GameObject[] Walls = new GameObject[4];
    [Space]
    [SerializeField] private float down = -2;

    void Start()
    {
        CenterOfCameraRotate = GameObject.Find(nameof(CenterOfCameraRotate));

        for (int i = 0; i < Walls.Length; i++)
            upPosition[i] = Walls[i].transform.position;

        for (int i = 0; i < Walls.Length; i++)
        {
            downPosition[i] = upPosition[i];
            downPosition[i].y += down;
        }

        var obj = CenterOfCameraRotate.transform;
        if (obj.eulerAngles.y <= 95 & obj.eulerAngles.y >= 85)
        {
            endPositionV3[0] = downPosition[0];
            endPositionV3[1] = downPosition[1];
            endPositionV3[2] = upPosition[2];
            endPositionV3[3] = upPosition[3];
        }
        else if (obj.eulerAngles.y <= 185 & obj.eulerAngles.y >= 175)
        {
            endPositionV3[0] = upPosition[0];
            endPositionV3[1] = downPosition[1];
            endPositionV3[2] = downPosition[2];
            endPositionV3[3] = upPosition[3];
        }
        else if (obj.eulerAngles.y <= 275 & obj.eulerAngles.y >= 265)
        {
            endPositionV3[0] = upPosition[0];
            endPositionV3[1] = upPosition[1];
            endPositionV3[2] = downPosition[2];
            endPositionV3[3] = downPosition[3];
        }
        else
        {
            endPositionV3[0] = downPosition[0];
            endPositionV3[1] = upPosition[1];
            endPositionV3[2] = upPosition[2];
            endPositionV3[3] = downPosition[3];
        }
    }

    public void WallsNormalizade(float speed)
    {
        for (int i = 0; i < Walls.Length; i++)
            if (Walls[i].transform.position != endPositionV3[i])
                Walls[i].transform.position = Vector3.Lerp(Walls[i].transform.position, endPositionV3[i], speed * Time.deltaTime);
    }
    public void WallsNormalizade()
    {
        for (int i = 0; i < Walls.Length; i++)
            if (Walls[i].transform.position != endPositionV3[i])
                Walls[i].transform.position = endPositionV3[i];
    }

    public IEnumerator WallsUp()
    {
        yield return new WaitForSeconds(0.1f);

        if (GameObject.Find("CenterOfCameraRotate").GetComponent<CameraController>().gmObjToMove == null)
            for (int i = 0; i < Walls.Length; i++)
                Walls[i].transform.position = upPosition[i];
    }

    public void WallsBack()
    {
        for(int i = 0; i < Walls.Length; i++)
            Walls[i].transform.position = endPositionV3[i];
    }

    public void StartWalsPosition(Transform obj)
    {
        if (obj.eulerAngles.y <= 95 & obj.eulerAngles.y >= 85)
        {
            endPositionV3[0] = downPosition[0];
            endPositionV3[1] = downPosition[1];
            endPositionV3[2] = upPosition[2];
            endPositionV3[3] = upPosition[3];
        }
        else if (obj.eulerAngles.y <= 185 & obj.eulerAngles.y >= 175)
        {
            endPositionV3[0] = upPosition[0];
            endPositionV3[1] = downPosition[1];
            endPositionV3[2] = downPosition[2];
            endPositionV3[3] = upPosition[3];
        }
        else if (obj.eulerAngles.y <= 275 & obj.eulerAngles.y >= 265)
        {
            endPositionV3[0] = upPosition[0];
            endPositionV3[1] = upPosition[1];
            endPositionV3[2] = downPosition[2];
            endPositionV3[3] = downPosition[3];
        }
        else if(obj.eulerAngles.y <= 5 & obj.eulerAngles.y >= 355)
        {
            endPositionV3[0] = downPosition[0];
            endPositionV3[1] = upPosition[1];
            endPositionV3[2] = upPosition[2];
            endPositionV3[3] = downPosition[3];
        }
    }
}
