using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HealthControlScript))]
[RequireComponent(typeof(EnemyDeath))]
public class TurretControl : MonoBehaviour {

	private GameObject player;
	private Color yellowishColor;
	private int distance = 35;
	private Light spotLight;
	private PlayerDeath playerDeath;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerDeath = player.GetComponent<PlayerDeath> ();
		spotLight = GetComponentInChildren<Light>();
		yellowishColor = spotLight.color;
	}

	void Update () {
		//kolla om turreten är död
		if (GetComponent<EnemyDeath>().isDead()) {
			flickerLight();
			//TODO lägg till rökeffekt, brand
		} else {
			// titta efter spelaren, men bara om spelaren lever
			if (!playerDeath.isDead() && enemySpotted ()) { // om spelaren hittas, följ spelaren med strålkastaren och skjut
				changeLampColor(Color.red);
				followPlayer();
				fireAtTarget();
			} else { // om spelaren inte hittas, ändra strålkastarens färg till gul, rotera
				changeLampColor(yellowishColor);
				transform.Rotate(Vector3.up * 35.0f * Time.deltaTime);
			}
		}
	}

	// skicka ut en ray i turretens riktning, om den träffar ett game object med namn PlayerProto, 
	// returnera true. Annars, retuerna false.
	private bool enemySpotted() {
		RaycastHit hit;
		Vector3 originPosition = transform.position;
		originPosition.y += 3.5f;
		Vector3 direction = -transform.forward.normalized;
		Debug.DrawRay(originPosition, direction * distance, Color.green);
		if (Physics.Raycast (originPosition, direction, out hit, distance)) {
			if (hit.transform.tag == "Player") { //för att anfalla fiender, lägg till: || hit.transform.tag == "Enemy" 
				return true;
			}
		}
		return false;
	}

	//byt lampans färg till den som skickas med i anropet 
	private void changeLampColor(Color newColor) {
		spotLight.color = newColor;
	}

	private void followPlayer() {
		//sätt turretens nuvarande rotation till spelarens position relativt turretens position
		transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
	}

	//variabler för flimrande strålkastare
	private float changeTime = 0f;
	void flickerLight() { //gör så att strålkastaren flimrar när turreten är död
		if (Time.time > changeTime) {
			spotLight.enabled = !spotLight.enabled;
			if (spotLight.enabled) {
				changeTime = Time.time + Random.Range(0.1f, 0.4f);
			} else {
				changeTime = Time.time + Random.Range(0.1f, 0.5f);
			}
		}
	}

	//TODO byt ut mot InvokeRepeating
	public GameObject bulletPrefab;
	private const int INITIAL_VELOCITY = 2500; //hastighet på kulan, påverkar bara animation
	private const float DELAY = 0.5f; //tid mellan varje skott
	private float timeOfLastFiring; //senaste gången vapnet skjutits, används för att beräkna eldhastighet
	private void fireAtTarget() {
		if ((Time.time - timeOfLastFiring) > DELAY) {
			timeOfLastFiring = Time.time;
			fireWeapon();
		}
	}

	void fireWeapon () {
		// skapa kula 2.5 längdenheter framför karaktären, i riktning mot muspekaren, med y-offset på 3
		Vector3 spawnPos = transform.TransformPoint (-Vector3.forward * 3f);
		spawnPos.y += 3;
		GameObject bulletClone = Instantiate(bulletPrefab, spawnPos, transform.rotation) as GameObject;
		Debug.Log ("Bullet: " + bulletClone);
		BulletCollision bulletColl = bulletClone.GetComponent<BulletCollision> ();
		bulletColl.nameOfFirer = transform.name;
		bulletColl.noPush = true;
		bulletClone.rigidbody.AddForce(-transform.forward * INITIAL_VELOCITY);
		//TODO lägg till mynningsflamma
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Detected hit with " + other.name);
	}
}
