using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMany : MonoBehaviour
{
    public Button[] LvLB;
    int LevelComplite;

    public GameObject[] LvLGO;

    // Start is called before the first frame update
    void Start()
    {
        LevelComplite = PlayerPrefs.GetInt("LevelComplete");
        for(int i=1;i<LvLB.Length;i++)
            LvLB[i].interactable = false;

        for(int i = LevelComplite; i >= 0; i--)
                    LvLB[i].interactable = true;

        LoadSceneToBacFoont();
    }

    private void LoadSceneToBacFoont()
    {
        Instantiate(LvLGO[LevelComplite]);
    }
    public void LoadTo(int LvL)
    {
        SceneManager.LoadSceneAsync(LvL, LoadSceneMode.Single);
    }

    public void Resets()
    {
        for (int i = 1; i < LvLB.Length; i++)
            LvLB[i].interactable = false;

        Destroy(GameObject.Find(LvLGO[LevelComplite].name + "(Clone)"));
        PlayerPrefs.DeleteAll();

        LevelComplite = PlayerPrefs.GetInt("LevelComplete");
        LoadSceneToBacFoont();
    }

    public void ContinueButton()
    {
        SceneManager.LoadSceneAsync(LevelComplite + 1, LoadSceneMode.Single);
    }

    public void SetingsButton()
    {

    }

    public GameObject MainCanvas, LevelCanvaas;

    public void LevelsButton()
    {
        LevelCanvaas.SetActive(true);
        MainCanvas.SetActive(false);
    }

    public void BackButton()
    {
        MainCanvas.SetActive(true);
        LevelCanvaas.SetActive(false);   
    }
}
