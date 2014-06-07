using UnityEngine;
using System.Collections;

public class DoorKeyScript : MonoBehaviour {

	public bool pickedUp = false;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		//om spelaren är i triggerområdet för nyckeln, gör nyckeln osynlig och sätt pickedUp = true
		if (col.transform.tag == "Player") {
			renderer.enabled = false;
			light.enabled = false;
			pickedUp = true;
		}
	}
}
