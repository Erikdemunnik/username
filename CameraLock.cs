using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    float cameraZoom;
    public Vector3 redMid;
    public Vector3 blueMid;
    public float smoothTime = 0.1f;
    public Transform camTarget;
    private Vector3 velocity = Vector3.zero;
    public int cameraDistance = 20;
    public Transform horizon;
    private PlayerSpawn spawnScript;

    void Start()
    {
        spawnScript = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawn>();
    }

    void FixedUpdate()
    {
        if(spawnScript.BattleStart == true)
        {
            //hoe ver de camera uitzoomt om de spelers goed in beeld te houden
            cameraZoom = (Vector3.Distance(redMid, blueMid));
            //gemiddelde positie tussen de twee spelers
            float midX = (redMid.x + blueMid.x) / 2f;
            float midY = (redMid.y + blueMid.y) / 2f;
            //transform van de empty waar dit script in zit
            transform.position = new Vector3(midX, midY +3f, (-cameraZoom * 0.4f) -cameraDistance);
            //camera volgt de empty met demping zodat ie smoooooth rondvliegt
            Vector3 targetPosition = transform.TransformPoint(new Vector3(0, 2, 0));
            camTarget.transform.position = Vector3.SmoothDamp(camTarget.transform.position, targetPosition, ref velocity, smoothTime);
            horizon.transform.position = new Vector3(camTarget.transform.position.x, 0, 20);
        }
    }
}
