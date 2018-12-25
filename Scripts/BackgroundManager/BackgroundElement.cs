using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour {

	public float scrollRate = 0.05f;

	// Update is called once per frame
	void Update () {
        //transform.Translate(0.0f, scrollRate, 0.0f);
        transform.Translate(Vector3.down * scrollRate);
	}
}
