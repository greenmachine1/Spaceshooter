using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
    private float shieldTime;
    private float timer;
    public static ShieldController SC;
	// Use this for initialization
	void Start () {
        StartShield();
	}
	void Update()
    {
        shieldTime = GameController.GC.shipShield + 5;
        timer += Time.deltaTime;
        if (timer > shieldTime)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<SphereCollider>().enabled = false;
            
        }
    }

    public void StartShield()
    {
        timer = 0;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<SphereCollider>().enabled = true;
    }
}
