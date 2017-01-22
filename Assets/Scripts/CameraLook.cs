using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public GameObject player;
    public float sensitivity = 0.75f;
    public float smooth      = 4f;

    Vector2 mouseLook;
    Vector2 smoother;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cameraMovement();
	}
    
    void cameraMovement()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"),
                             Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smooth,
                                           sensitivity * smooth));
        smoother.x = Mathf.Lerp(smoother.x, md.x, 1f / smooth);
        smoother.y = Mathf.Lerp(smoother.y, md.y, 1f / smooth);
        mouseLook += smoother;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
