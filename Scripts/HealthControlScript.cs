using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class HealthControlScript : MonoBehaviour {

	public int healthPoints = 100;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void meleeHit(int damage) {
		if (!isDead()) {
			Debug.Log ("Took " + damage + " points of damage from melee attack");
			healthPoints -= damage;
			if (healthPoints <= 0) {
				handleDeath();
			}
		}
	}

	public void projectileHit(int damage) {
		if (!isDead()) {
			Debug.Log ("Took " + damage + " points of damage from projectile attack");
			healthPoints -= damage;
			if (healthPoints <= 0) {
				handleDeath();
			}
		}
	}

	private void handleDeath() {
		Killable target = GetComponent( typeof(Killable) ) as Killable;
		target.kill();

//		if (transform.tag == "Player") { //hantera spelarens död
//			GetComponent<PlayerDeath>().killPlayer();
//		} else { //hantera fiendes död
//			GetComponent<EnemyDeath>().killEnemy();
//		}
	}

	private bool isDead() {
		Killable target = GetComponent( typeof(Killable) ) as Killable;
		return target.isDead();

//		if (transform.tag == "Player") {
//			return GetComponent<PlayerDeath>().isDead;
//		} else {
//			return GetComponent<EnemyDeath>().isDead;
//		}
	}
}
