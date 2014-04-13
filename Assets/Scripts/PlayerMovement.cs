using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	float step = 5.0f;
	float rotatespeed = 2.0f;
	public Rigidbody player;
	void Start () {
	}
	void Update () {
		bool hasMoved = false;
		if(Input.GetKey(KeyCode.W)) {
			Vector3 dir = Camera.main.transform.TransformDirection(Vector3.up);
			dir.y = 0;
			dir.Normalize();
			player.MovePosition(player.position + dir * step * Time.deltaTime);
			hasMoved = true;
		}

		if(Input.GetKey(KeyCode.S)) {
			Vector3 dir = -Camera.main.transform.TransformDirection(Vector3.up);
			dir.y = 0;
			dir.Normalize();
			player.MovePosition(player.position + dir * step * Time.deltaTime);
			hasMoved = true;
		}

		if(Input.GetKey(KeyCode.A)) {
			Vector3 dir = Camera.main.transform.TransformDirection(Vector3.left);
			dir.y = 0;
			dir.Normalize();
			player.MovePosition(player.position + dir * step * Time.deltaTime);
			hasMoved = true;
		}

		if(Input.GetKey(KeyCode.D)) {
			Vector3 dir = -Camera.main.transform.TransformDirection(Vector3.left);
			dir.y = 0;
			dir.Normalize();
			player.MovePosition(player.position + dir * step * Time.deltaTime);
			hasMoved = true;
		}
		if(hasMoved) {
			player.velocity.Set (0, 0, 0);
			hasMoved = false;
		}
	}
}
