using UnityEngine;
using System.Collections;

public class AlternatePlayer : MonoBehaviour {
	private Vector3 moveDirection = Vector3.zero;
	private float speed = 6.0F;
	private float jumpSpeed = 8.0F;
	private float gravity = 20.0F;
	public float sensitivityX = 4F;
	public float sensitivityY = 4F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationX = 0F;
	float rotationY = 0F;

	public GameObject arrowGO;
	void Awake() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		rotationX += Input.GetAxis ("Mouse X");
		rotationY += Input.GetAxis ("Mouse Y");
//		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
//
//		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
//
//		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
//		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
//
//		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
//
//		CharacterController controller = GetComponent<CharacterController>();
//		if (controller.isGrounded) {
//			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//			moveDirection = transform.TransformDirection(moveDirection);
//			moveDirection *= speed;
//			if (Input.GetButton("Jump"))
//				moveDirection.y = jumpSpeed;
//
//		}
//		if (Input.GetButton ("Fire1")) {
//			FireArrow ();
//		}
//		moveDirection.y -= gravity * Time.deltaTime;
//		controller.Move(moveDirection * Time.deltaTime);
	}

	void FireArrow(){
		Vector3 spawnPosition = new Vector3 (this.transform.position.x + 0.8f, this.transform.position.y, this.transform.position.z);
		GameObject arrow = Instantiate (arrowGO, spawnPosition, this.transform.rotation) as GameObject;

		Rigidbody arrowRB = arrow.GetComponent<Rigidbody> ();
		arrowRB.AddForce (this.transform.forward * 900f);
	}
}
