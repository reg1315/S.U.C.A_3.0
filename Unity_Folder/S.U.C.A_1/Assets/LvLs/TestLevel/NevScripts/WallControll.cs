using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControll : AllScale
{
    public GameObject[] Walls = new GameObject[4];
    public Vector3[] WallsEndPos = new Vector3[4];

    private void Start()
    {
        WallsEndPos
    }

    public void WallsNormalizade(float scale)
    {
        for(int i = 0; i < Walls.Length; i++)
            if(Walls[i].transform.position != WallsEndPos[i])
                Walls[i].transform.position = Vector3.Lerp(Walls[i].transform.position, WallsEndPos[i], scale*WallMoowingSpeedScale * Time.deltaTime);
    }
}
