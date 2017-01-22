using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurdererController : AIController {

    private GameObject player;
    private bool playerInBound;
    private bool staredTooLong;
    private bool chaseHim;
    private float chaseRadius;
    private float currSpeed;
    private float boostSpeed = 2f;

    private float stareTimer;
    private float stareTimeMax = 3;
    private float chaseTimer;
    private float chaseTimeMax = 30;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        chaseRadius = Random.Range(5, 20);
        speed = 0.75f;
        currSpeed = speed;
        staredTooLong = false;
        chaseHim = false;
        playerInBound = false;
        chaseTimer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        checkPlayerDistance();
        shouldIChase();
        chase();

        // If not chasing, then the dude may either wander or idle.

        if (!idler) walkAround();
        else idleForABit();
	}

    void walkAround()
    {

    }

    void idleForABit()
    {

    }

    void shouldIChase()
    {
        if (isPlayerStaring) stareTimer += Time.deltaTime;
        if (stareTimer >= stareTimeMax) staredTooLong = true;
        if (isPlayerWaving || isPlayerFlipping) staredTooLong = true;
        if (playerInBound && staredTooLong)
        {
            chaseHim = true;
        }
        else chaseHim = false;
    }

    void chase()
    {
        if(chaseTimer >= chaseTimeMax)
        {
            chaseHim = false;
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
}
