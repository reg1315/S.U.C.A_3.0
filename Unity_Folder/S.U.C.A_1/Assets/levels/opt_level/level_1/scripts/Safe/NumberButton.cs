using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteAlways]
public class NumberButton : MonoBehaviour, IPointerClickHandler
{
    public TextMeshPro outputInterface;
    public char simbol;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (outputInterface.text.Length >= 4)
            outputInterface.text = "";
        else
            outputInterface.text += simbol;
    }
}
