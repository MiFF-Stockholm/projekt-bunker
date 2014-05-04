using UnityEngine;
using System.Collections;

public class LookAtCursor2 : MonoBehaviour
{

	void Start () {
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Vector3 targetPos;

		if (Physics.Raycast(ray, out hit, 100)) {
			if (hit.collider.gameObject.tag == "Terrain") {
				Debug.DrawRay(transform.position, transform.position, Color.red);
			}     
		}

		//check for dead zone
		float distanceBetweenPlayerAndMouse = Vector3.Distance(transform.position, hit.point);
		if (distanceBetweenPlayerAndMouse < 3f) {
			return;
		}

		targetPos = hit.point;
		targetPos.y = (float)(transform.position.y); //default +1.3
		targetPos.z -= 1;
	
		transform.LookAt (targetPos);
	}
}
