using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    public Vector3[] endPositionV3 = new Vector3[4];

    public Vector3[] downPosition = new Vector3[4];
    public Vector3[] upPosition = new Vector3[4];

    [Space]
    public GameObject[] Walls = new GameObject[4];
    [Space]
    [SerializeField] private float down = -2;

    private void Start()
    {
        for (int i = 0; i < Walls.Length; i++)
            upPosition[i] = Walls[i].transform.position;

        for (int i = 0; i < Walls.Length; i++)
        {
            downPosition[i] = upPosition[i];
            downPosition[i].y += down;
        }

        endPositionV3[0] = downPosition[0];
        endPositionV3[1] = upPosition[1];
        endPositionV3[2] = upPosition[2];
        endPositionV3[3] = downPosition[3];
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
}
