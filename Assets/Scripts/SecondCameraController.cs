using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraController : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.LookAt(target);
	}
}
