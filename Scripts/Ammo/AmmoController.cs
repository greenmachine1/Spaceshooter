using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public float ammoSpeed;
    public float ammoDistance;
    public float colliderY;
    private Rigidbody thisRigid;
    private void Awake()
    {
        thisRigid = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        thisRigid.velocity = transform.up * ammoSpeed;
        
        if (this.gameObject.transform.position.y >= colliderY)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("topBoundary") || collider.CompareTag("sideBoundary"))
        {
            Destroy(this.gameObject);
        }

    }

}