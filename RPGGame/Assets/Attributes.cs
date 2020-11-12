using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Attributes : MonoBehaviour

{
    static public int maxHP = 100;
    static public int currentHP = 100;
    static public int level = 1; //stats will just be attack and defence power directly proportional to level, don't need their own attributes
    static public int nextLevelXP = 20;
    static public int currentXP = 0;
    static public int currency = 0;
    static public string rangedWeapon = "pistol";
    static public string meleeWeapon = "fists";
    static public int dead=0;
    public bool invincible = false;


    public int SetmaxHP;
    public int SetcurrentHP;
    public int Setlevel; //stats will just be attack and defence power directly proportional to level, don't need their own attributes
    public int SetnextLevelXP;
    public int SetcurrentXP;
    public int Setcurrency;
    public string SetrangedWeapon;
    public string SetmeleeWeapon;


    //public levelTextScript levelTextScript;
    //public hpBarScript script;
    // Start is called before the first frame update
    public void refillHP()
    {
        currentHP = maxHP;
    }
    public int getMaxXp()
    {
        return nextLevelXP;
    }
    public int getXP()
    {
        return currentXP;
    }
    public int getMaxHP()
    {
        return maxHP;
    }

    public int getHP()
    {
        return currentHP;
    }

    public void changeCurrency(int amount)
    {     //positive amount means gain money, negative means lose money
        currency += amount;
        if (currency < 0)
        {
            currency = 0;
        }
    }

    public void switchMelee(string weapon)
    {
        meleeWeapon = weapon;
    }

    public void switchRanged(string weapon)
    {
        rangedWeapon = weapon;
    }

    public void takeDamage(int hp)
    {
        currentHP -= hp;
        if (currentHP <= 0)
        {
            dead = 1;
            SceneManager.LoadScene("DeathScreen");
            currentHP = 0;
        }
        GameObject hpbar = GameObject.FindWithTag("HealthDisplay");
        hpbar.GetComponent<hpSlider>().changeBar(currentHP, maxHP);
    }
    public void gainXP(int xp)
    {
        currentXP += xp;
        if (currentXP >= nextLevelXP) //the level up event
        {
            int carryover = currentXP - nextLevelXP;
            currentXP = carryover;
            level++;
            maxHP += 10;
            currentHP += 10;
            nextLevelXP = nextLevelXP * 2;
            GameObject levelText = GameObject.FindWithTag("levelText");
            levelText.GetComponent<levelText>().levelUp(level);
            GameObject hpbar = GameObject.FindWithTag("HealthDisplay");
            hpbar.GetComponent<hpSlider>().changeBar(currentHP, maxHP);
            //GameObject hpbar = GameObject.FindWithTag("hpBar");
            //hpbar.GetComponent<hpBarScript>().changeBar(currentHP, maxHP);
        }

        GameObject xpbar = GameObject.FindWithTag("XpDisplay");
        xpbar.GetComponent<xpSlider>().changeBar(currentXP, nextLevelXP);

    }

    public void Heal(int hp)
    {
        currentHP += hp;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        GameObject hpbar = GameObject.FindWithTag("HealthDisplay");
        hpbar.GetComponent<hpSlider>().changeBar(currentHP, maxHP);
    }

    void Start() //on startup
    {
        if (dead==1) {
            currentHP = maxHP;
        }
        GameObject hpbar = GameObject.FindWithTag("HealthDisplay");
        hpbar.GetComponent<hpSlider>().changeBar(currentHP, maxHP);

        GameObject xpbar = GameObject.FindWithTag("XpDisplay");
        xpbar.GetComponent<xpSlider>().changeBar(currentXP, nextLevelXP);

        GameObject levelText = GameObject.FindWithTag("levelText");
        levelText.GetComponent<levelText>().levelUp(level);

    }

    // Update is called once per frame

    void Update()
    {
        SetmaxHP = maxHP;
        SetcurrentHP = currentHP;
        Setlevel = level;
        SetnextLevelXP = nextLevelXP;
        SetcurrentXP = currentXP;
        Setcurrency = currency;
        SetrangedWeapon = rangedWeapon;
        SetmeleeWeapon = meleeWeapon;
    }
}
