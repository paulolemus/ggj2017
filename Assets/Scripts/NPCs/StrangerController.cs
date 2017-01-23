using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StrangerController : AIController {

    private GameObject player;
    private bool staredTooLong;

    private float starTimer;
    private float starTimerMax = 6;
    private float resetTimer;


	// Use this for initialization
	void Start () {
        if (!idler && pathTag != null) getWP();
        idleTransform = transform;
        player = GameObject.Find("Player");
        speed = Random.Range(averageSpeed - speedRange, averageSpeed + speedRange);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
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
            if (distance < 0.4) { currentNode++; }
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
