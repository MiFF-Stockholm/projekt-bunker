using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour, AssemblyCSharp.Killable {

	public bool dead = false;
	private float respawnCountDownDone;
	private const float RESPAWN_COUNTDOWN_SEC = 5;
	private GUIText deathMsg;
	private NavMeshAgent agent;

	void Start () {
		deathMsg = GameObject.Find ("MidScreenText").GetComponent<GUIText> ();
		agent = GameObject.FindGameObjectWithTag ("Player").GetComponent<NavMeshAgent> ();
	}
	
	void Update () {
		if (dead) {
			if (Time.time > respawnCountDownDone) {
				hideDeathMessage();
				respawnPlayer();
			}
		}
	}

	private void playDeathAnimation() {
		Debug.Log ("Playing death animation");
	}

	private void showDeathMessage() {
		deathMsg.text = "Game Over";
		deathMsg.color = Color.red;
		deathMsg.enabled = true;
	}

	private void hideDeathMessage() {
		deathMsg.text = "...";
		deathMsg.color = Color.white;
		deathMsg.enabled = false;
	}

	// Anropa denna metod om du vill döda spelaren direkt
	public void killPlayer() {
		showDeathMessage ();
		respawnCountDownDone = Time.time + RESPAWN_COUNTDOWN_SEC;
		dead = true;
		playDeathAnimation();
	}

	public void kill() {
		killPlayer ();
	}

	public bool isDead() {
		return dead;
	}
	
	// Anropa denna metod om du vill respawna spelaren i startzone kuben
	public void respawnPlayer() {
		dead = false;
		//reload level
		//Application.LoadLevel(Application.loadedLevelName);
		Vector3 startZonePos = GameObject.Find ("StartZone").renderer.bounds.center;

		startZonePos = new Vector3 (startZonePos.x, agent.transform.position.y, startZonePos.z);
		agent.Warp(startZonePos);
	}
}
