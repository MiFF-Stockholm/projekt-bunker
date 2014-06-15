using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public bool lookAtPlayer = true;

	Transform target;

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update () {
		if (lookAtPlayer) {
			transform.position = new Vector3(target.position.x + 5, transform.position.y, target.position.z + 5);
			transform.LookAt(target);
		}
	}
}

