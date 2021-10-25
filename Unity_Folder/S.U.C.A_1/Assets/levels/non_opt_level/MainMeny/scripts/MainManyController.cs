using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManyController : MonoBehaviour
{
    private GameObject MainCamera;
    private GameObject CenterOfCameraRotate;
    public void Start()
    {
        CheckLvlState();
        AddLevelsByScene();
        MainCamera = GameObject.FindWithTag("MainCamera");
        CenterOfCameraRotate = GameObject.Find(nameof(CenterOfCameraRotate));
    }

    private int passedLevels;
    private void CheckLvlState()
    {
        if (PlayerPrefs.HasKey(nameof(passedLevels)))
            passedLevels = PlayerPrefs.GetInt(nameof(passedLevels));
        else {
            passedLevels = 0;
            PlayerPrefs.SetInt(nameof(passedLevels), passedLevels);
        }
    }
    private GameObject levelOnBackFons;
    public GameObject[] allLevels;
    private void AddLevelsByScene()
    {
        levelOnBackFons = allLevels[passedLevels];
        levelOnBackFons.tag = "Level";
        Instantiate(levelOnBackFons);
    }

    private enum MenuLier
    {
        MainMenu,
        Levels,
        Setings
    }
    private MenuLier lier = MenuLier.MainMenu;

    private void Update()
    {
        if (continueb)
            Continue();

        switch (lier)
        {
            case MenuLier.MainMenu:
                Bac();
                break;
            case MenuLier.Levels:
                Levels();
                break;
            case MenuLier.Setings:
                break;
        }
    }

    private bool continueb = false;
    public void Continue()
    {
        if (!continueb)
            continueb = true;

        DisappearanceMany();
        GoToStartPosition();
        StartCoroutine(GoToSaveLvl());
    }

    private Vector3 endCameraPosition = new Vector3(3.6f, 3.6f, 3.6f);
    private Vector3 endCameraRotation = new Vector3(30, 225, 0);
    private Vector3 endCameraRotatorRotation;
    private void GoToStartPosition()
    {
        var speed = 7f;
        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, endCameraPosition, speed * Time.deltaTime);
        MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, Quaternion.Euler(endCameraRotation), speed * Time.deltaTime);

        if (CenterOfCameraRotate.transform.rotation.eulerAngles.y > 1 & CenterOfCameraRotate.transform.rotation.eulerAngles.y <= 91)
            endCameraRotatorRotation = new Vector3(0, 90, 0);
        else if (CenterOfCameraRotate.transform.rotation.eulerAngles.y <= 181 & CenterOfCameraRotate.transform.rotation.eulerAngles.y > 91)
            endCameraRotatorRotation = new Vector3(0, 180, 0);
        else if (CenterOfCameraRotate.transform.rotation.eulerAngles.y <= 271 & CenterOfCameraRotate.transform.rotation.eulerAngles.y > 181)
            endCameraRotatorRotation = new Vector3(0, 270, 0);
        else if (CenterOfCameraRotate.transform.rotation.eulerAngles.y > 271 & CenterOfCameraRotate.transform.rotation.eulerAngles.y <= 361)
            endCameraRotatorRotation = new Vector3(0, 360, 0);

        CenterOfCameraRotate.transform.rotation = Quaternion.Lerp(CenterOfCameraRotate.transform.rotation, Quaternion.Euler(endCameraRotatorRotation), speed * Time.deltaTime);
    }

    public float waitTime;
    private IEnumerator GoToSaveLvl()
    {
        yield return new WaitForSeconds(waitTime);
        PlayerPrefs.SetFloat("StartRotation", (int)CenterOfCameraRotate.transform.rotation.eulerAngles.y);
        SceneManager.LoadScene(passedLevels + 1, LoadSceneMode.Single);
    }

    public void Levels()
    {
        if (lier != MenuLier.Levels)
            lier = MenuLier.Levels;
        DisappearanceMany();
    }

    public void Setings()
    {
        if (lier != MenuLier.Setings)
            lier = MenuLier.Setings;
        AppearanceMany();
    }

    public void Bac()
    {
        if (lier != MenuLier.MainMenu)
            lier = MenuLier.MainMenu;
        AppearanceMany();
    }

    [Header("DisappearanceMany")]
    public Image disappearanceManyColor;
    public float disappearanceSpead;
    private void DisappearanceMany()
    {
        Debug.Log(disappearanceManyColor.color.a);
        if (disappearanceManyColor.color.a > 0)
            disappearanceManyColor.color = new Color(disappearanceManyColor.color.r, disappearanceManyColor.color.g, disappearanceManyColor.color.b, (disappearanceManyColor.color.a*255 - disappearanceSpead)/255);
        else
            disappearanceManyColor.color = new Color(disappearanceManyColor.color.r, disappearanceManyColor.color.g, disappearanceManyColor.color.b,0);
        Debug.Log(disappearanceManyColor.color.a);
    }   //  плавне зникнення головного меню

    private void AppearanceMany()
    {

    }   //  плавна поява головного меню
}
