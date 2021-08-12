using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SafeDor : MonoBehaviour, IPointerClickHandler
{
    public char simbol;
    public TextMeshPro skrean;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(skrean.text.Length<4)
            skrean.text += simbol;
    }
}
