using UnityEngine;
using System.Collections;

public class ActivationAreaTriggerScript : MonoBehaviour {
	
	public bool isActivated = false;
	public bool needsKeyPress = false;

	private bool playerInTheZone = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (needsKeyPress) {
			if (playerInTheZone && Input.GetKeyUp (KeyCode.E) && !isActivated) {
				isActivated = true;
				Debug.Log ("Activated");
			} else if (playerInTheZone && Input.GetKeyUp (KeyCode.E) && isActivated) {
				isActivated = false;
				Debug.Log ("Deactivated");
			}
		}
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "Player") {
			if (!needsKeyPress && !isActivated) {
				isActivated = true;
				Debug.Log ("Activated");
			}
			playerInTheZone = true;
		}
	}
	
	void OnTriggerExit(Collider col) {
		if (col.transform.tag == "Player") {
			playerInTheZone = false;
		}
	}
}
