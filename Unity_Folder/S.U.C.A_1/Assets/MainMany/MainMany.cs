using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMany : MonoBehaviour
{
    public Button[] LvLB;
    int LevelComplite;

    // Start is called before the first frame update
    void Start()
    {
        LevelComplite = PlayerPrefs.GetInt("LevelComplete");
        for(int i=1;i<LvLB.Length;i++)
            LvLB[i].interactable = false;

        for(int i = LevelComplite; i >= 0; i--)
                    LvLB[i].interactable = true;
    }

    public void LoadTo(int LvL)
    {
        SceneManager.LoadScene(LvL);
    }

    public void Reset()
    {
        for (int i = 1; i < LvLB.Length; i++)
            LvLB[i].interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
