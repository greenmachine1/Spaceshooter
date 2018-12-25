using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

    public static GameController GC;


    //Stats
    public int shipHealth; //The Amount of Health the ship has
    public int shipShield; //The Length of Time that the shield lasts after getting hit
    public int shipWeaponSpeed; //The speed at which the basic Weapon shoots
    public int shipWeaponDamage;    //The amount of damage that the basic Weapon deals
    public int shipSpecialWeapon;   //The length of time the special weapon lasts
    public int shipBombs;   //The amount of bombs the ship can carry
    public int shipScrap;   //The amount of scrap that you have collected.

    public int WDCost;
    public int WSCost;
    public int SWCost;
    public int SCost;
    public int HCost;
    public int BCost;

    //Scrap is used to upgrade the ship.

    void Awake () {
        shipHealth = 3;
        shipShield = 1;
        shipWeaponSpeed = 5;
        shipWeaponDamage = 1;
        shipSpecialWeapon = 1;
        shipBombs = 1;
        


        if(GC == null)
        {
            DontDestroyOnLoad(gameObject);
            GC = this;
        }
        else if(GC != this)
        {
            Destroy(gameObject);
        }
        
	}
    private void Update()
    {
        WDCost = shipWeaponDamage * 100;
        WSCost = shipWeaponSpeed * 100;
        SWCost = shipSpecialWeapon * 300;
        SCost = shipShield * 150;
        HCost = shipHealth * 1000;
        BCost = shipBombs * 500;   
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.shipHealth = shipHealth;
        data.shipShield = shipShield;
        data.shipWeaponSpeed = shipWeaponSpeed;
        data.shipWeaponDamage = shipWeaponDamage;
        data.shipSpecialWeapon = shipSpecialWeapon;
        data.shipBombs = shipBombs;
        data.shipScrap = shipScrap;
      

        bf.Serialize(file, data);
        file.Close();

    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            shipHealth = data.shipHealth;
            shipShield = data.shipShield;
            shipWeaponSpeed = data.shipWeaponSpeed;
            shipWeaponDamage = data.shipWeaponDamage;
            shipSpecialWeapon = data.shipSpecialWeapon;
            shipBombs = data.shipBombs;
            shipScrap = data.shipScrap;
        }
    }

    [Serializable]
    class PlayerData
    {
        public int shipHealth;
        public int shipShield;
        public int shipWeaponSpeed;
        public int shipWeaponDamage;
        public int shipSpecialWeapon;
        public int shipBombs;
        public int shipScrap;
    }
}
