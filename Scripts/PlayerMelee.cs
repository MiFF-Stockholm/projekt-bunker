using UnityEngine;
using System.Collections;

public class PlayerMelee : MonoBehaviour {

	void Start() {
		
	}
	
	void Update() {
		if(Input.GetButtonDown("Fire2")) {
			doPlayerMeleeAttack();
		}

	}

	public void doPlayerMeleeAttack() {
		//skjuter en ray framför spelaren
		RaycastHit hit;
		Vector3 direction = transform.forward.normalized;
		Vector3 originPosition = transform.position;
		originPosition.y += 3;
		float distance = 3.5f;
		Debug.DrawRay(originPosition, direction * distance, Color.green);
		if (Physics.Raycast (originPosition, direction, out hit, distance)) {
			Debug.Log ("Melee attack hit: " + hit.transform.name);
			if (hit.transform.tag == "Enemy") {
				//wait for animation to finish (somehow)
				Debug.Log("Enemy hit!");
				HealthControlScript enemy = hit.transform.GetComponent<HealthControlScript>();
				enemy.meleeHit(getWeaponDamage());
			}
		}
	}

	int getWeaponDamage() {
		//byt ut mot spelarens nuvarande närstridsvapens skada
		return 10;
	}
}
