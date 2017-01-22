using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class will always have the player and the object the player is looking at.
 * Depending on what the situation is, this will change variables in the object
 * to make it behave a certain way.
 */

public class BehaviorController : MonoBehaviour {

    public CameraRay  rayScript;
    public GameObject player;
    public GameObject activeNPC;

    private bool hasObject;

	// Use this for initialization
	void Start () {
        hasObject = false;
	}
	
	// Update is called once per frame
	void Update () {
        hasObject = rayScript.hasObject;
        if (hasObject)
        {
            activeNPC = rayScript.hitObject;
        }
        else
        {
            activeNPC = null;
        }


        // TODO: DO SOMETHING WITH OBJECT AND PLAYER;
	}
}
