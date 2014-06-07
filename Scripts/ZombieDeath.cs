using UnityEngine;
using System.Collections;

public class ZombieDeath : MonoBehaviour {
	EnemyDeath death;
	AI ai;
	Rigidbody rigidbody;
	NavMeshAgent agent;
	bool hasUpdated = false;
	// Use this for initialization
	void Start () {
		death = GetComponent<EnemyDeath> ();
		ai = GetComponent<AI> ();
		rigidbody = GetComponent<Rigidbody> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (death.isDead() && !hasUpdated) {
			ai.enabled = false;
			agent.enabled = false;
			rigidbody.drag = 1;
			Vector3 randomForce = Random.onUnitSphere;
			randomForce.y = 0;
			rigidbody.AddTorque(Random.onUnitSphere * 1000);
			rigidbody.AddForceAtPosition((Vector3.up + randomForce) * 50, new Vector3(0, 4, 0));
			//rigidbody.collider = new CapsuleCollider();
			hasUpdated = true;
			return;
		}
	}
}
