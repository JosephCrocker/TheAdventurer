using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{
    public Transform Buttons;
    public Transform NamePlark;
    public Transform HelpSection;
    public Transform AssetSection;
    public Transform LevelSection;
    public bool ASectionLoaded;
    public bool LevelLoaded;

	void Start () 
    {
        Time.timeScale = 1;
        ASectionLoaded = false;
        LevelLoaded = false;
    }

	void Update () {}

    public void LoadLevel()
    {   SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ExitGame()
    {   Application.Quit();
    }

    public void LoadHelp()
    {
        if (ASectionLoaded == true)
        {
            AssetSection.gameObject.SetActive(false);
            ASectionLoaded = false;
        }
        if (LevelLoaded == true)
        {
            LevelSection.gameObject.SetActive(false);
            LevelLoaded = false;
        }
        Buttons.gameObject.SetActive(false);
        NamePlark.gameObject.SetActive(false);
        HelpSection.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        HelpSection.gameObject.SetActive(false);
        Buttons.gameObject.SetActive(true);
        NamePlark.gameObject.SetActive(true);
    }

    public void LoadAssets()
    {
        if (ASectionLoaded == false)
        {
            if (LevelLoaded == true)
            {
                LevelSection.gameObject.SetActive(false);
                LevelLoaded = false;
            }
            AssetSection.gameObject.SetActive(true);
            ASectionLoaded = true;
        }
        else if (ASectionLoaded == true)
        {
            AssetSection.gameObject.SetActive(false);
            ASectionLoaded = false;
        }
    }

    public void Loadlevels()
    {
        if (LevelLoaded == false)
        {
            if (ASectionLoaded == true)
            {
                AssetSection.gameObject.SetActive(false);
                ASectionLoaded = false;
            }
            LevelSection.gameObject.SetActive(true);
            LevelLoaded = true;
        }
        else if (LevelLoaded == true)
        {
            LevelSection.gameObject.SetActive(false);
            LevelLoaded = false;
        }
    }
}