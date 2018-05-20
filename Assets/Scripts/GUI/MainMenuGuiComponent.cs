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
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private ShipSelector shipSelector;

    [SerializeField]
    private AudioSource audiocSourceBgm;

    public void Start()
    {
        this.audiocSourceBgm.Play();
        this.mainMenu.SetActive(true);
        this.howToPlay.Hide();
        this.credits.SetActive(false);
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

    public void OnClickButtonCredits()
    {
        this.mainMenu.SetActive(false);
        this.credits.SetActive(true);
    }

    public void OnClickButtonShipSelector()
    {
        this.mainMenu.SetActive(false);
        this.shipSelector.Show();
    }

    public void OnClickButtonQuit()
    {
        Application.Quit();
    }

    public void OnClickButtonBackToMainMenu()
    {
        this.mainMenu.SetActive(true);
        this.howToPlay.Hide();
        this.credits.SetActive(false);
        this.shipSelector.Hide();
    }
}
