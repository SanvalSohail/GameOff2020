using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class Attributes : MonoBehaviour

{
    public int maxHP;
    public int currentHP;
    public int level; //stats will just be attack and defence power directly proportional to level, don't need their own attributes
    public int nextLevelXP;
    public int currentXP;
    public int currency;
    public string rangedWeapon;
    public string meleeWeapon;
    // Start is called before the first frame update
    void handleDeath() { 
        //todo
    }

    public void changeCurrency(int amount) {     //positive amount means gain money, negative means lose money
        currency += amount;
        if (currency < 0) {
            currency = 0;
        }
    }

    public void switchMelee(string weapon) {
        meleeWeapon = weapon;
    }

    public void switchRanged(string weapon) { 
       rangedWeapon = weapon;
    }

    public void takeDamage(int hp) {
        currentHP -= hp;
        if (currentHP <= 0) {
            currentHP = 0;
            //handle death in another script TODO
        }
    }
    public void gainXP(int xp) {
        currentXP += xp;
        if (currentXP >= nextLevelXP) //the level up event
        {
            int carryover = currentXP - nextLevelXP;
            currentXP = carryover;
            level++;
            maxHP += 10;
            currentHP += 10;
            nextLevelXP = nextLevelXP*2;
        }

    }

    public void Heal(int hp) {
        currentHP += hp;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
    void Start() //on startup
    {
        maxHP = 100;
        currentHP = 100;
        level = 1;
        nextLevelXP = 20;
        currentXP = 0;
        rangedWeapon = "pistol";
        meleeWeapon = "fists";
        currency = 0;

    }

    // Update is called once per frame

    void Update()
    {

    }
}
