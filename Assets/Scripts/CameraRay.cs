using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour {

    public GameObject hitObject;
    public float rayMax = 10f;
    public bool hasObject;

    void Start()
    {
        hasObject = false;
    }

    void Update () {
        castRay();
	}

    /* this function casts a ray a specific distance from the player.
     * If it hits an object, then it attaches to the object, and moves it;
     */

    void castRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.cyan);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayMax))
        {
            hitObject = hit.transform.gameObject;
            hasObject = true;
            Debug.Log("Hit and attached");
            Debug.Log(hitObject.name);
        }
        else
        {
            hitObject = null;
            hasObject = false;
        }
    }

    /* Used for passing to behavior script */

    //public bool checkObject()
    //{
     //   return hasObject;
    //}

    public GameObject getObject()
    {
        return hitObject;
    }
}
