using UnityEngine;
using System.Collections;

public class Fire2 : MonoBehaviour {

	public GameObject bulletPrefab;

	private const int INITIAL_VELOCITY = 2500; //hastighet på kulan, påverkar bara animation
	private const float DELAY = 0.5f; //tid mellan varje skott
	private float timeOfLastFiring; //senaste gången vapnet skjutits, används för att beräkna eldhastighet
	
	void Start () {
		timeOfLastFiring = Time.time;
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0) && ((Time.time - timeOfLastFiring) > DELAY)) {
			timeOfLastFiring = Time.time;
			fireWeapon();
		}
	}

	void fireWeapon () {
		// skapa kula 2.5 längdenheter framför karaktären, i riktning mot muspekaren, med y-offset på 3
		Vector3 spawnPos = transform.TransformPoint (Vector3.forward * 2.5f);
		spawnPos.y += 3;
		GameObject bulletClone = Instantiate(bulletPrefab, spawnPos, transform.rotation) as GameObject;
		bulletClone.GetComponent<BulletCollision> ().nameOfFirer = transform.name;
		bulletClone.rigidbody.AddForce(transform.forward * INITIAL_VELOCITY);
		//display muzzle flash
	}
}
