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
    [SerializeField]
    private GameObject gameoverTrashCollectorPlane;
    [SerializeField]
    private GameObject player;

    private float timer;
    private float points;
    private float overallMass;
    private float tickedMass;
    private Dictionary<int, int> collectedItems;
    private int crashedRockets;
    private TrashSpawner trashSpawner;
    private GameObject trashContainer;
    private GameObject trashAttachContainer;

    public void Start()
    {
        this.trashSpawner = GameObject.Find("TrashContainer").GetComponent<TrashSpawner>();
        this.trashAttachContainer = GameObject.FindGameObjectWithTag("TrashAttachmentContainer");
        this.trashContainer = GameObject.FindGameObjectWithTag("TrashContainer");
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

    private void ProcessEndGameTrash(GameObject trash)
    {
        trash.gameObject.layer = 17;
        Rigidbody2D body = trash.GetComponent<Rigidbody2D>();
        body.gravityScale = 2.0f;

        tickedMass += body.mass;
        string massText = string.Format("{0} tons of trash", tickedMass);
        this.textMass.text = massText;


        int childCount = trash.gameObject.transform.childCount;
        for ( int i = 0; i <  childCount; ++i)
        {
            GameObject child = trash.gameObject.transform.GetChild(i).gameObject;
            if (child.layer == 9)
                child.layer = 17;
        }

        trash.transform.localScale = new Vector3( Random.Range(1f, 2.5f), Random.Range(1f, 2.5f), 1);
    }

    private IEnumerator GameOverSpawner()
    {
        Vector2 spawnPos = player.transform.position + new Vector3(0, 10, 0);

        System.Action<GameObject> processAction = ProcessEndGameTrash;
        Dictionary<int, int> collectedItemsCopy = new Dictionary<int, int>();
        foreach (KeyValuePair<int, int> trash in collectedItems)
        {
            // more == better
            collectedItemsCopy.Add(trash.Key, trash.Value * 5);
        }
        
        foreach (KeyValuePair<int, int> trash in collectedItemsCopy)
        {
            int spawned = 0;
            while (spawned < trash.Value)
            {
                int left = trash.Value - spawned;
                int spawnNow = Mathf.Min(left, Random.Range(0, (left /2)+ 1 )) ;
                this.trashSpawner.SpawnRandomTrashWithMassFilterAtLocation(spawnPos, trash.Key, spawnNow, processAction);
                spawned += spawnNow;
                
                
                yield return new WaitForSeconds(0.25f);
            }
        }
    }


    public void EndGame() 
    {
        if (gameoverSound)
        {
            gameoverSound.Play();
        }
        this.gameOverScreen.SetActive(true);

        System.TimeSpan span = System.TimeSpan.FromSeconds(this.timer);
        string text = string.Format("{0}:{1}:{2}", span.Hours.ToString("D2"), span.Minutes.ToString("D2"), span.Seconds.ToString("D2"));
        this.textTime.text = text;
        string massText = string.Format("{0} tons of trash", overallMass);
        this.textMass.text = massText;

        // Stop all game logic.
        player.SetActive(false);
        trashAttachContainer.SetActive(false);
        trashSpawner.SpawnTimer = float.PositiveInfinity;
        GetComponent<RocketController>().spawnTimer = float.PositiveInfinity;

        gameoverTrashCollectorPlane.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 10f, this.transform.position.z);
        StartCoroutine(this.GameOverSpawner());
    }
}
