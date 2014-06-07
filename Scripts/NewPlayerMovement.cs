using UnityEngine;
using System.Collections;

//Kräver att banan har en navmesh, och att spelaren har en navmesh agent.
[RequireComponent(typeof(NavMeshAgent))]
public class NewPlayerMovement : MonoBehaviour {
	private Rigidbody player;
	private NavMeshAgent agent;
	private bool hasMoved = false;
	
	void Start () {
		agent = transform.GetComponent<NavMeshAgent>();
		player = transform.GetComponent<Rigidbody>();
	}
	
	void Update () {
		//Skapa en vector, och lägg till värden beroende av vilket håll man vi gå åt
		//att gå åt flera samtidigt (diagonellt) funkar.
		Vector3 dir = new Vector3();
		//TODO: Byt ut mot axlar
		if(Input.GetKey(KeyCode.W)) {
			dir += Camera.main.transform.TransformDirection(Vector3.up);
		}
		
		if(Input.GetKey(KeyCode.S)) {
			dir += -Camera.main.transform.TransformDirection(Vector3.up);
		}
		
		if(Input.GetKey(KeyCode.A)) {
			dir += Camera.main.transform.TransformDirection(Vector3.left);
		}
		
		if(Input.GetKey(KeyCode.D)) {
			dir += -Camera.main.transform.TransformDirection(Vector3.left);
		}
		//Sätter navmesh agentens destination till vektorn.
		//Om man inte tryckt något blir det 0, så agenten stannar.
		agent.SetDestination(player.position + dir);
	}

}
