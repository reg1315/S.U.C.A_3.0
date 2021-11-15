using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleSkript : MonoBehaviour, IPointerClickHandler
{
    public TextMeshPro outputInterface;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (outputInterface.text == "1315")
            TheEnd();
        else
            Fail();
        GetComponent<Animator>().SetTrigger("Trigger");
    }

    private void TheEnd()
    {
        GetComponent<Animator>().SetBool("TheEnd", true);
    }
    
    private void Fail()
    {
        outputInterface.text = "";
    }
}
