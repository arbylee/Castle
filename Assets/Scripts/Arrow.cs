using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	private Rigidbody rb;
	private Collider col;
	private GameObject explosion;

	void Awake() {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<Collider> ();
	}

	void Start(){
		explosion = GameObject.FindGameObjectWithTag ("Explosion");
	}

	void OnTriggerEnter (Collider other) {
		GameObject hitTarget = other.gameObject;
		if (hitTarget.CompareTag ("Enemy")) {
			Destroy(hitTarget.gameObject);
			Instantiate (explosion, hitTarget.transform.position, Quaternion.identity);
		} else {
			this.transform.parent = other.gameObject.transform;
			Destroy (rb);
			Destroy (col);
		}
	}
}
