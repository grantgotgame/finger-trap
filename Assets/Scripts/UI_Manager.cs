using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public GameObject Pause_Menu;
    public GameObject Play_Menu;
    public GameObject Victory_Menu;
    public Player_Controller Player;
    public TextMeshProUGUI PlayTimer;
    public TextMeshProUGUI EndTimer;
    public bool Done;

    // Start is called before the first frame update
    void Start()
    {
        Done = false;
        Victory_Menu.SetActive(false);
        Play_Menu.SetActive(true);
        Pause_Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayTimer.text = FormatTime(Time.time);

        if(Player.finish == true)
        {
            Victory();
        }

        if(Player.kill == false)
        {
            Kill();
        }
    }

    public void PauseGame()
    {
        Play_Menu.SetActive(false);
        Pause_Menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Play_Menu.SetActive(true);
        Pause_Menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Victory_Menu.SetActive(false);
        Play_Menu.SetActive(true);
        Pause_Menu.SetActive(false);
    }

    public void Victory()
    {
        Victory_Menu.SetActive(true);
        Play_Menu.SetActive(false);
        Pause_Menu.SetActive(false);

        if (!Done)
        {
            EndTimer.text = FormatTime(Time.time);
            Done = true;
        }
    }

    public void LoadLevelSelect()
    {

    }

    public void LoadNextLevel()
    {

    }

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }

    public void Kill()
    {

    }
}
