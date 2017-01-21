using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

    public GameObject friend;
    public GameObject stranger;
    public GameObject junkie;
    public GameObject murderer;

    public int MAX_NPCS       = 10;
    public float friendRate   = 30;
    public float strangerRate = 55;
    public float junkieRate   = 10;
    public float murdererRate = 5;

    private enum SpawnType{FRIEND, STRANGER, JUNKIE, MURDERER};

    private SpawnType nextNPC;
    private float rateSum;          // Used for averages
    private float spawnTimer;       // For spawning new NPCS
    private bool readyToSpawn;

	// Use this for initialization
	void Start () {
        nextNPC = SpawnType.FRIEND;
        rateSum = friendRate + strangerRate + junkieRate + murdererRate;
        spawnTimer = Random.Range(0f, 10f);
        readyToSpawn = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (readyToSpawn)
        {
            nextNPC = selectSpawn();
            spawnNPC();
        }
	}

    void spawnNPC()
    {
        switch (nextNPC)
        {
            case SpawnType.FRIEND:
                
                break;
            case SpawnType.STRANGER:

                break;
            case SpawnType.JUNKIE:

                break;
            case SpawnType.MURDERER:
                break;
            default:

                break;
        }
    }

    SpawnType selectSpawn()
    {
        float choice = Random.Range(1f, rateSum);
        if (choice <= friendRate)
        {
            return SpawnType.FRIEND;
        }
        else if (choice > friendRate && choice <= (friendRate + strangerRate))
        {
            return SpawnType.STRANGER;
        }
        else if (choice > friendRate + strangerRate && choice <= (rateSum - murdererRate))
        {
            return SpawnType.JUNKIE;
        }
        else if (choice > (rateSum - murdererRate)) 
        {
            return SpawnType.MURDERER;
        }
        else
        {
            return SpawnType.FRIEND;
        }
    }
}
