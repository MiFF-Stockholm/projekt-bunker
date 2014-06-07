using UnityEngine;
using System.Collections;

public class startZoneScript : MonoBehaviour {
	
	void Start () {
		//TODO ta bort denna och använd kamerafilter
		renderer.enabled = false;
		GameObject.Find ("StartZoneText").GetComponent<Renderer> ().enabled = false;
	}

	void Update () {

	}
}
