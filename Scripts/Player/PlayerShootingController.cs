using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour {

    public float ammoDelay;
    public float timeStamp;

    public GameObject gunObject;
    public GameObject gunLeftObject;
    public GameObject gunRightObject;

    void FixedUpdate()
    {
        if (ammoDelay > 0)
        {
            ammoDelay = .5f - (GameController.GC.shipWeaponSpeed * .03f);
        }else
        {
            ammoDelay = 0;
        }
            SingleShot();
    }

    public void SingleShot()
    {
        if(Input.GetMouseButton(0) && Time.time >= timeStamp)
        {
           GameObject ammo = Instantiate(Resources.Load("PlayerAmmo"), gunObject.transform.position, this.transform.rotation) as GameObject;
           GameObject ammoRight = Instantiate(Resources.Load("PlayerAmmo"), gunLeftObject.transform.position, this.transform.rotation) as GameObject;
           GameObject ammoLeft = Instantiate(Resources.Load("PlayerAmmo"), gunRightObject.transform.position, this.transform.rotation) as GameObject;
         
           timeStamp = Time.time + ammoDelay;
        }
    }
}
