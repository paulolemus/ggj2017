using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MurdererController : AIController {

    private GameObject player;
    private bool playerInBound;
    private bool staredTooLong;
    private bool chaseHim;
    private float chaseRadius;
    private float currSpeed;
    private float boostSpeed = 1.5f;

    private float stareTimer;
    private float stareTimeMax = 3;
    private float chaseTimer;
    private float chaseTimeMax = 30;

	// Use this for initialization
	void Start () {
        if (!idler && pathTag != null) getWP();
        idleTransform = transform;
        player = GameObject.Find("Player");
        chaseRadius = Random.Range(5, 20);
        speed = 0.6f;
        currSpeed = speed;
        staredTooLong = false;
        chaseHim = false;
        playerInBound = false;
        chaseTimer = 0;
        restlessTimer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        checkPlayerDistance();
        shouldIChase();
        chase();

        // If not chasing, then the dude may either wander or idle.
        if (!interacting) {
            if (!idler) walkAround();
            else idleAround();
        }
	}

    void walkAround()
    {
        if (path.Length > 0)
        {
            float distance = Vector3.Distance(path[currentNode].position, transform.position);
            if (distance < 0.4) { currentNode++; }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,
                                                         path[currentNode].position,
                                                         currSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      path[currentNode].rotation,
                                                      turnSpeed * Time.deltaTime);
            }
            if (currentNode >= path.Length) currentNode = 0;
        }
    }

    void idleAround()
    {
        bool xPosClose;
        bool zPosClose;
        bool yAngClose;
        xPosClose = Mathf.Abs(transform.position.x - idleTransform.position.x) < 0.2f;
        zPosClose = Mathf.Abs(transform.position.z - idleTransform.position.z) < 0.2f;
        yAngClose = Mathf.Abs(transform.rotation.y - idleTransform.rotation.y) < 0.2f;

        if (xPosClose && zPosClose && yAngClose)
        {
            //IDLE
        }
        else
        {
            restlessTimer += Time.deltaTime;

            float step = speed * Time.deltaTime;
            idleTransform.position = new Vector3(idleTransform.position.x, 
                                                 transform.position.y, 
                                                 idleTransform.position.z);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     idleTransform.position,
                                                     step);
        }

        // If resetless, teleport back and idle.
        if (restlessTimer > 30)
        {
            restlessTimer = 0;
            transform.position = idleTransform.position;
            transform.rotation = idleTransform.rotation;
        }
    }

    void shouldIChase()
    {
        if (isPlayerStaring) stareTimer += Time.deltaTime;
        if (stareTimer >= stareTimeMax) staredTooLong = true;
        if (isPlayerWaving || isPlayerFlipping) staredTooLong = true;
        if (playerInBound && staredTooLong)
        {
            chaseHim = true;
            interacting = true;
            ac.gettingAwkward(true);
        }
        else
        {
            chaseHim = false;
            ac.gettingAwkward(false);
        }
        }

    void chase()
    {
        if(chaseTimer >= chaseTimeMax)
        {
            chaseHim = false;
            interacting = false;
            staredTooLong = false;
            chaseTimer = 0;
        }
        if (chaseHim)
        {
            float straffeH = 0;

            straffeH = currSpeed * Time.deltaTime;
            transform.LookAt(player.transform);
            transform.Translate(0, 0, straffeH);
        }
    }
    void checkPlayerDistance()
    {
        if ((player.transform.position - transform.position).sqrMagnitude < chaseRadius * chaseRadius)
        {
            playerInBound = true;
        }
        else
        {
            playerInBound = false;
        }
    }
    void getWP()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag(pathTag)
               .OrderBy(gameo => gameo.name)
               .ToArray();
        path = new Transform[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            path[i] = objs[i].transform;
        }
    }
}
