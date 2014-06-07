using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float step = 5.0f;
	public float rotatespeed = 2.0f;
	public Rigidbody player;

	private bool hasMoved = false;

	void Start () {

	}

	void Update () {
		if(Input.GetKey(KeyCode.W)) {
			Vector3 dir = Camera.main.transform.TransformDirection(Vector3.up);
			movePlayerInDir(dir);
		}

		if(Input.GetKey(KeyCode.S)) {
			Vector3 dir = -Camera.main.transform.TransformDirection(Vector3.up);
			movePlayerInDir(dir);
		}

		if(Input.GetKey(KeyCode.A)) {
			Vector3 dir = Camera.main.transform.TransformDirection(Vector3.left);
			movePlayerInDir(dir);
		}

		if(Input.GetKey(KeyCode.D)) {
			Vector3 dir = -Camera.main.transform.TransformDirection(Vector3.left);
			movePlayerInDir(dir);
		}

		if(hasMoved) {
			player.velocity.Set (0, 0, 0);
			hasMoved = false;
		}
	}

	private void movePlayerInDir(Vector3 dir) {
		dir.y = 0;
		dir.Normalize();
		player.MovePosition(player.position + dir * step * Time.deltaTime);
		hasMoved = true;
	}

	public void teleportPlayerToPos(Vector3 pos) {
		player.transform.position = pos;
	}
}
