using System.Collections;
using System.Collections.Generic;
//using Tobii.EyeTracking;
using UnityEngine;

//[RequireComponent(typeof(GazeAware))]
public class SpinOnGaze : MonoBehaviour {

    //private GazeAware _gazeAware;
    private ParticleSystem _particles;

	// Use this for initialization
	void Start () {
        //_gazeAware = GetComponent<GazeAware>();
        _particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))  //_gazeAware.HasGazeFocus)
        {
            transform.Rotate(Vector3.forward);
            _particles.Play();
        }
        else
        {
            _particles.Stop();
        }
	}
}
