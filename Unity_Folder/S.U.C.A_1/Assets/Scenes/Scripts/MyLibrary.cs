using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLibrary
{
    public enum CameraControllerLyer   //  описує шари в якому можна виконувати лише певні методи контролю камери
    {
        Lier0,
        LierMoveTo,
        LierRotateAround,
        LierMoveInSpace,
        LierBack
    }

    public class Comparison: MonoBehaviour
    {
        public bool CheckRange(float value, float CenterOfRange, float Range)
        {
            Range = Mathf.Abs(Range);
            if (value < CenterOfRange + Range && value > CenterOfRange - Range)
                return true;
            else
                return false;
        }

        public bool CheckRange(Vector3 value, Vector3 CenterOfRange, Vector3 Range)
        {
            float x, y, z;
            x = Mathf.Abs(Range.x);
            y = Mathf.Abs(Range.y);
            z = Mathf.Abs(Range.z);

            if (value.x < CenterOfRange.x + x && value.x > CenterOfRange.x - x &&
                value.y < CenterOfRange.y + x && value.y > CenterOfRange.y - y &&
                value.z < CenterOfRange.z + z && value.z > CenterOfRange.z - z)
                return true;
            else
                return false;
        }

        public bool CheckRange(Vector3 value, Vector3 CenterOfRange)
        {
            float x, y, z;
            x = 0.1f;
            y = 0.1f;
            z = 0.1f;

            if (value.x < CenterOfRange.x + x && value.x > CenterOfRange.x - x &&
                value.y < CenterOfRange.y + x && value.y > CenterOfRange.y - y &&
                value.z < CenterOfRange.z + z && value.z > CenterOfRange.z - z)
                return true;
            else
                return false;
        }

        public bool CheckRange(Quaternion value,Vector3 CenterOfRange,Vector3 Range)
        {
            float x, y, z;
            x = Mathf.Abs(Range.x);
            y = Mathf.Abs(Range.y);
            z = Mathf.Abs(Range.z);

            if (value.eulerAngles.x < CenterOfRange.x + x && value.eulerAngles.x > CenterOfRange.x - x &&
                value.eulerAngles.y < CenterOfRange.y + x && value.eulerAngles.y > CenterOfRange.y - y &&
                value.eulerAngles.z < CenterOfRange.z + z && value.eulerAngles.z > CenterOfRange.z - z)
                return true;
            else
                return false;
        }

        public bool CheckRange(Quaternion value, Vector3 CenterOfRange)
        {
            float x, y, z;
            x = 0.1f;
            y = 0.1f;
            z = 0.1f;

            if (value.eulerAngles.x < CenterOfRange.x + x && value.eulerAngles.x > CenterOfRange.x - x &&
                value.eulerAngles.y < CenterOfRange.y + x && value.eulerAngles.y > CenterOfRange.y - y &&
                value.eulerAngles.z < CenterOfRange.z + z && value.eulerAngles.z > CenterOfRange.z - z)
                return true;
            else
                return false;
        }
    }
    
}