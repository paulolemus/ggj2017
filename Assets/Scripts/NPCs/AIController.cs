using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    public float averageSpeed = 0.4f;
    public float speedRange = 0.2f;
    public float idleProbability = 10;    // chance player is an idler, /100
    public float waveTendency = 0.25f; // chance of waving, /100
    public float stareTendency = 1;     // chance of staring /100

    public bool isPlayerStaring = false;
    public bool isPlayerWaving = false;
    public bool isPlayerFlipping = false;

    public bool waving = false;

    protected float speed;
    protected bool idler;

}
