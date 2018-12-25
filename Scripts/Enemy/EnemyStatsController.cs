using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsController : MonoBehaviour {

    public int enemyHealth;


	void Start () {
		switch(this.tag)
            {
            case "basic":
                enemyHealth = 2;
                break;
            case "advanced":
                enemyHealth = 3;
                break;
        }

	}
	

	void Update () {
		if(enemyHealth < 1)
        {
            Destroy(this.gameObject);
        }
	}
}
