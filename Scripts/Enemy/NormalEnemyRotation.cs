using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyRotation : MonoBehaviour {


    GameObject bottomBoundary;

	// Use this for initialization
	void Start () {
        bottomBoundary = GameObject.FindGameObjectWithTag("Boundary");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vectorToTarget = bottomBoundary.transform.position - this.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 270.0f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
	}
}
