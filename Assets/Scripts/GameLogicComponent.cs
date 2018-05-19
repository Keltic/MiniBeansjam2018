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

    private float points;

    public void Start()
    {
        this.gameOverScreen.SetActive(false);
        this.points = 2000;
        this.textPoints.text = this.points.ToString();
    }

    public void ReportScrapDelivered(float amount)
    {
        this.points += amount;
        this.textPoints.text = this.points.ToString();
    }

    public void ReportRocketCrashed(GameObject rocket)
    {

    }

    private void EndGame()
    {
        this.gameOverScreen.SetActive(true);
    }
}
