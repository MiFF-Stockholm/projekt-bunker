using UnityEngine;
//Den här klassen är tagen från angrybots, och behöver förhoppnings inte ändras på.
[RequireComponent(typeof(EnemyDeath))]
[RequireComponent(typeof(HealthControlScript))]
public class AI : MonoBehaviour {
	// Public member data
	public MonoBehaviour behaviourOnSpotted;
	public AudioClip soundOnSpotted = null;
	public MonoBehaviour behaviourOnLostTrack;

	// Private memeber data
	private Transform player;
	private EnemyDeath enemyDeath;
	void Start () {
		behaviourOnSpotted.enabled = false;
		behaviourOnLostTrack.enabled = true;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag ("Player")) {
			if(!go.name.ToLower().Contains("clone")) {
				player = go.transform;
			}
		}

		enemyDeath = GetComponent<EnemyDeath> ();
	}
	// Update is called once per frame
	void Update() {
		if (enemyDeath.isDead()) {
			return;
		}
		if (CanSeePlayer ()) {
			Debug.Log("Can see player");
			OnSpotted ();
		} else {
			Debug.Log("Cannot see player");
			OnLostTrack ();
		}
	}


	void OnDisable() {
		behaviourOnSpotted.enabled = false;
		behaviourOnLostTrack.enabled = false;
	}

	void OnSpotted () {
		if (!behaviourOnSpotted.enabled) {
			behaviourOnSpotted.enabled = true;
			behaviourOnLostTrack.enabled = false;
			
			if (audio && soundOnSpotted) {
				audio.clip = soundOnSpotted;
				audio.Play ();
			}
		}
	}

	void OnLostTrack () {
		if (!behaviourOnLostTrack.enabled) {
			behaviourOnSpotted.enabled = false;
			behaviourOnLostTrack.enabled = true;
		}
	}

	bool CanSeePlayer() {
		Vector3 playerDirection = (player.position - transform.position);
		Vector3 origin = transform.position;
		origin.y = 2;
		RaycastHit hit = new RaycastHit ();
		Physics.Raycast (origin, playerDirection, out hit, playerDirection.magnitude);
		Debug.DrawRay (origin, playerDirection);
		if (hit.collider) {
			Debug.Log(hit.collider.name);
		}
		if (hit.collider && hit.collider.transform == player) {
			return true;
		}
		return false;
	}
}
