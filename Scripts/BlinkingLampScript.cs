using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class BlinkingLampScript : MonoBehaviour {

	public float blinkIntervalInSeconds = 1;

	private Light lamp;
	private float lastBlinkTime = 0;

	void Start() {
		lamp = transform.GetComponent<Light> ();
	}
	
	void Update () {
		blink ();
	}

	void blink() {
		if (Time.time - lastBlinkTime >= blinkIntervalInSeconds) {
			lamp.enabled = !lamp.enabled;
			lastBlinkTime = Time.time;
		}
	}
}
