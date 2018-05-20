using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogicComponent : MonoBehaviour
{
    [SerializeField]
    private int numberOfSpawnAtCrash = 5;
    [SerializeField]
    private Text textPoints;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private Text textTime;
    [SerializeField]
    private Text textMass;
    [SerializeField]
    private AudioSource gameoverSound;

    private float timer;
    private float points;
    private float overallMass;
    private Dictionary<int, int> collectedItems;
    private int crashedRockets;
    private TrashSpawner trashSpawner;

    public void Start()
    {
        this.trashSpawner = GameObject.Find("TrashContainer").GetComponent<TrashSpawner>();
        Time.timeScale = 1;
        this.timer = 0;
        this.gameOverScreen.SetActive(false);
        this.points = 2000;
        this.textPoints.text = this.points.ToString();
        this.collectedItems = new Dictionary<int, int>();
        this.crashedRockets = 0;
        this.overallMass = 0;
    }

    public void Update()
    {
        this.timer += Time.deltaTime;
    }

    public void ReportScrapDelivered(float amount)
    {
        this.points += amount;
        this.textPoints.text = this.points.ToString();

        int intAmount = (int)amount;
        if (!this.collectedItems.ContainsKey(intAmount))
        {
            this.collectedItems.Add(intAmount, 0);
        }

        this.collectedItems[intAmount]++;
        overallMass += amount;
    }

    public void ReportRocketCrashed(GameObject rocket)
    {
        this.trashSpawner.SpawnRandomTrashAtLocation(rocket.transform.position, this.numberOfSpawnAtCrash);

        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            this.points -= rb.mass;
        }

        this.textPoints.text = this.points.ToString();

        this.crashedRockets++;

        if(this.points <= 0)
        {
            this.EndGame();
        }
    }

    public void OnClickEndGameButton()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        if (gameoverSound)
        {
            gameoverSound.Play();
        }

        Time.timeScale = 0;
        this.gameOverScreen.SetActive(true);

        System.TimeSpan span = System.TimeSpan.FromSeconds(this.timer);
        string text = string.Format("{0}:{1}:{2}", span.Hours.ToString("D2"), span.Minutes.ToString("D2"), span.Seconds.ToString("D2"));
        this.textTime.text = text;
        string massText = string.Format("{0} tons of trash", overallMass);
        this.textMass.text = massText;
    }
}
