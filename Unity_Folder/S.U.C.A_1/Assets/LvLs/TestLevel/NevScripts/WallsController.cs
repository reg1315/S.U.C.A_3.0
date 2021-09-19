using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    public Vector3[] endPositionV3 = new Vector3[4];

    public Vector3[] downPosition = new Vector3[4];
    public Vector3[] normalPosition = new Vector3[4];

    [Space]
    public GameObject[] Walls = new GameObject[4];
    [Space]
    [SerializeField] private float down = -2;

    private void Start()
    {
        for (int i = 0; i < Walls.Length; i++)
            normalPosition[i] = Walls[i].transform.position;

        for (int i = 0; i < Walls.Length; i++)
        {
            downPosition[i] = normalPosition[i];
            downPosition[i].y += down;
        }

        endPositionV3[0] = downPosition[0];
        endPositionV3[1] = normalPosition[1];
        endPositionV3[2] = normalPosition[2];
        endPositionV3[3] = downPosition[3];
    }

    public void WallsNormalizade(float speed)
    {
        for (int i = 0; i < Walls.Length; i++)
            if (Walls[i].transform.position != endPositionV3[i])
                Walls[i].transform.position = Vector3.Lerp(Walls[i].transform.position, endPositionV3[i], speed * Time.deltaTime);
    }
}
