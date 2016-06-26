using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	private Rigidbody rb;
	private Collider col;

	void Awake() {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<Collider> ();
	}

	void OnTriggerEnter (Collider other) {
		GameObject hitTarget = other.gameObject;
		if (hitTarget.CompareTag ("Enemy")) {
			Destroy(hitTarget.gameObject);
		} else {
			this.transform.parent = other.gameObject.transform;
			Destroy (rb);
			Destroy (col);
		}
	}
}
