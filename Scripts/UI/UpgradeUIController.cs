using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeUIController : MonoBehaviour {

   
    public Text weaponDamage;
    public Text weaponSpeed;
    public Text shieldTime;
    public Text sWTime;
    public Text bombs;
    public Text health;

    public Text WDScrap;
    public Text WSScrap;
    public Text SScrap;
    public Text SWscrap;
    public Text BScrap;
    public Text HScrap;

    public Text ShipScrap;

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        weaponDamage.text = GameController.GC.shipWeaponDamage.ToString();
        weaponSpeed.text = GameController.GC.shipWeaponSpeed.ToString();
        shieldTime.text = GameController.GC.shipShield.ToString();
        sWTime.text = GameController.GC.shipSpecialWeapon.ToString();
        bombs.text = GameController.GC.shipBombs.ToString();
        health.text = GameController.GC.shipHealth.ToString();

        ShipScrap.text = GameController.GC.shipScrap.ToString() + "  - SCRAP";

        UpdateScrap();
    }

    public void UpdateScrap()
    {
        WDScrap.text = GameController.GC.WDCost.ToString();
        WSScrap.text = GameController.GC.WSCost.ToString();
        SScrap.text = GameController.GC.SCost.ToString();
        SWscrap.text = GameController.GC.SWCost.ToString();
        BScrap.text = GameController.GC.BCost.ToString();
        HScrap.text = GameController.GC.HCost.ToString();
    }
   
    public void UpdateDamage()
    {
        if (GameController.GC.shipScrap >= GameController.GC.WDCost)
        {
            GameController.GC.shipScrap -= GameController.GC.WDCost;
            GameController.GC.shipWeaponDamage += 1;
            UpdateUI();
        }
    }
    public void UpdateWeaponSpeed()
    {
        if (GameController.GC.shipScrap >= GameController.GC.WSCost)
        {
            GameController.GC.shipScrap -= GameController.GC.WSCost;
            GameController.GC.shipWeaponSpeed += 1;
            UpdateUI();
        }
    }
    public void UpdateShieldTime()
    {
        if (GameController.GC.shipScrap >= GameController.GC.SCost)
        {
            GameController.GC.shipScrap -= GameController.GC.SCost;
            GameController.GC.shipShield += 1;
            UpdateUI();
        }
    }
    public void UpdateSpeacialWeaponTime()
    {
        if (GameController.GC.shipScrap >= GameController.GC.SWCost)
        {
            GameController.GC.shipScrap -= GameController.GC.SWCost;
            GameController.GC.shipSpecialWeapon += 1;
            UpdateUI();
        }
    }
    public void UpdateBombs()
    {
        if (GameController.GC.shipScrap >= GameController.GC.BCost)
        {
            GameController.GC.shipScrap -= GameController.GC.BCost;
            GameController.GC.shipBombs += 1;
            UpdateUI();
        }

    }
    public void UpdateHealth()
    {
        if (GameController.GC.shipScrap >= GameController.GC.HCost)
        {
            GameController.GC.shipScrap -= GameController.GC.HCost;
            GameController.GC.shipHealth += 1;
            UpdateUI();
        }
    }
}
