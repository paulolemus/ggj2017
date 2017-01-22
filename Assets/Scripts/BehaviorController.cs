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
    private GameObject oldNPC;

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
            setIsStaredAt(true);
            setIsWavedAt();
            setIsFlippedAt();
            
        }
        else if(activeNPC != null)
        {
            setIsStaredAt(false);
            oldNPC = activeNPC;
            activeNPC = null;
        }
        
        // TODO: DO SOMETHING WITH OBJECT AND PLAYER;

	}
    void setIsStaredAt(bool b)
    {
        activeNPC.GetComponent<FriendController>().isPlayerStaring = b;
        activeNPC.GetComponent<StrangerController>().isPlayerStaring = b;
        activeNPC.GetComponent<JunkieController>().isPlayerStaring = b;
        activeNPC.GetComponent<MurdererController>().isPlayerStaring = b;
        
    }
    void setIsWavedAt()
    {
        bool b = player.GetComponent<PlayerStateController>().waving;
        activeNPC.GetComponent<FriendController>().isPlayerWaving = b;
        activeNPC.GetComponent<StrangerController>().isPlayerWaving = b;
        activeNPC.GetComponent<JunkieController>().isPlayerWaving = b;
        activeNPC.GetComponent<MurdererController>().isPlayerWaving = b;
    }
    void setIsFlippedAt()
    {
        bool b = player.GetComponent<PlayerStateController>().flipping;
        activeNPC.GetComponent<FriendController>().isPlayerFlipping = b;
        activeNPC.GetComponent<StrangerController>().isPlayerFlipping = b;
        activeNPC.GetComponent<JunkieController>().isPlayerFlipping = b;
        activeNPC.GetComponent<MurdererController>().isPlayerFlipping = b;
    }
}
