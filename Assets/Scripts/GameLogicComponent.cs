using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicComponent : MonoBehaviour
{
    [SerializeField]
    private Text textPoints;
    [SerializeField]
    private GameObject gameOverScreen;

    public void Start()
    {
        this.gameOverScreen.SetActive(false);
    }

    public void ReportScrapDelivered(int amount)
    {

    }

    private void EndGame()
    {
        this.gameOverScreen.SetActive(true);
    }
}
