using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour {

    public int numberOfEnemies;
    public int amountOfScrap;
    public int difficulty;
    public int level;
    public bool alive  = true;
 
	// Use this for initialization
	void Start () {
        amountOfScrap = 10 + (difficulty *3)  * level;
	}
	
	// Update is called once per frame
	void Update () {
		if(numberOfEnemies == 0)
        {
            alive = false;
        }
	}
}
