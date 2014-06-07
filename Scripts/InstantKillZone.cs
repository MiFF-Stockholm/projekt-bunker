using UnityEngine;
using System.Collections;

public class InstantKillZone : MonoBehaviour {

	void Start () {

	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "Player") {
			col.GetComponent<PlayerDeath>().killPlayer();
		}
	}
}
