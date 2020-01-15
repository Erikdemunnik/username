using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHorizonTracker : MonoBehaviour
{
    public Transform target;
    private PlayerSpawn spawnScript;

    void Start()
    {
        spawnScript = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawn>();
    }

    // Update is called once per frame
    void Update()
    {

        if(spawnScript.BattleStart == true)
        {
            transform.LookAt(target);
        }
    }
}
