using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadSceneAsync("MainMany", LoadSceneMode.Single);
    }
}
