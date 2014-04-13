using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public Rigidbody bullet;
	float delay = 0.1f;
	float currentTime;
	// Use this for initialization

	void Start () {
		currentTime = Time.time;	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && ((Time.time - currentTime) > delay)) {
			currentTime = Time.time;
			//GameObject.Instantiate
			Vector3 spread = new Vector3(Random.value, 0, Random.value);
			Rigidbody rocketClone = (Rigidbody) Instantiate(bullet, transform.position + transform.forward, transform.rotation);
			rocketClone.velocity = transform.forward * 10;
		}
	}
}
