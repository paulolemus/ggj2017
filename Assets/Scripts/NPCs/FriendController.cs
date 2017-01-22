using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour {

    public float averageSpeed = 0.3f;
    public float speedRange   = 0.2f;
    private float speed;

	// Use this for initialization
	void Start () {
        speed = Random.Range(averageSpeed - speedRange, averageSpeed + speedRange);
	}

    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, speed* Time.deltaTime);
    }


}
