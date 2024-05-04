using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuContoller : MonoBehaviour
{
    [SerializeField] private GameObject SettingScene;

    private void Awake()
    {
        SettingScene.SetActive(false);
    }

    public void Settings()
    {
        SettingScene.SetActive(true);
    }
    public void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        SettingScene.SetActive(false);
    }
    
}
