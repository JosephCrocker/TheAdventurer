using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour 
{
    [Header("Text / UI Elements")]
    public Text CountUI;
    public Text ZoneNum;
    public Text ZoneCount;
    public Image Checkmark;
    public RawImage Tracker;
    public Transform GameOverUI;
    // Pause Items
    public Transform PauseUI;
    public bool PauseMenuActive;
    // EndGame Items
    public Transform EndGameUI;

    [Header("Variables")]
    public float Countdown;
    public GameObject Player;

    [Header("CompletedSections")]
    public Image Z1Check;
    public Image Z2Check;
    public Image Z3Check;
    public Image Z4Check;
    public bool Section1Done;
    public bool Section2Done;
    public bool Section3Done;
    public bool Section4Done;

	void Start () 
    {
        PauseMenuActive = false;
        GameOverUI.gameObject.SetActive(false);
        Time.timeScale = 1;
        Section1Done = false;
        Section2Done = false;
        Section3Done = false;
        Section4Done = false;
	}
	
	void Update () 
    {
        if (Section1Done == true)
        {
            Z1Check.gameObject.SetActive(true);
        }
        if (Section2Done == true)
        {
            Z2Check.gameObject.SetActive(true);
        }
        if (Section3Done == true)
        {
            Z3Check.gameObject.SetActive(true);
        }
        if (Section4Done == true)
        {
            Z4Check.gameObject.SetActive(true);
        }
        // End Game
        if (Section1Done == true && Section2Done == true && Section3Done == true && Section4Done == true)
        { EndGame();
        }
        // Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        { LoadPauseMenu();
        }
        // Map Keys
        if (Input.GetKeyDown(KeyCode.Space))
        { Tracker.gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        { Tracker.gameObject.SetActive(false);
        }
        // End Game Countdown
        if (Countdown > 0)
        {
            Countdown -= 1 * Time.deltaTime;
            CountUI.text = Countdown.ToString();
        }
        else
        {
            Countdown = 0;
            Player.GetComponent<Movement>()._Speed = 0;
            CountUI.text = Countdown.ToString();
            EndGame();
        }
        // Zone Check
        if (Player.GetComponent<PlayerChecks>().node1_Activated == false && 
            Player.GetComponent<PlayerChecks>().node2_Activated == false &&
            Player.GetComponent<PlayerChecks>().node3_Activated == false &&
            Player.GetComponent<PlayerChecks>().node4_Activated == false)
        {
            ZoneCount.text = "N/A";
            ZoneNum.text = "N/A";
            Checkmark.gameObject.SetActive(false);
        }
        else if (Player.GetComponent<PlayerChecks>().node1_Activated == true)
        {
            ZoneCount.text = Player.GetComponent<PlayerChecks>().Node1Section.ToString();
            ZoneNum.text = "1";
            if (Player.GetComponent<PlayerChecks>().Node1Section == 8)
            {
                Checkmark.gameObject.SetActive(true);
                Section1Done = true;
            }
        }
        else if (Player.GetComponent<PlayerChecks>().node2_Activated == true)
        {
            ZoneCount.text = Player.GetComponent<PlayerChecks>().Node2Section.ToString();
            ZoneNum.text = "2";
            if (Player.GetComponent<PlayerChecks>().Node2Section == 8)
            {
                Checkmark.gameObject.SetActive(true);
                Section2Done = true;
            }
        }
        else if (Player.GetComponent<PlayerChecks>().node3_Activated == true)
        {
            ZoneCount.text = Player.GetComponent<PlayerChecks>().Node3Section.ToString();
            ZoneNum.text = "3";
            if (Player.GetComponent<PlayerChecks>().Node3Section == 8)
            {
                Checkmark.gameObject.SetActive(true);
                Section3Done = true;
            }
        }
        else if (Player.GetComponent<PlayerChecks>().node4_Activated == true)
        {
            ZoneCount.text = Player.GetComponent<PlayerChecks>().Node4Section.ToString();
            ZoneNum.text = "4";
            if (Player.GetComponent<PlayerChecks>().Node4Section == 8)
            {
                Checkmark.gameObject.SetActive(true);
                Section4Done = true;
            }
        }
        // Game Over Confirmed
        if (Player.GetComponent<Movement>()._PlayerKilled == true)
        {
            GameOverUI.gameObject.SetActive(true);
        }
	}

    // Button Functions //
    public void ExitGame()
    { Application.Quit();
    }

    public void LoadMenu()
    { SceneManager.LoadScene("Menu");
    }

    public void Level1()
    { SceneManager.LoadScene("Level1");
    }

    public void Level2()
    { SceneManager.LoadScene("Level2");
    }

    public void Level3()
    { SceneManager.LoadScene("Level3");
    }

    public void LoadPauseMenu()
    {
        if (PauseMenuActive == false)
        {
            Time.timeScale = 0;
            PauseUI.gameObject.SetActive(true);
            PauseMenuActive = true;
        }
        else if (PauseMenuActive == true)
        {
            Time.timeScale = 1;
            PauseUI.gameObject.SetActive(false);
            PauseMenuActive = false;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        EndGameUI.gameObject.SetActive(true);
    }
}