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
    public bool ASectionLoaded;

	void Start () 
    {
        Time.timeScale = 1;
        ASectionLoaded = false;
    }

	void Update () {}

    public void LoadLevel()
    {   SceneManager.LoadScene("Level1");
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
            AssetSection.gameObject.SetActive(true);
            ASectionLoaded = true;
        }
        else if (ASectionLoaded == true)
        {
            AssetSection.gameObject.SetActive(false);
            ASectionLoaded = false;
        }
    }
}