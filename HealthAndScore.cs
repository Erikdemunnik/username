using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthAndScore : MonoBehaviour
{
    public float redBrawlerHP;
    public float blueBrawlerHP;

    public float redRunnerHP;
    public float blueRunnerHP;

    public float redFighterHP;
    public float blueFighterHP;

    public float objStatRed;
    public float objStatBlue;


    public RectTransform rbBar;
    public RectTransform bbBar;

    public RectTransform rrBar;
    public RectTransform brBar;

    public RectTransform rfBar;
    public RectTransform bfBar;

    public RectTransform objStatusRed;
    public RectTransform objStatusBlue;

    public Text money1;
    public Text money2;
    float vict = 0;

    void Start()
    {
        redBrawlerHP = 20f;
        blueBrawlerHP = 20f;

        redRunnerHP = 20f;
        blueRunnerHP = 20f;

        redFighterHP = 20f;
        blueFighterHP = 20f;

        objStatBlue = 0f;
        objStatRed = 0f;
    }

    public void HealthCheck()
    {
        //(opgeroepen na elke vorm van damage)
        //health minimum 
        if (redBrawlerHP < 0)
        {
            redBrawlerHP = 0;
        }
        if (blueBrawlerHP < 0)
        {
            blueBrawlerHP = 0;
        }
        if (redRunnerHP < 0)
        {
            redRunnerHP = 0;
        }
        if (blueRunnerHP < 0)
        {
            blueRunnerHP = 0;
        }
        if (redFighterHP < 0)
        {
            redFighterHP = 0;
        }
        if (blueFighterHP < 0)
        {
            blueFighterHP = 0;
        }
        //health maximum
        if (redBrawlerHP > 20)
        {
            redBrawlerHP = 20;
        }
        if (blueBrawlerHP > 20)
        {
            blueBrawlerHP = 20;
        }
        if (redRunnerHP > 20)
        {
            redRunnerHP = 20;
        }
        if (blueRunnerHP > 20)
        {
            blueRunnerHP = 20;
        }
        if (redFighterHP > 20)
        {
            redFighterHP = 20;
        }
        if (blueFighterHP > 20)
        {
            blueFighterHP = 20;
        }
    }
    void Update()
    {
        //Score balk
        objStatusBlue.transform.localScale = new Vector3((objStatBlue / 1000) * 4.4f, objStatusBlue.transform.localScale.y, objStatusBlue.transform.localScale.z);
        objStatusRed.transform.localScale = new Vector3((objStatRed / 1000) * 4.4f, objStatusRed.transform.localScale.y, objStatusRed.transform.localScale.z);

        //Health bar scale verandert met de health van de speler gedeeld door zijn max health, keer de lengte van de totale bar (2.17m)
        rbBar.transform.localScale = new Vector3((redBrawlerHP / 20) * 2.17f, rbBar.transform.localScale.y, rbBar.transform.localScale.z);
        bbBar.transform.localScale = new Vector3((blueBrawlerHP / 20) * 2.17f, bbBar.transform.localScale.y, bbBar.transform.localScale.z);
        rrBar.transform.localScale = new Vector3((redRunnerHP / 20) * 2.17f, rrBar.transform.localScale.y, rrBar.transform.localScale.z);
        brBar.transform.localScale = new Vector3((blueRunnerHP / 20) * 2.17f, brBar.transform.localScale.y, brBar.transform.localScale.z);
        rfBar.transform.localScale = new Vector3((redFighterHP / 20) * 2.17f, rfBar.transform.localScale.y, rfBar.transform.localScale.z);
        bfBar.transform.localScale = new Vector3((blueFighterHP / 20) * 2.17f, bfBar.transform.localScale.y, bfBar.transform.localScale.z);

        //objStatBlue = (objStatBlue + 30 * Time.deltaTime);
        //objStatRed = (objStatRed + 30 * Time.deltaTime);

        //score maxiumum
        if (objStatBlue > 1000)
        {
            objStatBlue = 1000;
            VictoryBlue();
        }
        if (objStatRed > 1000)
        {
            objStatRed = 1000;
            VictoryRed();
        }

        PlayerSpawn spawnScript = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawn>();
        //death activatie
        if (spawnScript.BattleStart == true)
        {
            Playermovement Rrunner = GameObject.Find("Red Runner").GetComponent<Playermovement>();
            
            // if (Rrunner.dead == false)
            // {
            //     redRunnerHP = 20;
            // }
            if (redRunnerHP <= 0)
            {
                //Rrunner.deathCooldown = 0;
                Rrunner.dead = true;
            }
            else
            {
                Rrunner.dead = false;
            }
            if (Rrunner.respawned == true)
            {
                redRunnerHP = 20;
            }

            Playermovement Brunner = GameObject.Find("Blue Runner").GetComponent<Playermovement>();
            // if (Brunner.dead == false)
            // {
            //     blueRunnerHP = 20;
            // }
            if (blueRunnerHP <= 0)
            {
                //Brunner.deathCooldown = 0;
                Brunner.dead = true;
            }
            else
            {
                Brunner.dead = false;
            }
            if (Brunner.respawned == true)
            {
                blueRunnerHP = 20;
            }

            Playermovement Rfighter = GameObject.Find("Red Fighter").GetComponent<Playermovement>();
            if (redFighterHP <= 0)
            {
                //Rfighter.deathCooldown = 0;
                Rfighter.dead = true;
            }
            else
            {
                Rfighter.dead = false;
            }
            if (Rfighter.respawned == true)
            {
                redFighterHP = 20;
            }

            Playermovement Bfighter = GameObject.Find("Blue Fighter").GetComponent<Playermovement>();
            // if (Bfighter.dead == false)
            // {
            //     blueFighterHP = 20;
            // }
            if (blueFighterHP <= 0)
            {
                //Bfighter.deathCooldown = 0;
                Bfighter.dead = true;
            }
            else
            {
                Bfighter.dead = false;
            }
            if (Bfighter.respawned == true)
            {
                blueFighterHP = 20;
            }

            Playermovement Rbrawler = GameObject.Find("Red Brawler").GetComponent<Playermovement>();
            // if (Rbrawler.dead == false)
            // {
            //     redBrawlerHP = 20;
            // }
            if (redBrawlerHP <= 0)
            {
                //Rbrawler.deathCooldown = 0;
                Rbrawler.dead = true;
            }
            else
            {
                Rbrawler.dead = false;
            }
            if (Rbrawler.respawned == true)
            {
                redBrawlerHP = 20;
            }

            Playermovement Bbrawler = GameObject.Find("Blue Brawler").GetComponent<Playermovement>();
            // if (Bbrawler.dead == false)
            // {
            //     blueBrawlerHP = 20;
            // }
            if (blueBrawlerHP <= 0)
            {
                //Bbrawler.deathCooldown = 0;
                Bbrawler.dead = true;
            }
            else
            {
                Bbrawler.dead = false;
            }
            if (Bbrawler.respawned == true)
            {
                blueBrawlerHP = 20;
            }
        }
    }
    void VictoryBlue()
    {
        
        vict ++;
        if (vict > 100)
        {
        SceneManager.LoadScene("VictoryScreen");
        }
    }
    void VictoryRed()
    {
        vict ++;
        if (vict > 100)
        {
        SceneManager.LoadScene("VictoryScreen");
        }
    }
}
