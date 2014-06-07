using UnityEngine;
using System.Collections;

public class ZombieOnSpotted : MonoBehaviour {
	private Transform player;
	private NavMeshAgent agent;
	private ZombieAnimTriggers anim;
	private ZombieStats stats;
	float delay = 1;
	float timeout = 0;
	HealthControlScript playerHealth;
	void Start () {
		foreach(GameObject go in GameObject.FindGameObjectsWithTag ("Player")) {
			if(!go.name.ToLower().Contains("clone")) {
				player = go.transform;
			}
		}
		playerHealth = player.GetComponent<HealthControlScript> ();
		agent = transform.parent.GetComponent<NavMeshAgent>();
		anim = transform.parent.GetComponent<ZombieAnimTriggers>();
		stats = transform.parent.GetComponent<ZombieStats>();
	}

	void OnEnable() {
    }

	void OnDisable() {
    }
	
	void Update() {
		//Om den här är enablad, vilket innebär att zombien ser spelaren,
		//Gå då mot spelaren.
		if(Vector3.Distance(player.position, transform.position) < 3.5f) {
			if((Time.realtimeSinceStartup - timeout) > delay) {
				timeout = Time.realtimeSinceStartup;
				playerHealth.meleeHit(stats.damage);
			}
			anim.playAttack();
			agent.Stop();
			//agent.enabled = false;
			transform.LookAt(player.position);
		} else {
			//agent.enabled = true;
			agent.SetDestination(player.position);
		}

	}
}
