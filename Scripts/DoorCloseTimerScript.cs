using UnityEngine;
using System.Collections;

public class DoorCloseTimerScript : MonoBehaviour {
	public float timeToCloseInSeconds = 5f;

	private Animation doorAnim;
	private Light doorLamp;
	private bool isOpen = false;
	private bool playerInTheZone = false;
	private AudioSource doorAudio;

	void Start () {
		//spara animationen och ljuset här för att spara tid
		doorAnim = transform.parent.transform.parent.animation;
		doorLamp = transform.parent.transform.parent.FindChild ("DoorActiveLight").GetComponent<Light> ();
		doorAudio = transform.parent.transform.parent.FindChild ("DoorSound").GetComponent<AudioSource> ();
	}
	
	void Update () {
		//om spelaren är i triggerboxen och trycker E och dörren är stängd, öppna dörren
		if (!isOpen && playerInTheZone && Input.GetKeyUp(KeyCode.E)) {
			doorAnim.Play ("open");
			doorAudio.Play();
			isOpen = true;
			doorLamp.color = Color.green;
		}
		//om dörren är öppen och inga animationer spelas
		if (isOpen && !doorAnim.isPlaying) {
			Debug.Log("Timed door closing...");
			AnimationState state = doorAnim["close"];
			state.speed = 0.1f;
			doorAnim.Play("close");
			doorAudio.Play();
			isOpen = false;
		}
	}
	
	void OnTriggerEnter(Collider col) { //denna funktion körs när spelaren går in i dörrens trigger
		if (col.transform.tag == "Player") {
			Debug.Log ("Entered door zone");
			playerInTheZone = true;
		}
	}
	
	void OnTriggerExit(Collider col) { //denna funktion körs när spelaren går ut ur dörrens trigger
		if (col.transform.tag == "Player") {
			Debug.Log ("Exited door zone");
			playerInTheZone = false;
		}
	}
}

