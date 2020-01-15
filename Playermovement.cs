using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody player;
    public float moveSpeed = 5000f;
    public float jumpHeight = 10f;
    public float maxSpeed = 10f;
    int jumpLoop = 0;
    public float statMagnitude;
    public Transform facingDirection;
    bool doubleJumpCharge = false;
    bool doubleJumpAble = false;
    float jumpCooldown = 0;
    public bool player1 = false;
    public bool player2 = false;
    public bool computerPlayer = false;
    Collider collie;
    float punchCooldown;
    bool ableToPunch = true;
    public Collider hitColliderRed;
    public Collider hitColliderBlue;
    public MeshRenderer meshy;
    public MeshRenderer meshy2;
    public bool computerLeft = false;
    public bool computerRight = false;
    public bool computerJump = false;
    public Renderer charPlane;
    public bool isRunner = false;
    public bool isBrawler = false;
    public bool isFighter = false;
    public Material redRunnerMat;
    public Material redBrawlerMat;
    public Material redFighterMat;
    public Material blueRunnerMat;
    public Material blueBrawlerMat;
    public Material blueFighterMat;
    public bool teamRed = false;
    public float charSpeed;
    public float charDamage;
    public float charHealth;
    public Transform forceCenter;
    public bool dead;
    public float knockbackForce = 500;
    public Transform play1Loc;
    public Transform play2Loc;
    public float deathCooldown;
    public bool respawned;
    public bool holdingObj;
    public GameObject obj;
    GameObject grab;
    bool oct;
    public GameObject objectiveSpawn;
    public ParticleSystem boom;
    public HealthAndScore HAS;
    public float movementTick;
    public float computerDecide;
    private void Start()
    {
        dead = false;
        player.freezeRotation = true;
        collie = GetComponent<Collider>();
        hitColliderRed.enabled = false;
        hitColliderBlue.enabled = false;
        meshy.enabled = false;
        meshy2.enabled = false;
        statMagnitude = 1f;
        boom.Stop();
        HAS = GameObject.Find("ScoreStatus").GetComponent<HealthAndScore>();
        //stats van elk karakter
        //Runner
        if (isRunner == true)
        {
            charHealth = 5;
            charDamage = 1f;
            charSpeed = 1;
            maxSpeed = 10f * (charSpeed);
            if (teamRed == true)
            {
                charPlane.material = redRunnerMat;
            }
            else
            {
                charPlane.material = blueRunnerMat;
            }
        }
        //Brawler
        if (isBrawler == true)
        {
            charHealth = 15;
            charDamage = 5f;
            charSpeed = 0.6f;
            maxSpeed = 10f * (charSpeed);
            if (teamRed == true)
            {
                charPlane.material = redBrawlerMat;
            }
            else
            {
                charPlane.material = blueBrawlerMat;
            }
        }
        //Fighter
        if (isFighter == true)
        {
            charHealth = 10;
            charDamage = 2f;
            charSpeed = 0.8f;
            maxSpeed = 10f * (charSpeed);
            if (teamRed == true)
            {
                charPlane.material = redFighterMat;
            }
            else
            {
                charPlane.material = blueFighterMat;
            }
        }

        //jumpheight per character
        if (isRunner == true)
        {
            jumpHeight = jumpHeight * 8;
        }
        if (isFighter == true)
        {
            jumpHeight = jumpHeight * 11;
        }
        if (isBrawler == true)
        {
            jumpHeight = jumpHeight * 9;
        }
        

    }
    public void FixedUpdate()
    {
        respawned = false;
        
        PlayCheck();
        boom.transform.position = player.position;
        //double jump charge krijg je pas als je een meter van de grond af bent
        //zodat je niet direct kan springen na je eerste sprong
        if (jumpCooldown > 0.3f)
        {
            doubleJumpAble = true;
        }
        if (jumpCooldown < 0.3f)
        {
            doubleJumpAble = false;
        }
        //slaan cooldown
        punchCooldown = (punchCooldown - 1 * Time.deltaTime);
        if (punchCooldown <= 0)
        {
            punchCooldown = 0;
        }
        if (punchCooldown == 0)
            ableToPunch = true;
        if (punchCooldown > 0)
            ableToPunch = false;

        //als cooldown van slaan nog bezig is
        if (ableToPunch == false)
        {
            hitColliderRed.enabled = false;
            hitColliderBlue.enabled = false;
            meshy.enabled = false;
            meshy2.enabled = false;
        }
        //Alle movement voor player 1
        if (player1 == true && dead == false)
        {
            PlayerOne();
        }
        //player 2
        if (player2 == true && dead == false)
        {
            PlayerTwo();
        }
        //computer player
        if (computerPlayer == true && dead == false)
        {
            ComputerPlayer();
        }
        if (dead == false)
        {
            deathCooldown = 0;
        }
        if (dead == true)
        {
            Terminated();
        }
        if (holdingObj == true)
        {
            ObjGrabbed();
        }
    }





    void PlayerOne()
    {
        player.drag = 0.1f;
        CamTrackRed();
        play1Loc = transform;
        //raycast om te checken of je op de grond staat
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1000f, LayerMask.GetMask("floors"))) { }

        //SPRINGEN
        //cooldowns op jump zodat je niet meerdere frames achter elkaar kan springen als je afzet van de grond
        if (hit.distance >= 1.05f) { jumpLoop = 7; }
        jumpLoop = (jumpLoop - 1);
        if (jumpLoop < 0) { jumpLoop = 0; }

        //double jump charge krijg je pas als je een meter van de grond af bent
        //zodat je niet direct kan springen na je eerste sprong
        if (jumpCooldown > 0.3f)
        {
            doubleJumpAble = true;
        }
        if (jumpCooldown < 0.3f)
        {
            doubleJumpAble = false;
        }

        //slaan cooldown
        punchCooldown = (punchCooldown - 1 * Time.deltaTime);
        if (punchCooldown <= 0)
        {
            punchCooldown = 0;
        }
        if (punchCooldown == 0)
            ableToPunch = true;
        if (punchCooldown > 0)
            ableToPunch = false;

        //als cooldown van slaan nog bezig is
        if (ableToPunch == false)
        {
            hitColliderRed.enabled = false;
            hitColliderBlue.enabled = false;
            meshy.enabled = false;
            meshy2.enabled = false;
        }

        //naar links kijken
        if (Input.GetKey("a"))
        {
            if (facingDirection.transform.rotation.eulerAngles.y >= 180)
            {
                facingDirection.Rotate(0, 180, 0, Space.Self);
                charPlane.transform.localScale = new Vector3(1, 1, 1);
            }

        }
        //naar rechts kijken
        if (Input.GetKey("d"))
        {
            if (facingDirection.transform.rotation.eulerAngles.y <= 180)
            {
                facingDirection.Rotate(0, 180, 0, Space.Self);
                charPlane.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        //LOPEN
        //checkt of je op de grond staat
        if (hit.distance < 1.01)
        {
            //frictie zodat je niet op ijs loopt
            collie.material.dynamicFriction = 7;
            collie.material.staticFriction = 0.1f;

            //Doublejump cooldown stopt als je op grond loopt
            //je krijgt je jump charge terug die je hebt gebruikt in de vorige jump
            jumpCooldown = 0;
            doubleJumpCharge = true;

            //lopen
            if (Input.GetKey("a"))
            {
                player.AddForce(-moveSpeed * Time.deltaTime * statMagnitude, 0, 0);
            }
            if (Input.GetKey("d"))
            {
                player.AddForce(moveSpeed * Time.deltaTime * statMagnitude, 0, 0);
            }
            //springen
            if (Input.GetKey("w"))
            {
                if (jumpLoop == 0)
                {
                    player.AddForce(player.velocity.x * 7, jumpHeight * 10 * statMagnitude, 0);
                    jumpLoop = 5;
                }

            }
            //maximale snelheid werkt alleen op de grond omdat je verticale snelheid niet moet worden gelimiteerd tijdens springen
            float tempY = player.velocity.y;
            //checkt je relatieve snelheid en limiteert deze zodat je niet oneindig accelereert
            if (player.velocity.magnitude > maxSpeed * statMagnitude)
            {
                player.velocity = player.velocity.normalized * maxSpeed * statMagnitude;
                player.velocity = new Vector3(player.velocity.x, tempY, player.velocity.z);
            }
        }


        //als je niet op de grond staat...dan zal je wel in de lucht gesprongen zijn?
        else
        {
            //frictie uit als je niet op de vloer staat zodat je nergens aan blijft kleven
            collie.material.dynamicFriction = 0;
            collie.material.staticFriction = 0;
            //extra force naar beneden
            player.AddForce(0, -1400 * Time.deltaTime, 0);

            //DOUBLE JUMP
            jumpCooldown = (jumpCooldown + 1 * Time.deltaTime);

            if (Input.GetKey("w"))
            {
                if (doubleJumpCharge == true && doubleJumpAble == true && isRunner == true)
                {
                    player.AddForce(player.velocity.x * 0.5f, jumpHeight * 10 * statMagnitude, 0);
                    doubleJumpCharge = false;
                }

            }

            //beweging in de lucht is zwakker dan gewone beweging zodat de speler nog een beetje bij kan sturen tijdens een sprong
            if (Input.GetKey("a"))
            {
                player.AddForce((-moveSpeed * Time.deltaTime * 0.07f), 0, 0);
            }
            if (Input.GetKey("d"))
            {
                player.AddForce((moveSpeed * Time.deltaTime * 0.07f), 0, 0);
            }
        }
        //als cooldown van slaan voorbij is
        if (ableToPunch == true)
        {
            if (Input.GetKey("s"))
            {
                //cooldown van slaan in seconden
                punchCooldown = 0.5f;
                //alles wat er bij slaan hoort
                if (player1 == true)
                {
                    hitColliderRed.enabled = true;
                    meshy.enabled = true;

                    //knockback mechanic
                    Collider[] colliders = Physics.OverlapSphere(hitColliderBlue.transform.position, 1f);
                    foreach (Collider contact in colliders)
                    {
                        Rigidbody rb = contact.GetComponent<Rigidbody>();

                        if (rb != null)
                        {
                            if (rb != player)
                            {
                                rb.AddExplosionForce(knockbackForce, forceCenter.position, 0, 2);
                            }
                        }
                    }
                }

            }
        }
    }


    void PlayerTwo()
    {
        player.drag = 0.1f;
        CamTrackBlue();
        play2Loc = transform;
        //raycast om te checken of je op de grond staat
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1000f, LayerMask.GetMask("floors"))) { }

        //SPRINGEN
        //cooldowns op jump zodat je niet meerdere frames achter elkaar kan springen als je afzet van de grond
        if (hit.distance >= 1.05f) { jumpLoop = 7; }
        jumpLoop = (jumpLoop - 1);
        if (jumpLoop < 0) { jumpLoop = 0; }

        //double jump charge krijg je pas als je een meter van de grond af bent
        //zodat je niet direct kan springen na je eerste sprong
        if (jumpCooldown > 0.3f)
        {
            doubleJumpAble = true;
        }
        if (jumpCooldown < 0.3f)
        {
            doubleJumpAble = false;
        }

        //slaan cooldown
        punchCooldown = (punchCooldown - 1 * Time.deltaTime);
        if (punchCooldown <= 0)
        {
            punchCooldown = 0;
        }
        if (punchCooldown == 0)
            ableToPunch = true;
        if (punchCooldown > 0)
            ableToPunch = false;

        //als cooldown van slaan nog bezig is
        if (ableToPunch == false)
        {
            hitColliderRed.enabled = false;
            hitColliderBlue.enabled = false;
            meshy.enabled = false;
            meshy2.enabled = false;
        }
        //naar links kijken
        if (Input.GetKey("left"))
        {
            if (facingDirection.transform.rotation.eulerAngles.y >= 180)
            {
                facingDirection.Rotate(0, 180, 0, Space.Self);
                charPlane.transform.localScale = new Vector3(1, 1, 1);
            }

        }
        //naar rechts kijken
        if (Input.GetKey("right"))
        {
            if (facingDirection.transform.rotation.eulerAngles.y <= 180)
            {
                facingDirection.Rotate(0, 180, 0, Space.Self);
                charPlane.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        //LOPEN
        //checkt of je op de grond staat
        if (hit.distance < 1.01)
        {
            //frictie zodat je niet op ijs loopt
            collie.material.dynamicFriction = 7;
            collie.material.staticFriction = 0.1f;

            //Doublejump cooldown stopt als je op grond loopt
            //je krijgt je jump charge terug die je hebt gebruikt in de vorige jump
            jumpCooldown = 0;
            doubleJumpCharge = true;

            //lopen
            if (Input.GetKey("left"))
            {
                player.AddForce(-moveSpeed * Time.deltaTime * statMagnitude, 0, 0);
            }
            if (Input.GetKey("right"))
            {
                player.AddForce(moveSpeed * Time.deltaTime * statMagnitude, 0, 0);
            }
            //springen
            if (Input.GetKey("up"))
            {
                if (jumpLoop == 0)
                {
                    player.AddForce(player.velocity.x * 7, jumpHeight * 10 * statMagnitude, 0);
                    jumpLoop = 5;
                }

            }
            //maximale snelheid werkt alleen op de grond omdat je verticale snelheid niet moet worden gelimiteerd tijdens springen
            float tempY = player.velocity.y;
            //checkt je relatieve snelheid en limiteert deze zodat je niet oneindig accelereert
            if (player.velocity.magnitude > maxSpeed * statMagnitude)
            {
                player.velocity = player.velocity.normalized * maxSpeed * statMagnitude;
                player.velocity = new Vector3(player.velocity.x, tempY, player.velocity.z);
            }
        }


        //als je niet op de grond staat...dan zal je wel in de lucht gesprongen zijn?
        else
        {
            //frictie uit als je niet op de vloer staat zodat je nergens aan blijft kleven
            collie.material.dynamicFriction = 0;
            collie.material.staticFriction = 0;
            //extra force naar beneden als extra zwaartekracht
            player.AddForce(0, -1400 * Time.deltaTime, 0);

            //DOUBLE JUMP
            jumpCooldown = (jumpCooldown + 1 * Time.deltaTime);

            if (Input.GetKey("up"))
            {
                if (doubleJumpCharge == true && doubleJumpAble == true && isRunner == true)
                {
                    player.AddForce(player.velocity.x * 0.5f, jumpHeight * 10 * statMagnitude, 0);
                    doubleJumpCharge = false;
                }

            }

            //beweging in de lucht is zwakker dan gewone beweging zodat de speler nog een beetje bij kan sturen tijdens een sprong
            if (Input.GetKey("left"))
            {
                player.AddForce((-moveSpeed * Time.deltaTime * 0.07f), 0, 0);
            }
            if (Input.GetKey("right"))
            {
                player.AddForce((moveSpeed * Time.deltaTime * 0.07f), 0, 0);
            }
        }
        //als cooldown van slaan voorbij is
        if (ableToPunch == true)
        {
            if (Input.GetKey("down"))
            {
                //cooldown van slaan in seconden
                punchCooldown = 0.5f;
                //alles wat er bij slaan hoort
                if (player2 == true)
                {
                    hitColliderBlue.enabled = true;
                    meshy2.enabled = true;

                    //knockback mechanic
                    Collider[] colliders = Physics.OverlapSphere(hitColliderBlue.transform.position, 1f);
                    foreach (Collider contact in colliders)
                    {
                        Rigidbody rb = contact.GetComponent<Rigidbody>();

                        if (rb != null)
                        {
                            if (rb != player)
                            {
                                rb.AddExplosionForce(knockbackForce, forceCenter.position, 0, 2);
                            }
                        }
                    }
                }
            }
        }
    }
    void ComputerPlayer()
    {
        //AI movement controller
        movementTick = (movementTick - 1 * Time.deltaTime);
        if (movementTick < 0 )
        {
            movementTick = Random.Range(0.5f, 1.5f);
            computerDecide = Random.Range(1f,2f);
        }
        if (computerDecide <= 1.5f)
        {
            computerLeft = true;
            computerRight = false;
        }

        if (computerDecide > 1.5f)
        {
            computerLeft = false;
            computerRight = true;
        }
        
        if (transform.position.x > 28f)
        {
            computerLeft = true;
            computerRight = false;
        }

        if (transform.position.x < -28f)
        {
            computerLeft = false;
            computerRight = true;
        }

        player.drag = 0.1f;
        //raycast om te checken of je op de grond staat
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1000f, LayerMask.GetMask("floors"))) { }

        //SPRINGEN
        //cooldowns op jump zodat je niet meerdere frames achter elkaar kan springen als je afzet van de grond
        if (hit.distance >= 1.05f) { jumpLoop = 7; }
        jumpLoop = (jumpLoop - 1);
        if (jumpLoop < 0) { jumpLoop = 0; }

        //double jump charge krijg je pas als je een meter van de grond af bent
        //zodat je niet direct kan springen na je eerste sprong
        if (jumpCooldown > 0.3f)
        {
            doubleJumpAble = true;
        }
        if (jumpCooldown < 0.3f)
        {
            doubleJumpAble = false;
        }

        //slaan cooldown
        punchCooldown = (punchCooldown - 1 * Time.deltaTime);
        if (punchCooldown <= 0)
        {
            punchCooldown = 0;
        }
        if (punchCooldown == 0)
            ableToPunch = true;
        if (punchCooldown > 0)
            ableToPunch = false;

        //als cooldown van slaan nog bezig is
        if (ableToPunch == false)
        {
            hitColliderRed.enabled = false;
            hitColliderBlue.enabled = false;
            meshy.enabled = false;
            meshy2.enabled = false;
        }
        //ARTIFICIAL INTELLIGENCE

        //naar links kijken
        if (computerLeft == true)
        {
            if (facingDirection.transform.rotation.eulerAngles.y >= 180)
            {
                facingDirection.Rotate(0, 180, 0, Space.Self);
                charPlane.transform.localScale = new Vector3(1, 1, 1);
            }

        }
        //naar rechts kijken
        if (computerRight == true)
        {
            if (facingDirection.transform.rotation.eulerAngles.y <= 180)
            {
                facingDirection.Rotate(0, 180, 0, Space.Self);
                charPlane.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        //LOPEN
        //checkt of je op de grond staat
        if (hit.distance < 1.01)
        {
            //frictie zodat je niet op ijs loopt
            collie.material.dynamicFriction = 7;
            collie.material.staticFriction = 0.1f;

            //Doublejump cooldown stopt als je op grond loopt
            //je krijgt je jump charge terug die je hebt gebruikt in de vorige jump
            jumpCooldown = 0;
            doubleJumpCharge = true;

            //lopen
            if (computerLeft == true)
            {
                player.AddForce(-moveSpeed * Time.deltaTime * statMagnitude, 0, 0);
            }
            if (computerRight == true)
            {
                player.AddForce(moveSpeed * Time.deltaTime * statMagnitude, 0, 0);
            }
            //springen
            if (computerJump == true)
            {
                if (jumpLoop == 0)
                {
                    player.AddForce(player.velocity.x * 7, jumpHeight * 10 * statMagnitude, 0);
                    jumpLoop = 5;
                }

            }
            //maximale snelheid werkt alleen op de grond omdat je verticale snelheid niet moet worden gelimiteerd tijdens springen
            float tempY = player.velocity.y;
            //checkt je relatieve snelheid en limiteert deze zodat je niet oneindig accelereert
            if (player.velocity.magnitude > maxSpeed * statMagnitude)
            {
                player.velocity = player.velocity.normalized * maxSpeed * statMagnitude;
                player.velocity = new Vector3(player.velocity.x, tempY, player.velocity.z);
            }
        }

        //als je niet op de grond staat...dan zal je wel in de lucht gesprongen zijn?
        else
        {
            //frictie uit als je niet op de vloer staat zodat je nergens aan blijft kleven
            collie.material.dynamicFriction = 0;
            collie.material.staticFriction = 0;
            //extra force naar beneden als BONUS zwaartekracht. DING DING DING, JUPITER MODE ENGAGED.
            player.AddForce(0, -1400 * Time.deltaTime, 0);

            //DOUBLE JUMP YEET
            jumpCooldown = (jumpCooldown + 1 * Time.deltaTime);

            if (Input.GetKey("t"))
            {
                if (doubleJumpCharge == true && doubleJumpAble == true && isRunner == true)
                {
                    player.AddForce(player.velocity.x * 0.5f, jumpHeight * 10 * statMagnitude, 0);
                    doubleJumpCharge = false;
                }
            }

            //beweging in de lucht is zwakker dan gewone beweging zodat de speler nog een beetje bij kan sturen tijdens een sprong
            if (computerLeft == true)
            {
                player.AddForce((-moveSpeed * Time.deltaTime * 0.07f), 0, 0);
            }
            if (computerRight == true)
            {
                player.AddForce((moveSpeed * Time.deltaTime * 0.07f), 0, 0);
            }
        }
    }

    public void PlayCheck()
    {
        if (player1 == false && player2 == false)
        {
            computerPlayer = true;
        }
        else
        {
            computerPlayer = false;
        }
    }

    public void Terminated()
    {
        deathCooldown += 1 * Time.deltaTime;
        player.AddForce(0, -1400 * Time.deltaTime, 0);
        collie.material.dynamicFriction = 30;
        collie.material.staticFriction = 2f;
        player.drag = 10f;

        if (teamRed == true && player1 == true)
        {
            CamTrackRed();
        }
        if (teamRed == false && player2 == true)
        {
            CamTrackBlue();
        }
        if (deathCooldown > 5)
        {  
            respawned = true;
            player.transform.position = new Vector3(0, 10, 0);
        }
        if (deathCooldown > 6)
        {
            dead = false;
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Objective" && dead == false)
        {
            Destroy(other.gameObject);
            holdingObj = true;
        }
    }
    public void ObjGrabbed()
    {
        
        statMagnitude = 0.85f;
        if (oct == false)
        {
            grab = Instantiate(obj, player.position + new Vector3(0,1,0), Quaternion.identity, player.transform);
            grab.name = "Objective";
        }
        oct = true;
        if (dead == true)
        {
            holdingObj = false;
            boom.Play();
            ObjDropped();
        }
        if (teamRed == true)
        {
            HAS.objStatRed = (HAS.objStatRed + 30 * Time.deltaTime);
        }
        else 
        {
            HAS.objStatBlue = (HAS.objStatBlue + 30 * Time.deltaTime);
        }
    }
    public void ObjDropped()
    {
        //boom.Stop();
        Destroy(grab);
        GameObject newSpawn = Instantiate(objectiveSpawn, new Vector3(Random.Range(-10f, 10f),20,0), Quaternion.identity);
        newSpawn.name = "Objective";
        statMagnitude = 1f;
        
        oct = false;
    }
    public void CamTrackRed()
    {
        GameObject.Find("CameraSmoother").GetComponent<CameraLock>().redMid = player.position;
    }
    public void CamTrackBlue()
    {
        GameObject.Find("CameraSmoother").GetComponent<CameraLock>().blueMid = player.position;
    }
}
