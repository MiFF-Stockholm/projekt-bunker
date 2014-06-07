using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DoorActivationTrigger : MonoBehaviour {

	public bool autoClose = false;

	private bool isOpen = false;
	private bool playerInTheZone = false;
	private Animation doorAnim;

	void Start () {
		doorAnim = transform.parent.animation;
	}
	
	void Update () {
		if (playerInTheZone && Input.GetKeyUp(KeyCode.E) && !isOpen) {
			//om spelaren är i triggerboxen och trycker E och dörren är stängd, öppna dörren
			isOpen = true;
			doorAnim.Play ("open");
			audio.Play();
		} else if (playerInTheZone && Input.GetKeyUp(KeyCode.E) && isOpen) {
			//om spelaren är i triggerboxen och trycker E och dörren är öppen, stäng dörren
			isOpen = false;
			doorAnim.Play ("close");
			audio.Play();
		}
	}

	void OnTriggerEnter(Collider col) { //denna funktion körs när spelaren går in i dörrens trigger
		Debug.Log ("Entered door zone");
		if (col.transform.tag == "Player") {
			playerInTheZone = true;
		}
	}
	
	void OnTriggerExit(Collider col) { //denna funktion körs när spelaren går ut ur dörrens trigger
		Debug.Log ("Exited door zone");
		if (col.transform.tag == "Player") {
			if (isOpen && autoClose) { //stäng dörren om autoClose = true
				isOpen = false;
				doorAnim.Play ("close");
				audio.Play();
			}
			playerInTheZone = false;
		}
	}
}
