using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGuiComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private WindowHowToPlayComponent howToPlay;

    public void Start()
    {
        this.mainMenu.SetActive(true);
        this.howToPlay.Hide();
    }

    public void OnClickButtonStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickButtonHowToPlay()
    {
        this.mainMenu.SetActive(false);
        this.howToPlay.Show();
    }

    public void OnClickButtonQuit()
    {
        Application.Quit();
    }

    public void OnClickButtonHowToPlayBack()
    {
        this.mainMenu.SetActive(true);
        this.howToPlay.Hide();
    }
}
