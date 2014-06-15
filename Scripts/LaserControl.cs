using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LaserControl : MonoBehaviour {

	public bool instantDeath = false;
	public int damage = 10;

	HealthControlScript collidee;

	void Start () {
	}
	
	void Update () {
	}

	void OnTriggerEnter(Collider col) {
		//om lasern träffar spelaren eller en fiende
		if (col.transform.tag == "Player" || col.transform.tag == "Enemy") {
			if (instantDeath) { //om instant death, döda den träffade
				Killable target = col.GetComponent(typeof(Killable)) as Killable;
				target.kill();
			} else { //om icke instant death, ge spelaren "damage" antal skada per sekund (fördröjd 0.2 sek)
				collidee = col.GetComponent<HealthControlScript>();
				InvokeRepeating ("takeLaserDamage", 0.2f, 1f);
			}
		}
	}

	void OnTriggerStay(Collider col) {
	}

	void takeLaserDamage() {
		collidee.meleeHit(damage);
	}

	void OnTriggerExit(Collider col) {
		if (col.transform.tag == "Player" || col.transform.tag == "Enemy") {
			CancelInvoke ();
		}
	}
}
