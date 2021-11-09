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
        levelOnBackFons.GetComponentInChildren<WallsController>().WallsNormalizade();
        Instantiate(levelOnBackFons);
    }

    private enum MenuLier
    {
        Continue,
        MainMenu,
        Levels,
        Setings,
        Back
    }
    private MenuLier lier = MenuLier.MainMenu;
    private MenuLier nextLier = MenuLier.MainMenu;

    private void Update()
    {
        if(lier != nextLier)
            switch (nextLier)
            {
                case MenuLier.Continue:
                    Continue();
                    break;
                case MenuLier.Levels:
                    Levels();
                    break;
                case MenuLier.Setings:
                    break;
                case MenuLier.MainMenu:
                    Bac();
                    break;
            }
    }


    public void Continue()
    {
        if (nextLier != MenuLier.Continue)
            nextLier = MenuLier.Continue;

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
        if (nextLier != MenuLier.Levels)
            nextLier = MenuLier.Levels;
        DisappearanceMany();
    }

    public void Setings()
    {
        if (nextLier != MenuLier.Setings)
            nextLier = MenuLier.Setings;
        AppearanceMany();
    }

    public void Bac()
    {
        if (nextLier != MenuLier.MainMenu)
        {
            nextLier = MenuLier.MainMenu;
            lier = MenuLier.Back;
        }
            
        AppearanceMany();
    }

    [Header("Disappearance and AppearanceMany Many")]
    public GameObject disappearanceMany;
    public float disappearanceSpead;
    private void DisappearanceMany()
    {
        if (disappearanceMany.GetComponent<Image>().color.a*255 > 0)
            disappearanceMany.GetComponent<Image>().color = new Color(disappearanceMany.GetComponent<Image>().color.r, disappearanceMany.GetComponent<Image>().color.g, disappearanceMany.GetComponent<Image>().color.b, (disappearanceMany.GetComponent<Image>().color.a*255 - disappearanceSpead)/255);
        else if (nextLier != lier)
        {
            disappearanceMany.GetComponent<Image>().color = new Color(disappearanceMany.GetComponent<Image>().color.r, disappearanceMany.GetComponent<Image>().color.g, disappearanceMany.GetComponent<Image>().color.b, 0);
            if (nextLier != MenuLier.Continue)
                lier = nextLier;
            disappearanceMany.SetActive(false);
        }
    }   //  плавне зникнення головного меню

    private void AppearanceMany()
    {
        if (disappearanceMany.GetComponent<Image>().color.a * 255 < 255)
            disappearanceMany.GetComponent<Image>().color = new Color(disappearanceMany.GetComponent<Image>().color.r, disappearanceMany.GetComponent<Image>().color.g, disappearanceMany.GetComponent<Image>().color.b, (disappearanceMany.GetComponent<Image>().color.a * 255 + disappearanceSpead) / 255);
        else if (nextLier != lier)
        {
            disappearanceMany.GetComponent<Image>().color = new Color(disappearanceMany.GetComponent<Image>().color.r, disappearanceMany.GetComponent<Image>().color.g, disappearanceMany.GetComponent<Image>().color.b, 1);
            lier = nextLier;

        }
    }   //  плавна поява головного меню
}
