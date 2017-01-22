using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        if (!idler && pathTag != null) getWP();
        idleTransform = transform;
        speed = Random.Range(averageSpeed - speedRange, averageSpeed + speedRange);
    }

    void FixedUpdate()
    {

        // friend behaviors

        // If not activated by player, act normally
        if (true) // Not interacting
        {
            if (!idler) walkAround();
            else idleAround();
        }
    }

    void walkAround()
    {
        if (path.Length > 0)
        {
            float distance = Vector3.Distance(path[currentNode].position, transform.position);
            if (distance < 0.4) { currentNode++; Debug.Log("Selecteed Next Node"); }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, 
                                                         path[currentNode].position, 
                                                         speed * Time.deltaTime);
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
