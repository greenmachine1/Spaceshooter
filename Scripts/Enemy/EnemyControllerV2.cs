using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerV2 : MonoBehaviour
{

    public GameObject player;

    // countdown text stuff //
    public GameObject countDownTextPrefab;
    private GameObject countDownPrefab;
    private Text countDownText;


    public int level = 0;
    public int difficulty = 0;
    public float zPosition = 0.0f;
    public int numberOfWaves = 0;
    int heightOfPlayingField = 20;


    public GameObject[] arrayOfEnemyGroupPrefabs;
    private List<GameObject> randomListOfEnemyPrefabs = new List<GameObject>();


    float countDownStartTime = 6.0f;
    float goDisplayTime = 2.0f;
    bool start = false;
    bool startEnemySpawningBoolean = false;
    bool enemySpawnHasStarted = false;

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 11, this.gameObject.transform.position.z);
        GenerateRandomEnemyOrder();
        countDownPrefab = Instantiate(countDownTextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        countDownText = countDownPrefab.GetComponentInChildren<Text>();
    }

    // randomizing the order in which the groups get sent out //
    void GenerateRandomEnemyOrder()
    {
        Debug.Log(arrayOfEnemyGroupPrefabs.Length);
        for (var i = 0; i < numberOfWaves; i++){

            int randomNumber = Random.Range(0, arrayOfEnemyGroupPrefabs.Length);
            randomListOfEnemyPrefabs.Add(arrayOfEnemyGroupPrefabs[randomNumber]);
        }
    }
	
	// Update is called once per frame
	void Update () {

        // checking to see if our countdown timer has reached the end //
        if (DisplayStartTextCountDown())
        {
            if (enemySpawnHasStarted == false)
            {
                // if it has, then start sending out waves of enemies //
                if (randomListOfEnemyPrefabs.Count != 0)
                {
                    SendOutWaveOfEnemies();
                    enemySpawnHasStarted = true;
                }
            }
        }
        
	}



    void SendOutWaveOfEnemies()
    {
        if (randomListOfEnemyPrefabs.Count != 0)
        {
            float playerXPosition = player.transform.position.x;
            GameObject enemyPrefab = randomListOfEnemyPrefabs[0];

            float yPosition = 0.0f;

            if (enemyPrefab.name == "VerticalEnemyFormation")
            {
                // the vertical group needs to instantiate a good distance above the scene //
                yPosition = 4.0f;
            }
            else if(enemyPrefab.name == "HorizontalEnemyFormation")
            {
                // the horizontal group needs to instantiate a small distance above the scene //
                yPosition = 2.0f;
            }else if(enemyPrefab.name == "BoxEnemyFormation")
            {
                yPosition = 2.0f;
            }

            Debug.Log("--> Position --> " + this.transform.position.y + yPosition);


            GameObject waveOfEnemies = Instantiate(enemyPrefab, new Vector3(playerXPosition, heightOfPlayingField / 2 + yPosition, this.transform.position.z), Quaternion.identity);
            EnemyGrouping waveOfEnemiesScript = waveOfEnemies.GetComponent<EnemyGrouping>();

            // adding a listener for the delegate method hasCompleted and sendoutanotherwave //
            waveOfEnemiesScript.hasCompleted += new EnemyGrouping.EnemyGroupingDelegate(HandleEnemiesHaveCompleted);
            waveOfEnemiesScript.sendOutAnotherWave += new EnemyGrouping.EnemyGroupingDelegate(SendOutAnotherWaveOfEnemies);
        }
    }


    // this is the delegate call made from the instantiated enemy group //
    void HandleEnemiesHaveCompleted(GameObject enemyGroup)
    {
        if (randomListOfEnemyPrefabs.Count != 0)
        {
            if (enemyGroup != null)
            {
                Destroy(enemyGroup);
            }
            randomListOfEnemyPrefabs.RemoveAt(0);
            enemySpawnHasStarted = false;
        }
    }

    // starting another wave.  Called from the delegate //
    void SendOutAnotherWaveOfEnemies(GameObject enemyGroup){
        enemySpawnHasStarted = false;
    }








    // **** start of level stuff **** //
    // creating a countdown timer from 5 - 0 //
    bool DisplayStartTextCountDown()
    {
        bool done = false;
        if (start == false)
        {
            countDownStartTime -= Time.deltaTime;
            if ((int)(countDownStartTime) == 0)
            {
                // start the waves of enemies //
                start = true;
            }
            else
            {
                countDownText.text = "" + (int)(countDownStartTime);
            }
        }
        else
        {
            DisplayGoText();
            // making sure the "Go!"  Has gone away before proceeding //
            if (startEnemySpawningBoolean)
            {
                done = true;
            }
        }
        return done;
    }

    // Displays Go! for 2 seconds then destroys itself //
    void DisplayGoText()
    {
        countDownText.text = "Go!";
        goDisplayTime -= Time.deltaTime;
        if((int)(goDisplayTime) == 0)
        {
            Destroy(countDownPrefab);
            startEnemySpawningBoolean = true;
        }

    }

}
