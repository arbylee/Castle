using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private GameObject target;
	NavMeshAgent agent;

	void Start () {
		target = GameObject.FindWithTag ("MainTower");
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		agent.SetDestination (target.transform.position);
	}
}
