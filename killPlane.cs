using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlane : MonoBehaviour
{
    public HealthAndScore scoreHealth;
    // Start is called before the first frame update
    void Start()
    {
        scoreHealth = GameObject.Find("ScoreStatus").GetComponent<HealthAndScore>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "blueBrawler")
        {
            scoreHealth.blueBrawlerHP -= 30 * Time.deltaTime;
        }
        if (other.gameObject.name == "blueRunner")
        {
            scoreHealth.blueRunnerHP -= 30 * Time.deltaTime;
        }
        if (other.gameObject.name == "blueFighter")
        {
            scoreHealth.blueFighterHP -= 30 * Time.deltaTime;
        }
        if (other.gameObject.name == "redBrawler")
        {
            scoreHealth.redBrawlerHP -= 30 * Time.deltaTime;
        }
        if (other.gameObject.name == "redRunner")
        {
            scoreHealth.redRunnerHP -= 30 * Time.deltaTime;
        }
        if (other.gameObject.name == "redFighter")
        {
            scoreHealth.redFighterHP -= 30 * Time.deltaTime;
        }
        scoreHealth.HealthCheck();
        
    }
}
