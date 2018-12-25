using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour {

    public float rotateSpeed = 0.0f;

	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(-Vector3.back * rotateSpeed * Time.deltaTime);
	}
}
