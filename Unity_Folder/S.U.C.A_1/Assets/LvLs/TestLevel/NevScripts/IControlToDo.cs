using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlToDo // ��������� ���� ����� �� ����� ���� ������ � ��
{
    public bool LeftSwipe(GameObject rotator);  // �������� �� �� �� ���� ���������� �����

    public bool RightSwipe(GameObject rotator); // �������� �� �� �� ������ ���������� �����

    public void Zoom(); // ����������� ���������

    public bool CenIMove(); // ����� �� ����� ����� ���� (��������������� ����� Left Right Move)

    public void Move(GameObject rotator);   // ����
}
