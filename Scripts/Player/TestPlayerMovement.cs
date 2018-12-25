using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour {

    public Vector3 mouseLocation;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetNewPlayerLocation();
	}

    void SetNewPlayerLocation()
    {
        mouseLocation = Input.mousePosition;
        mouseLocation.z = 10;
        mouseLocation.y += 100;
        mouseLocation = Camera.main.ScreenToWorldPoint(mouseLocation);
        mouseLocation.z = 0;
        this.transform.position = mouseLocation;
    }
}
