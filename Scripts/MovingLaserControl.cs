using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MovingLaserControl : MonoBehaviour {

	public bool instantDeath = false;
	public int damage = 10;
	[Range(0.1f, 2f)]
	public float speed = 0.8f;

	float trajectoryPosition = 0;
	float direction = 1f;
	Vector3 originPos;
	Vector3 destination;

	void Start () {
		originPos = transform.position;
		Vector3 destTrans = transform.parent.FindChild("MovementDestination").position;
		destination = new Vector3(destTrans.x, 
		                          transform.position.y, 
		                          destTrans.z);
	}
	
	void FixedUpdate () {
		Vector3 nextPos = Vector3.Lerp(originPos, destination, (trajectoryPosition / 100f));
		transform.position = new Vector3 (nextPos.x, transform.position.y, nextPos.z);
		trajectoryPosition += (direction * speed);
		if (trajectoryPosition >= 100 || trajectoryPosition <= 0) {
			direction = -direction;
		}
	}

	void OnTriggerEnter(Collider col) {
		//om lasern träffar spelaren eller en fiende
		Debug.Log("Lasers hit " + col.transform.name);
		if (col.transform.tag == "Player" || col.transform.tag == "Enemy") {
			if (instantDeath) { //om instant death, döda den träffade
				Killable target = col.GetComponent(typeof(Killable)) as Killable;
				target.kill();
			} else { //om icke instant death, get spelaren "damage" antal skada per sekund (fördröjd 0.2 sek)
				col.GetComponent<HealthControlScript>().meleeHit(damage);
			}
		}
	}

	void OnTriggerStay(Collider col) {
		//Debug.Log("Lasers hitting " + col.transform.name);
	}
}
