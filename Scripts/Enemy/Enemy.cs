using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject player;
    public float rotationSpeed = 0.0f;
    public bool doesTrackPlayer = false;

    private Quaternion lookRotation;
    private Vector3 direction;

    public float speed;

    enum DiedFrom
    {
        PLAYER,
        BOUNDARY,
        AMMO
    };

    // creating a callback delegate //
    public delegate void EnemyDelegate(int diedFrom, string tag);
    public event EnemyDelegate hasDied;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // getting the players location then aiming towards it //
    void Update()
    {
        if(doesTrackPlayer){
            if(player != null)
            {
                Vector3 vectorToTarget = player.transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 270.0f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            }
        }
    }



    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Boundary"))
        {
            hasDied((int)(DiedFrom.BOUNDARY), this.tag);
            Destroy(this.gameObject);
        }else if (collider.CompareTag("playerAmmo"))
        {
            hasDied((int)(DiedFrom.AMMO), this.tag);
            Destroy(this.gameObject);
        }
        
    }
    
}
