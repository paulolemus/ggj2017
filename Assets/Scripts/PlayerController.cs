using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed        = 0.1f;
    // public float angularSpeed = 8f;
    // public float maxSpeed     = 25f;
    //Rigidbody rb;


	void Start () {
        Cursor.lockState = CursorLockMode.Locked;   // Make cursor invisible
        //rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
	}

    void FixedUpdate()
    {
        float straffeH  = 0;
        float straffeV  = 0;

        // WASD CONTROL
        straffeH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        straffeV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
        transform.Translate(straffeH, 0, straffeV);
    }
}
