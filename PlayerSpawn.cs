using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Rigidbody playerPrefab1;
    public int charCycleRed = 1;
    public int charCycleBlue = 1;
    public bool BattleStart = false;
    bool started1 = false;
    float spawnHeight = 40;
    Transform cameraPre;
    float forcePos;
    Rigidbody red1, red2, red3, blue1, blue2, blue3;
    float startTimer;
    void Start()
    {
        BattleStart = false;
        started1 = false;
        cameraPre = GameObject.Find("Main Camera").transform;
        cameraPre.position = new Vector3(-20f, 10, -20);
        cameraPre.rotation = Quaternion.Euler(15, 0, 0);

    }

    void Update()
    {
        //camera viegt door level voordat de game is gestart
        if (BattleStart == false)
        {
            cameraPre.position = new Vector3(cameraPre.position.x + (Mathf.Sin(Time.time * 0.25f) * 0.05f), cameraPre.position.y, cameraPre.position.z);
            startTimer += 1 * Time.deltaTime;
            cameraPre.LookAt(new Vector3(0,5,20));
        }
        //als true is dan start de battle en spawnen alle spelers (eenmalig)
        if (startTimer > 11)//seconden
        {
            BattleStart = true;
        }
        //het spawnen van elk karakter (6) waarvan twee spelers en 4 computer
        //elke instance van de speler krijgt een naam, zodat karakter-specifieke besturing in of uitgeschakeld word
        if (BattleStart == true && started1 == false)
        {
            Spawning();
        }

        if (started1 == true)
        {
            //cycle door de 3 verschillende spelers van elk team
            if (Input.GetKeyDown("q"))
            {
                charCycleRed = (charCycleRed - 1);
                RedCycle();
            }

            if (Input.GetKeyDown("e"))
            {
                charCycleRed = (charCycleRed + 1);
                RedCycle();
            }

            if (Input.GetKeyDown("right shift"))
            {
                charCycleBlue = (charCycleBlue - 1);
                BlueCycle();
            }

            if (Input.GetKeyDown("[1]"))
            {
                charCycleBlue = (charCycleBlue + 1);
                BlueCycle();
            }
        }
    }
    public void Spawning()
    {
        red1 = Instantiate(playerPrefab1, new Vector3(Random.Range(-11f,-12f), spawnHeight, 0), Quaternion.identity) as Rigidbody;
        red1.gameObject.GetComponent<Playermovement>().isRunner = true;
        red1.gameObject.GetComponent<Playermovement>().teamRed = true;
        red1.gameObject.GetComponent<Playermovement>().player1 = true;
        red1.name = "Red Runner";
        red1.transform.Find("playCollider").name = "redRunner";

        blue1 = Instantiate(playerPrefab1, new Vector3(Random.Range(11f,12f), spawnHeight, 0), Quaternion.identity) as Rigidbody;
        blue1.gameObject.GetComponent<Playermovement>().isRunner = true;
        blue1.gameObject.GetComponent<Playermovement>().teamRed = false;
        blue1.gameObject.GetComponent<Playermovement>().player2 = true;
        blue1.name = "Blue Runner";
        blue1.transform.Find("playCollider").name = "blueRunner";


        red2 = Instantiate(playerPrefab1, new Vector3(-20.0F, spawnHeight, 0), Quaternion.identity) as Rigidbody;
        red2.gameObject.GetComponent<Playermovement>().isFighter = true;
        red2.gameObject.GetComponent<Playermovement>().teamRed = true;
        red2.gameObject.GetComponent<Playermovement>().computerPlayer = true;
        red2.name = "Red Fighter";
        red2.transform.Find("playCollider").name = "redFighter";


        red3 = Instantiate(playerPrefab1, new Vector3(-26.0F, spawnHeight, 0), Quaternion.identity) as Rigidbody;
        red3.gameObject.GetComponent<Playermovement>().isBrawler = true;
        red3.gameObject.GetComponent<Playermovement>().teamRed = true;
        red3.gameObject.GetComponent<Playermovement>().computerPlayer = true;
        red3.name = "Red Brawler";
        red3.transform.Find("playCollider").name = "redBrawler";


        blue2 = Instantiate(playerPrefab1, new Vector3(20.0F, spawnHeight, 0), Quaternion.identity) as Rigidbody;
        blue2.gameObject.GetComponent<Playermovement>().isFighter = true;
        blue2.gameObject.GetComponent<Playermovement>().teamRed = false;
        blue2.gameObject.GetComponent<Playermovement>().computerPlayer = true;
        blue2.name = "Blue Fighter";
        blue2.transform.Find("playCollider").name = "blueFighter";


        blue3 = Instantiate(playerPrefab1, new Vector3(26.0F, spawnHeight, 0), Quaternion.identity) as Rigidbody;
        blue3.gameObject.GetComponent<Playermovement>().isBrawler = true;
        blue3.gameObject.GetComponent<Playermovement>().teamRed = false;
        blue3.gameObject.GetComponent<Playermovement>().computerPlayer = true;
        blue3.name = "Blue Brawler";
        blue3.transform.Find("playCollider").name = "blueBrawler";
        started1 = true;
    }
    public void RedCycle()
    {
        if (charCycleRed < 1)
        {
            charCycleRed = 3;
        }
        if (charCycleRed > 3)
        {
            charCycleRed = 1;
        }
        //rood team
        if (charCycleRed == 1)
        {
            red1.gameObject.GetComponent<Playermovement>().player1 = true;
            red2.gameObject.GetComponent<Playermovement>().player1 = false;
            red3.gameObject.GetComponent<Playermovement>().player1 = false;
        }
        if (charCycleRed == 2)
        {
            red1.gameObject.GetComponent<Playermovement>().player1 = false;
            red2.gameObject.GetComponent<Playermovement>().player1 = true;
            red3.gameObject.GetComponent<Playermovement>().player1 = false;
        }
        if (charCycleRed == 3)
        {
            red1.gameObject.GetComponent<Playermovement>().player1 = false;
            red2.gameObject.GetComponent<Playermovement>().player1 = false;
            red3.gameObject.GetComponent<Playermovement>().player1 = true;
        }
    }
    public void BlueCycle()
    {
        if (charCycleBlue < 1)
        {
            charCycleBlue = 3;
        }
        if (charCycleBlue > 3)
        {
            charCycleBlue = 1;
        }
        //blauw team
        if (charCycleBlue == 1)
        {
            blue1.gameObject.GetComponent<Playermovement>().player2 = true;
            blue2.gameObject.GetComponent<Playermovement>().player2 = false;
            blue3.gameObject.GetComponent<Playermovement>().player2 = false;
        }
        if (charCycleBlue == 2)
        {
            blue1.gameObject.GetComponent<Playermovement>().player2 = false;
            blue2.gameObject.GetComponent<Playermovement>().player2 = true;
            blue3.gameObject.GetComponent<Playermovement>().player2 = false;
        }
        if (charCycleBlue == 3)
        {
            blue1.gameObject.GetComponent<Playermovement>().player2 = false;
            blue2.gameObject.GetComponent<Playermovement>().player2 = false;
            blue3.gameObject.GetComponent<Playermovement>().player2 = true;
        }
    }
}
