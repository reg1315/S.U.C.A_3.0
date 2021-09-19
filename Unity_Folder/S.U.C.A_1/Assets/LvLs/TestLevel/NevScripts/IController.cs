using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public bool Left();
    public bool Right();
    public Vector2 Move(Vector2 target);
    public bool tap();
    public bool Back();
}
