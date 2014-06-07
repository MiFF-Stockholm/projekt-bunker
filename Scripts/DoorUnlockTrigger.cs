using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DoorUnlockTrigger : MonoBehaviour {

	public GameObject doorKey = null;

	private Light lockLight;
	private bool isOpen = false;
	private Animation doorAnim;

	void Start () {
		doorAnim = transform.parent.animation;
		lockLight = transform.parent.FindChild ("lockLight").GetComponent<Light> ();
	}
	
	void Update () {
		if (doorKey == null) {
				lockLight.color = Color.green;
		} else {
			DoorKeyScript script = (DoorKeyScript)doorKey.GetComponent ("DoorKeyScript");
			if (script.pickedUp) {
				lockLight.color = Color.green;
			}
		}
	}

	private bool ifKeyExistsAndIsPickedUp() {
		if (doorKey == null) { //om det inte finns en nyckel, öppna alltid
			return true;
		}
		DoorKeyScript script = (DoorKeyScript)doorKey.GetComponent ("DoorKeyScript");
		//om dörren är enabled och nyckelns script har pickedUp = true, returnera true
		return doorKey.activeSelf == true && script.pickedUp;
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "Player" && ifKeyExistsAndIsPickedUp()) {
			isOpen = true;
			doorAnim.Play ("open");
			audio.Play();
		}
	}
	
	void OnTriggerExit(Collider col) {
		if (col.transform.tag == "Player" && isOpen == true) {
			isOpen = false;
			doorAnim.Play ("close");
			audio.Play();
		}
	}
}
