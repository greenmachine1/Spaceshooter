using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthScript : MonoBehaviour {

    public int bossHealth;

    private void Update()
    {
        if(bossHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerAmmo"))
        {
            bossHealth -= GameController.GC.shipWeaponDamage * 33;
        }
    }
}
