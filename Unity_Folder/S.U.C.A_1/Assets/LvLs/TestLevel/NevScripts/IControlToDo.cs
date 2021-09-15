using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlToDo // Інтерфейс який описує що можна буде робити в грі
{
    public bool LeftSwipe(GameObject rotator);  // перевірка на те чи вліво напралений свайп

    public bool RightSwipe(GameObject rotator); // перевірка на те чи вправо напралений свайп

    public void Zoom(); // приближення віддалення

    public bool CenIMove(); // запит чи можна рухти обєкт (використовується перед Left Right Move)

    public void Move(GameObject rotator);   // рухає
}
