using UnityEngine;
using System.Collections;

public class KlaxonScript : MonoBehaviour {

	[Range(1f, 500f)]
	public float rotationSpeed = 350f;

	void Start () {
	
	}

	void Update () {
		transform.Rotate(Vector3.up * 350.0f * Time.deltaTime);
	}
}
