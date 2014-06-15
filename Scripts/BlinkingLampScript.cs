using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class BlinkingLampScript : MonoBehaviour {

	[Range(0.1f, 60f)]
	public float blinkIntervalInSeconds = 1;

	private Light lamp;

	void Start() {
		lamp = transform.GetComponent<Light> ();
		InvokeRepeating("blink", 0, blinkIntervalInSeconds);
	}
	
	void Update () {
	}

	void blink() {
		lamp.enabled = !lamp.enabled;
	}
}
