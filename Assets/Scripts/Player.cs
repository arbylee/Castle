using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static Player Instance { get; private set; }

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 4F;
	public float sensitivityY = 4F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;
	private Vector3 moveDirection = Vector3.zero;

	public GameObject bulletPrefab;
	public Animator crosshairAnimator;
	private Transform gunTransform;
	[HideInInspector] public float force;
	[HideInInspector] public IPlayerAttackState currentAttackState;
	[HideInInspector] public AttackChargingState attackChargingState;
	[HideInInspector] public NonAttackingState nonAttackingState;

	void Awake(){
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		attackChargingState = new AttackChargingState (Instance);
		nonAttackingState = new NonAttackingState (Instance);
		currentAttackState = nonAttackingState;
	}

	void Start() {
		Transform playerModel = transform.Find ("PlayerModel");
		gunTransform = playerModel.Find ("Gun");
	}

	void Update() {
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


		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		currentAttackState.UpdateState ();
	}

	public void ReleaseArrow(){
		GameObject bullet = Instantiate (bulletPrefab, gunTransform.position, gunTransform.rotation) as GameObject;
		Rigidbody bulletRB = bullet.GetComponentInChildren<Rigidbody> ();
		bulletRB.AddForce (gunTransform.forward * force);
		force = 0;
		bulletRB = null;
	}
}
