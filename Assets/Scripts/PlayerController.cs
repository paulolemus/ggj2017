using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    private float sprintSpeed = 4f;
    private float currSpeed;
    
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;   // Make cursor invisible
        currSpeed = speed;
    }
	
	void Update () {
    }

    void FixedUpdate()
    {
        
        float straffeH  = 0;
        float straffeV  = 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currSpeed = speed;
        }

        // WASD CONTROL
        straffeH = Input.GetAxis("Horizontal") * currSpeed * Time.deltaTime;
        straffeV = Input.GetAxis("Vertical") * currSpeed * Time.deltaTime;
        
        transform.Translate(straffeH, 0, straffeV);
    }
}
