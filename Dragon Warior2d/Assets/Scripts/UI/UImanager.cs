using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private AudioClip GameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject PauseScreen;

    [Header("Settings")]
    [SerializeField] private GameObject SettingsScreen;

  



    private void Awake()
    {
        GameOverScreen.SetActive(false);
        PauseScreen.SetActive(false);
        SettingsScreen.SetActive(false);


    }

    #region Level1;
    #region General
    public void Gameover()
    {
        Time.timeScale = 0;
        SoundManager.instance.Audio(GameOverSound);
        GameOverScreen.SetActive(true);
    }
   
    public void QuitButton()
    {
        Application.Quit();

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
   
    
    public void PauseButton()
    {
        if (PauseScreen.activeInHierarchy)
        {
            Pause(false);
        }
        else
        {
            Pause(true);
        }
    }
    public void Pause(bool Status)
    {
        PauseScreen.SetActive(Status);

        if (Status)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }
    public void Settings()
    {
        PauseScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }


    public void Back()
    {
        SettingsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    #endregion
#region Variables
    public void level1()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
   

    public void RestartButtonLevel1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");

    }
    #endregion
    #endregion
    #region Level2;
    public void level2()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
    }


    public void RestartButtonLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2");

    }
    #endregion
}
