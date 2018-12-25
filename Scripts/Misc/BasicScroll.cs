using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicScroll : MonoBehaviour {
    public float scrollSpeedY;
    public float scrollSpeedX;

	void Update () {
        Vector3 newPosition = this.transform.position;
        newPosition.y -= scrollSpeedY;
        newPosition.x -= scrollSpeedX;
        this.transform.position = newPosition;
	}
}
