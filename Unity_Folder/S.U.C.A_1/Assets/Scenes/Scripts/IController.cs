using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public bool Left();
    public bool Right();
    public Vector2 Move();
    public bool tap();
    public bool Back();
}
