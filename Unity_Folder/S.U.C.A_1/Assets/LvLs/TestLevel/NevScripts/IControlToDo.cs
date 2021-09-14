using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlToDo
{
    public void Left(GameObject rotator);

    public void Right(GameObject rotator);

    public void ZoomIn();

    public void ZoomOut();

    public bool CenIMove(); // запит чи можна рухти обєкт (використовується для Left Right Move)

    public void Move(); // рухає
}
