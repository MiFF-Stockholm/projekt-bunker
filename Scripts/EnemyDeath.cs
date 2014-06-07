using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour, AssemblyCSharp.Killable {

	public bool dead = false;

	void Start() {

	}

	void Update() {

	}

	// Anropa denna metod om du vill döda spelaren direkt
	public void killEnemy() {
		dead = true;
		Debug.Log("Enemy killed");
	}

	public void kill() {
		killEnemy();
	}

	public bool isDead() {
		return dead;
	}
}

