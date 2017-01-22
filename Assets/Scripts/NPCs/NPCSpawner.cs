using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will handle cycling through all of the npcs
 * and sets their type and materials
 */

public class NPCSpawner : MonoBehaviour {

    public GameObject[] npcList;
    public Material[] randomMaterials;

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
        rateSum = friendRate + strangerRate + junkieRate + murdererRate;

        for (int i = 0; i < npcList.Length; i++)
        {
            nextNPC = selectSpawn();
            selectType(i);
        }
        selectMaterial();
	}
	
	// Update is called once per frame
	void Update () {
	}


    void selectType(int i)
    {
        switch (nextNPC)
        {
            case SpawnType.FRIEND:
                spawnFriend(i);
                break;
            case SpawnType.STRANGER:
                spawnStranger(i);
                break;
            case SpawnType.JUNKIE:
                spawnJunkie(i);
                break;
            case SpawnType.MURDERER:
                spawnMurderer(i);
                break;
            default:
                spawnFriend(i);
                break;
        }
    }

    void spawnFriend(int i)
    {
        npcList[i].GetComponent<FriendController>().enabled = true;
    }
    void spawnStranger(int i)
    {
        npcList[i].GetComponent<StrangerController>().enabled = true;
    }
    void spawnJunkie(int i)
    {
        npcList[i].GetComponent<JunkieController>().enabled = true;
    }
    void spawnMurderer(int i)
    {
        npcList[i].GetComponent<MurdererController>().enabled = true;
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

    void selectMaterial()
    {
        foreach(GameObject npc in npcList)
        {
            npc.GetComponent<Renderer>().material = randomMaterials[Random.Range(0, randomMaterials.Length)];
        }
    }
}
