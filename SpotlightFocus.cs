using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFocus : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public Transform smoothTarget;
    public float smoothTime = 0.1f;
    private PlayerSpawn spawnScript;
    private CameraLock focusPoint;
    MeshRenderer playerHud;
    public bool teamRed;
    void Start()
    {
        spawnScript = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawn>();
        focusPoint = GameObject.Find("CameraSmoother").GetComponent<CameraLock>();
        playerHud = GetComponentInChildren<MeshRenderer>();
        playerHud.enabled = false;
    }


    void Update()
    {   
        if(spawnScript.BattleStart == true)
        {
            playerHud.enabled = true;
            if (teamRed == true)
            {
                smoothTarget.transform.position = Vector3.SmoothDamp(smoothTarget.transform.position, focusPoint.redMid, ref velocity, smoothTime);
            }
            else
            {
                smoothTarget.transform.position = Vector3.SmoothDamp(smoothTarget.transform.position, focusPoint.blueMid, ref velocity, smoothTime);
            }
            
            transform.LookAt(smoothTarget);

        }
    }
}
