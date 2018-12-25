using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// **** the basic function of the Enemy Grouping is to group together **** //
// **** the enemies into manageble chunks and monitor their status **** //
// **** A timer will start and based on the groups makeup, time will be added to this **** //
// **** if all the enemies within the group have been destroyed, the timer will not go off **** //
// **** as this will be a null issue.  If all enemies have been destroyed or the timer goes **** //
// **** off, a new wave of enemies will be dispatched **** //

// **** this will be a simple line formation of 4 enemies **** //

public class EnemyGrouping : MonoBehaviour {

    // creating a callback delegate //
    public delegate void EnemyGroupingDelegate(GameObject enemyGroup);
    public event EnemyGroupingDelegate hasCompleted;
    public event EnemyGroupingDelegate sendOutAnotherWave;

    public float time = 10.0f;
    public float enemySpeed = 0.05f;
    //bool enemyShouldStop = false;

    public int formation = 0;
    private bool killTimer = false;

    private int totalNumberOfEnemiesKilled = 0;
    int totalNumberOfEnemiesInFormation = 0;

    public List<GameObject> listOfEnemies = new List<GameObject>();
    private List<GameObject> randomListOfEnemies = new List<GameObject>();

    private GameObject scrap;


	void Start () {


        RandomizeEnemyArray();
        // this will go through our list of enemies and see how many of each type we have //
        // then it will add time to our timer //
        foreach(var enemies in listOfEnemies)
        {
            if(enemies.tag == "basic")
            {
                time = time + 0.0f;
                enemySpeed = enemySpeed - 0.0f;
            }else if(enemies.tag == "advanced")
            {
                time = time + 1.0f;
                enemySpeed = enemySpeed - 0.005f;
            }else if(enemies.tag == "Enemy")
            {
                time = time + 1.0f;
                enemySpeed = enemySpeed - 0.005f;
            }
        }

        switch (formation)
        {
            // horizontal line formation //
            case 0:
                {
                    HorizontalLineFormation();
                    break;
                }
            // vertical line formation //
            case 1:
                {
                    VerticalLineFormation();
                    break;
                }
            // box formation //
            case 2:
                {
                    BoxFormation();
                    break;
                }
        }  

        
    }

    void RandomizeEnemyArray()
    {
        List<int> tempArrayOfRandomNumbers = new List<int>();
        int randomNumber;
        for(var i = 0; i < listOfEnemies.Count; i++){
            do{
                randomNumber = UnityEngine.Random.Range(0, listOfEnemies.Count);
            }while(tempArrayOfRandomNumbers.Contains(randomNumber));
                tempArrayOfRandomNumbers.Add(randomNumber);
                randomListOfEnemies.Add(listOfEnemies[randomNumber]);
        }

        // overriding the straight array of enemies with a randomized version of itself //
        listOfEnemies = randomListOfEnemies;

    }


    void hasDied(int diedFrom, string tag)
    {
        totalNumberOfEnemiesKilled++;
        if(totalNumberOfEnemiesKilled == totalNumberOfEnemiesInFormation)
        {
            KillTimerAndThisObject();

            // making sure to not launch out any scrap if the enemy was killed //
            // by the boundary //
            if(diedFrom != 1)
            {
                SendScrap();
            }
            
        }
    }

    void Update () {

        // this timer goes on in the background so that if the player hasnt killed all the enemies in the group //
        // a new group / enemy will be dispatched anyway.  The time the player has to kill all the enemies within //
        // the group will depend on the makeup of the group //
		if(killTimer == false){
			time -= Time.deltaTime;
			if(time < 0){
                SendOutAnotherWave();
                KillTimerAndThisObject();
            }
		}

        // moving the unit downwards //
        this.transform.Translate(Vector3.down * enemySpeed * Time.deltaTime, Space.World);
    }

    void SendOutAnotherWave(){
        killTimer = true;
        sendOutAnotherWave(this.gameObject);
    }

    void KillTimerAndThisObject()
    {
        killTimer = true;
        hasCompleted(this.gameObject);
    }


    // **** the formations **** //
    void HorizontalLineFormation()
    { 
        // create a simple horizontal formation of enemies to start with //
        for (var i = 0; i < listOfEnemies.Count; i++)
        {
            float widthOfEnemy = 1.0f;
            GameObject newEnemy = Instantiate(listOfEnemies[i], new Vector3(i * (widthOfEnemy + 1) - (listOfEnemies.Count / 2 + (widthOfEnemy + 1)), this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            newEnemy.transform.parent = this.gameObject.transform;

            Collider enemyCollider = newEnemy.GetComponent<BoxCollider>();
            widthOfEnemy = enemyCollider.bounds.size.x;

            // incrementing the total number of enemies in this formation //
            totalNumberOfEnemiesInFormation++;

            Enemy newEnemyScript = newEnemy.GetComponent<Enemy>();

            // adding a listener for the delegate method hasCompleted //
            newEnemyScript.hasDied += new Enemy.EnemyDelegate(hasDied);
        }
    }

    void VerticalLineFormation()
    {
        // create a simple vertical formation of enemies to start with //
        for (var i = 0; i < listOfEnemies.Count; i++)
        {
            float heightOfEnemy = 1.0f;
            GameObject newEnemy = Instantiate(listOfEnemies[i], new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + i * (heightOfEnemy + 1) - (listOfEnemies.Count / 2 + (heightOfEnemy)), this.gameObject.transform.position.z), Quaternion.identity);
            newEnemy.transform.parent = this.gameObject.transform;

            Collider enemyCollider = newEnemy.GetComponent<BoxCollider>();
            heightOfEnemy = enemyCollider.bounds.size.y;

            Enemy newEnemyScript = newEnemy.GetComponent<Enemy>();

            // incrementing the total number of enemies in this formation //
            totalNumberOfEnemiesInFormation++;

            // adding a listener for the delegate method hasCompleted //
            newEnemyScript.hasDied += new Enemy.EnemyDelegate(hasDied);
        }
    }


    // need to work on this more //
    // rotating box formation //
    void BoxFormation()
    {

        int numberOfRows = 1;
        int numberOfColumns = 1;

        int spacing = 2;

        int adjustedNumberOfRows = numberOfRows * spacing;
        int adjustedNumberOfColumns = numberOfColumns * spacing;

        // so this would effectively give 2 * 2 = 4 //
        // so the iterator would be i - (4 / 2) which over the lifespan of the //
        // for loop would be i = -2, i = -1 (which isnt used), i = 0 (which isnt used), i = 1 (which isnt used),
        // i = 2.

        for (var i = 0; i < adjustedNumberOfColumns + 1; i++){
            for (var j = 0; j < adjustedNumberOfRows + 1; j++){
                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                    {

                        GameObject enemy = Instantiate(listOfEnemies[0], new Vector3(this.transform.position.x + i - (numberOfColumns),
                                                                                             this.transform.position.y + j - (numberOfRows),
                                                                                             this.transform.position.z), Quaternion.identity);
                        enemy.transform.parent = this.gameObject.transform;
                        Enemy newEnemyScript = enemy.GetComponent<Enemy>();

                        // incrementing the total number of enemies in this formation //
                        totalNumberOfEnemiesInFormation++;

                        newEnemyScript.hasDied += new Enemy.EnemyDelegate(hasDied);

                    }
                }
            }
        }
    }




    // sending out the scrap upon destroying the group //
    void SendScrap()
    {
        scrap = Resources.Load<GameObject>("Scrap");
        Instantiate(scrap);
        scrap.transform.position = this.transform.position;
        Debug.Log("Scrap Sent");
    }


}
