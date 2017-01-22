using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the player flip off and wave functions.
 * It also sets public booleans for use in the behavior controller
 */

public class PlayerStateController : MonoBehaviour {


    public GameObject waveObject;
    public GameObject flipObject;
    public bool waving      = false;
    public bool flipping    = false;
    public float actionTime = 2;
    public float speed      = 26f;

    private bool movingUp;
    private bool movingDown;
    private float timer = 0;

	void Start () {
        Debug.Log("Initial values: " + waveObject.transform.position);
        Debug.Log("Initial values: " + flipObject.transform.position);
        movingDown = false;
        movingUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(waveObject.transform.position);
        checkHands();
        updateHands();
	}

    void updateHands()
    {
        // TODO CODE TO MOVE HANDS UP AND DOWN
        if (movingUp && waving)
        {
            waveObject.transform.Translate(waveObject.transform.parent.transform.up * speed);
            if (waveObject.transform.position.y >= 90f)
            {
                movingUp = false;
            }
        }
        if (movingDown && waving)
        {
            waveObject.transform.Translate(-waveObject.transform.parent.transform.up * speed);
            if (waveObject.transform.position.y <= -130f)
            {
                movingDown = false;
                waving = false;
            }
        }

        if (movingUp && flipping)
        {
            flipObject.transform.Translate(flipObject.transform.parent.transform.up * speed);
            if (flipObject.transform.position.y >= 90f)
            {
                movingUp = false;

            }
        }
        if (movingDown && flipping)
        {
            flipObject.transform.Translate(-flipObject.transform.parent.transform.up * speed);
            if (flipObject.transform.position.y <= -130f)
            {
                movingDown = false;
                flipping = false;
            }
        }

    }

    void checkHands()
    {
        if (Input.GetMouseButtonDown(0) && !waving && !flipping)
        {
            Debug.Log("WAVING");
            timer = 0;
            waving = true;
            flipping = false;
            movingUp = true;
            movingDown = false;
        }
        else if (Input.GetMouseButtonDown(1) && !waving && !flipping)
        {
            Debug.Log("FLIPPING");
            timer = 0;
            waving = false;
            flipping = true;
            movingUp = true;
            movingDown = false;
        }

        if ((waving || flipping) && !movingUp && !movingDown)
        {
            timer += Time.deltaTime;
            if (timer >= actionTime)
            {
                movingUp = false;
                movingDown = true;
            }
        }
    }
}
