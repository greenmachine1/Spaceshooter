using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour {

    public float ammoSpeed = 5.0f;


    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("topBoundary") || collider.CompareTag("sideBoundary") || collider.CompareTag("Player") || collider.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.velocity = -transform.up * ammoSpeed;
    }
}
