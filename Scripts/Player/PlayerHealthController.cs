using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour {
    int playerHealth;
    public Button exitButton;
	// Use this for initialization
	void Start () {
        playerHealth = GameController.GC.shipHealth;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("basic")||other.CompareTag("advanced") || other.CompareTag("EnemyAmmo"))
        {
            Debug.Log("hit");
            if(playerHealth > 0)
            {
                playerHealth--;
                //this.GetComponentInChildren<ShieldController>().StartShield();
            }
            if(playerHealth <= 0)
            {
                
                this.GetComponent<MeshRenderer>().enabled = false;
                ParticleSystem[] particleSystems;
                particleSystems = GetComponentsInChildren<ParticleSystem>();

                foreach (ParticleSystem Emission in particleSystems)
                    Emission.enableEmission = false;

                exitButton.GetComponent<SceneController>().BackToMain();

            }
        }
    }
}
