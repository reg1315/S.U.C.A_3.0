using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bizue
{
    public static Vector3 GetPoint(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float t)
    {
        Vector3 p12 = Vector3.Lerp(p1, p2, t);
        Vector3 p23 = Vector3.Lerp(p2, p3, t);
        Vector3 p34 = Vector3.Lerp(p3, p4, t);

        Vector3 p123 = Vector3.Lerp(p12, p23, t);
        Vector3 p234 = Vector3.Lerp(p23, p34, t);

        Vector3 p1234 = Vector3.Lerp(p123, p234, t);

        return p1234;
    }

    public static Vector3 GetLoocPoint(Vector3 p1, Vector3 p2, float t)
    {
        Vector3 p12 = Vector3.Lerp(p1, p2, t);

        return p12;
    }
}
