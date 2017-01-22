using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurdererController : AIController {

    private GameObject player;
    private bool playerInBound;
    private float chaseRadius;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        chaseRadius = Random.Range(5, 20);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        checkPlayerDistance();

		
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
