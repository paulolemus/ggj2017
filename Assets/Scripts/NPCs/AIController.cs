using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    [HideInInspector]
    public Transform idleTransform;       // initial pos and rot
    [HideInInspector]
    public Transform[] path;              // If not idle, they can follow a path
    public string pathTag;

    public float averageSpeed = 0.9f;
    public float speedRange = 0.2f;       // random variation
    public float turnSpeed = 4f;
    public float idleProbability = 10;    // chance player is an idler, /100
    public float waveTendency = 0.25f;    // chance of waving, /100
    public float stareTendency = 1;       // chance of staring /100

    public bool idler = false;                    // Set by player if player will chill in spawn
    protected float restlessTimer;        // Used if the player has a hard time getting to normal conditions

    [HideInInspector]
    public bool isPlayerStaring = false;  // set by BehaviorController on player action
    [HideInInspector]
    public bool isPlayerWaving = false;   // same
    [HideInInspector]
    public bool isPlayerFlipping = false; // same

    [HideInInspector]
    public bool waving = false;

    protected float speed;
    protected int currentNode = 0;

}
