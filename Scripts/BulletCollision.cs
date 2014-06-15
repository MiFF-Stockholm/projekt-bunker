using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	public int damage = 10; //sätt variablen vid avfyrning, beroende på vapen som används
	public string nameOfFirer = "PlayerProto"; //sätt variablen vid avfyrning, beroende på vem som skjuter
	public bool noPush = false;

	void Start () {

	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (!other.gameObject.layer.Equals(LayerMask.NameToLayer("Ignore Raycast"))) {
			Debug.Log ("Bullet hit " + other.name); //skriv ut namnet på objektet kulan träffar
			//lägg in eventuella blodspår/explosioner/kulhål här (använd other.transform.position )
			if (other.tag == "Enemy" || other.tag == "Player") {
				other.GetComponent<HealthControlScript>().projectileHit(damage);
				if (noPush == false) {
					other.GetComponent<Rigidbody>().AddForceAtPosition((transform.position - other.transform.position) * 100, transform.position);
				}
			}
			Destroy(gameObject); //förstör kulan efter träff
		}
    }
}
