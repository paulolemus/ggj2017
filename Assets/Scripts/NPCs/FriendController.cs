using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This contains all of the behaviors for the FRIEND type.
 * 
 * We must have several booleans that will be set by the BEHAVIORCONTROLLER.
 * Behaviors:
 * Idle - chill in place
 * Walking - walk around normally
 * Wave at player - without him looking. This is rare
 * 
 * Being stared at:
 *      - Look back at player
 *      - Wave at player
 *      - Walk towards player
 *      
 * If the user successfully waves to friend, firend will approach, say hi
 * , and disappear.
 * If user flips off friend, awkwardness will go up, friend will get angry
 */

public class FriendController : AIController {

    
	// Use this for initialization
	void Start () {
        initNPC();
	}

    void FixedUpdate()
    {
        //transform.Translate(speed * Time.deltaTime, 0, speed* Time.deltaTime);
        if (isPlayerFlipping)
        {

        }
        else if (isPlayerWaving)
        {
            transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime);
        }
        else if (isPlayerStaring)
        {

        }
        else if (!idler)
        {

        }
    }

    /* Set random values for several npc characteristics
     * Are they idlers, how fast they walk, etc
     */

    void initNPC()
    {
        speed = Random.Range(averageSpeed - speedRange, averageSpeed + speedRange);
        idler = Random.Range(1, 100) < idleProbability ? true : false;
    }

}
