using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private HealthAndScore scoreHealth;
    private Playermovement damageType;
    float damageDone;

    void Start()
    {
        scoreHealth = GameObject.Find("ScoreStatus").GetComponent<HealthAndScore>();
        damageType = gameObject.GetComponentInParent<Playermovement>();
        damageDone = 1;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //damage balancing
        if (gameObject.name == "PunchingHitboxRed")
        {
            if (other.gameObject.name == "blueBrawler")
            {
                if (damageType.isRunner == true)
                {
                    scoreHealth.blueBrawlerHP = (scoreHealth.blueBrawlerHP - (damageDone * 1));
                }
                if (damageType.isFighter == true)
                {
                    scoreHealth.blueBrawlerHP = (scoreHealth.blueBrawlerHP - (damageDone * 9));
                }
                if (damageType.isBrawler == true)
                {
                    scoreHealth.blueBrawlerHP = (scoreHealth.blueBrawlerHP - (damageDone * 2));
                }
            }

            if (other.gameObject.name == "blueRunner")
            {
                if (damageType.isRunner == true)
                {
                    scoreHealth.blueRunnerHP = (scoreHealth.blueRunnerHP - (damageDone * 2));
                }
                if (damageType.isFighter == true)
                {
                    scoreHealth.blueRunnerHP = (scoreHealth.blueRunnerHP - (damageDone * 1));
                }
                if (damageType.isBrawler == true)
                {
                    scoreHealth.blueRunnerHP = (scoreHealth.blueRunnerHP - (damageDone * 15));
                }
            }

            if (other.gameObject.name == "blueFighter")
            {
                if (damageType.isRunner == true)
                {
                    scoreHealth.blueFighterHP = (scoreHealth.blueFighterHP - (damageDone * 5));
                }
                if (damageType.isFighter == true)
                {
                    scoreHealth.blueFighterHP = (scoreHealth.blueFighterHP - (damageDone * 2));
                }
                if (damageType.isBrawler == true)
                {
                    scoreHealth.blueFighterHP = (scoreHealth.blueFighterHP - (damageDone * 2));
                }
            }
        }



        if (gameObject.name == "PunchingHitboxBlue")
        {
            if (other.gameObject.name == "redBrawler")
            {
                if (damageType.isRunner == true)
                {
                    scoreHealth.redBrawlerHP = (scoreHealth.redBrawlerHP - (damageDone * 1));
                }
                if (damageType.isFighter == true)
                {
                    scoreHealth.redBrawlerHP = (scoreHealth.redBrawlerHP - (damageDone * 9));
                }
                if (damageType.isBrawler == true)
                {
                    scoreHealth.redBrawlerHP = (scoreHealth.redBrawlerHP - (damageDone * 2));
                }
            }
            if (other.gameObject.name == "redRunner")
            {
                if (damageType.isRunner == true)
                {
                    scoreHealth.redRunnerHP = (scoreHealth.redRunnerHP - (damageDone * 2));
                }
                if (damageType.isFighter == true)
                {
                    scoreHealth.redRunnerHP = (scoreHealth.redRunnerHP - (damageDone * 1));
                }
                if (damageType.isBrawler == true)
                {
                    scoreHealth.redRunnerHP = (scoreHealth.redRunnerHP - (damageDone * 15));
                }
            }

            if (other.gameObject.name == "redFighter")
            {
                if (damageType.isRunner == true)
                {
                    scoreHealth.redFighterHP = (scoreHealth.redFighterHP - (damageDone * 5));
                }
                if (damageType.isFighter == true)
                {
                    scoreHealth.redFighterHP = (scoreHealth.redFighterHP - (damageDone * 2));
                }
                if (damageType.isBrawler == true)
                {
                    scoreHealth.redFighterHP = (scoreHealth.redFighterHP - (damageDone * 2));
                }
            }
        }
        scoreHealth.HealthCheck();
    }
}
