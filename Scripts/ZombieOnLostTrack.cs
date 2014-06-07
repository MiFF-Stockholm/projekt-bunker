using UnityEngine;
using System.Collections;

public class ZombieOnLostTrack : MonoBehaviour {
	private NavMeshAgent agent;
	float delay = 0;
	float timeout = 0;
	
	void Start () {
		agent = transform.parent.GetComponent<NavMeshAgent>();
	}

	void OnEnable() {
    }

	void OnDisable() {
    }

	void Update() {
		//Om tiden har gått ut
		if((Time.realtimeSinceStartup - timeout) > delay) {
			timeout = Time.realtimeSinceStartup;
			//Vänta mellan 0 till 3 sekunder tills du rör dig nästa gång
			delay = Random.value * 3;
			//Stå och häng 25% av gångerna
			if(Random.value < 0.25) {
				return;
			}
			//Eller gå någon annanstans (inom 10 enheter av nuvarande position).
			agent.SetDestination(transform.position + Random.insideUnitSphere * 10f);
		}
	}
}