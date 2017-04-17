using UnityEngine;
using System.Collections;

public class AlternateArrow : MonoBehaviour {
	Rigidbody rb;
	Collider col;
	GameObject explosion;
	void Awake() {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<Collider> ();
	}
	void Start(){
		explosion = GameObject.FindGameObjectWithTag ("Explosion");
	}
	void OnTriggerEnter(Collider other) {
		Instantiate (explosion, other.transform.position, Quaternion.identity);
		Destroy (other.gameObject);
	}
}
