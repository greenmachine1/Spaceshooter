using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowController : MonoBehaviour {

    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {

        this.transform.position = player.transform.position;


        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 1);
        */


	}
}
