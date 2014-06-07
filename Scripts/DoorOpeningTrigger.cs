using UnityEngine;
using System.Collections;

public class DoorOpeningTrigger : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col) {
		//om spelaren är i dörr-triggerboxen, öppna dörren
		if (col.transform.tag == "Player") {
			animation.Play ("open");
			//spela dörröppningens ljudeffekt
		}
	}

	void OnTriggerExit(Collider col) {
		//om spelaren är utanför dörr-triggerboxen, öppna dörren
		if (col.transform.tag == "Player") {
			animation.Play ("close");
			//spela dörrstängningens ljudeffekt
		}
	}
}
