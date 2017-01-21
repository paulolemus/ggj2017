using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;

	public GameObject menu_obj;

	RaycastHit hit;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update ()
	{
		if (Cursor.lockState == CursorLockMode.Locked)
			Movement ();
		if (Input.GetButtonDown ("Menu"))
			Menu ();
	}

	void FixedUpdate(){
		if (Input.GetButtonDown ("Fire1") && menu_obj.activeSelf == false) {
			if (Physics.Raycast (transform.position, transform.forward, out hit, 20))
				hit.collider.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.2f, 0.8f, 0.1f, 0.5f);
		}
		if (Input.GetButton ("Fire2"))
			GameObject.Find ("Main Camera").GetComponent<Camera> ().fieldOfView = 30f;
		else {
			GameObject.Find ("Main Camera").GetComponent<Camera> ().fieldOfView = 60f;
		}
	}

	void Movement() {
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}

	void Menu() {
		if (menu_obj.activeSelf == false) {
			menu_obj.SetActive (true);
			Cursor.lockState = CursorLockMode.None;
		} else if (menu_obj.activeSelf == true) {
			menu_obj.SetActive (false);
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
