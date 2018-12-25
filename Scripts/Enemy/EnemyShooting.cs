using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    public float time = 2.0f;
	float originalTime = 0.0f;

	// Use this for initialization
	void Start () {
		originalTime = time;
	}

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            fireWeapon();
            time = originalTime;
        }
    }

    void fireWeapon()
    {
        GameObject enemyAmmo = Instantiate(Resources.Load("EnemyAmmo"), this.transform.position, this.transform.rotation) as GameObject;
    }
}
