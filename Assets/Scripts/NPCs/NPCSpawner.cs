using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

    public GameObject nextSpawn;
    public Transform[] spawnPoints;

    public int MAX_NPCS       = 10;
    public int numberOfNPCs   = 0;
    public float friendRate   = 30;
    public float strangerRate = 55;
    public float junkieRate   = 10;
    public float murdererRate = 5;

    private enum SpawnType{FRIEND, STRANGER, JUNKIE, MURDERER};

    private SpawnType nextNPC;
    private int randomPoint;
    private float rateSum;          // Used for averages
    private float spawnTimer;       // For spawning new NPCS
    private float timer;
    private bool readyToSpawn;

	// Use this for initialization
	void Start () {
        nextNPC = SpawnType.FRIEND;
        rateSum = friendRate + strangerRate + junkieRate + murdererRate;
        spawnTimer = Random.Range(1f, 2f);
        timer = 0;
        numberOfNPCs = 0;
        readyToSpawn = false;
	}
	
	// Update is called once per frame
	void Update () {

        checkSpawnTimer();

        if (readyToSpawn)
        {
            randomPoint = Random.Range(0, spawnPoints.Length);
            nextNPC = selectSpawn();
            spawnNPC();
            numberOfNPCs++;

            timer = 0;
            spawnTimer = Random.Range(5f, 15f);
            readyToSpawn = false;
        }
	}

    void checkSpawnTimer()
    {
        if (timer < spawnTimer && numberOfNPCs <= MAX_NPCS) timer += Time.deltaTime;
        else if (timer >= spawnTimer && numberOfNPCs <= MAX_NPCS) readyToSpawn = true;
    }

    void spawnNPC()
    {
        switch (nextNPC)
        {
            case SpawnType.FRIEND:
                spawnFriend();
                Debug.Log("SPAWNED FRIEND");
                break;
            case SpawnType.STRANGER:
                spawnStranger();
                Debug.Log("SPAWNED STRANGER");
                break;
            case SpawnType.JUNKIE:
                spawnJunkie();
                Debug.Log("SPAWNED JUNKIE");
                break;
            case SpawnType.MURDERER:
                spawnMurderer();
                Debug.Log("SPAWNED MURDERER");
                break;
            default:
                break;
        }
    }

    void spawnFriend()
    {
        GameObject clone = Instantiate(nextSpawn, 
                                       spawnPoints[randomPoint].position,
                                       spawnPoints[randomPoint].rotation);
        clone.transform.parent = transform;
        clone.GetComponent<FriendController>().enabled = true;
    }
    void spawnStranger()
    {
        GameObject clone = Instantiate(nextSpawn,
                                       spawnPoints[randomPoint].position,
                                       spawnPoints[randomPoint].rotation);
        clone.transform.parent = transform;
    }
    void spawnJunkie()
    {
        GameObject clone = Instantiate(nextSpawn,
                                       spawnPoints[randomPoint].position,
                                       spawnPoints[randomPoint].rotation);
        clone.transform.parent = transform;
    }
    void spawnMurderer()
    {
        GameObject clone = Instantiate(nextSpawn,
                                       spawnPoints[randomPoint].position,
                                       spawnPoints[randomPoint].rotation);
        clone.transform.parent = transform;
        clone.GetComponent<MurdererController>().enabled = true;
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
