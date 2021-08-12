using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Verification : MonoBehaviour, IPointerClickHandler
{
    public TextMeshPro skrean;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (skrean.text == "1315")
            StartCoroutine(True());
        else
            StartCoroutine(Eror()); 
    }

    IEnumerator Eror()
    {
        skrean.text = "Fail";

        yield return new WaitForSeconds(1f);

        skrean.text = "";
    }

    IEnumerator True()
    {
        skrean.faceColor = new Color32(40, 202, 37, 225);
        skrean.text = "True";

        yield return new WaitForSeconds(1f);

        skrean.faceColor = new Color32(202, 37, 37, 225);
        skrean.text = "";

        PlayerPrefs.SetInt("LevelComplete", 1);
        SceneManager.LoadScene("MainMany");
    }
}
