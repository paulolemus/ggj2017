using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;   // Make cursor invisible
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
