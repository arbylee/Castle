using UnityEngine;
using System.Collections;

public class AlternateEnemy : MonoBehaviour {
	private GameObject target;
	NavMeshAgent agent;

	void Start () {
		target = GameObject.FindWithTag ("AlternateTarget");
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		agent.SetDestination (target.transform.position);
	}
}
