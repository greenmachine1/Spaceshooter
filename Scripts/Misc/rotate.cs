using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.back * 30.0f * Time.deltaTime);
        this.transform.Rotate(Vector3.up * 70.0f * Time.deltaTime);
    }
}
