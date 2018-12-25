using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

    //private BoxCollider enemyCollider;

	// Use this for initialization
	void Start () {
       // enemyCollider = this.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
        
    {
        if (other.CompareTag("playerAmmo"))
        {
            Debug.Log("damageDealt");
            this.GetComponent<EnemyStatsController>().enemyHealth -= 1;
            Destroy(other.gameObject);

        }
        if (other.CompareTag("Shield"))
        {
            Debug.Log("damageDealt");
            this.GetComponent<EnemyStatsController>().enemyHealth -= 10;
            Destroy(other.gameObject);

        }
    }
}
