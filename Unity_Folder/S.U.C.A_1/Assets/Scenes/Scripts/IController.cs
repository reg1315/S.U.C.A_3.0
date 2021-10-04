using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public bool Left();
    public bool Right();
    public Vector2 Move(float speed);
    public bool tap();
    public bool Back();
}
