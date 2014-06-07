//movment controler for player carakter and blend betvin animations.

using UnityEngine;
using System.Collections;

//forses this komponents onto the objekt the skript is atatcht to.
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HealthControlScript))]
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerControlScript : MonoBehaviour {

	public float speed = 12;

	[System.NonSerialized]
	public float animSpeed = 1.5f;

	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	private NavMeshAgent agent;
	private AnimatorStateInfo layer2CurrentState;
	private PlayerDeath death;
	private AudioSource footStepAudio;

	static int reloadState = Animator.StringToHash("Layer2.Reload");
	static int shootWeaponState = Animator.StringToHash("Layer2.Shoot");
	static int switchWeaponState = Animator.StringToHash("Layer2.SwitchWeapon");
	
	void Start() {
		agent = transform.GetComponent<NavMeshAgent>();
		death = GetComponent<PlayerDeath> ();
		anim = GetComponent<Animator>();
		if (anim.layerCount ==2) {
			anim.SetLayerWeight(1,1);
		}
		footStepAudio = transform.Find ("FootstepAudio").GetComponent<AudioSource> ();
	}

	void OnAnimatorMove() {	//tells Unity that root motion is handled by the script
		if (anim) {
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

			float dot = -Vector3.Dot(dir, transform.forward);
			anim.SetFloat ("Speed", -dot);
			Vector3 cross = Vector3.Cross (dir, transform.forward);
			anim.SetFloat ("Direction", -cross.y);
			Vector3 newPosition = transform.position + dir;
			agent.SetDestination(newPosition);
			agent.speed = speed * ((1-Mathf.Abs(cross.y)/2.0f) + 0.5f);
		}
	}

	void Update() {
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		if (currentBaseState.IsName("RunFwd") 
		    || currentBaseState.IsName("RunBekw") 
		    || currentBaseState.IsName("Strafe_L") 
		    || currentBaseState.IsName("Strafe_R")) {
			if (!footStepAudio.isPlaying) {
				footStepAudio.Play();
				Debug.Log("Playing footsteps");
			}
		} else {
			if (footStepAudio.isPlaying) {
				footStepAudio.Stop();
				Debug.Log("Stopping footsteps");
			}
		}

		if(death.isDead()) {
			anim.SetBool("dead", true);
			anim.SetFloat ("Speed", 0);
			anim.SetFloat ("Direction", 0);
		}
		if(anim.layerCount == 2) {
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);
		}

		if(Input.GetButtonDown("Fire1")) {
			anim.SetBool("firing", true);
		} else if (Input.GetButtonUp("Fire1")) {
			anim.SetBool("firing", false);
		}

		if(Input.GetButtonDown("Fire2")) {
			anim.SetBool("melee", true);
		} else if (Input.GetButtonUp("Fire1")) {
			anim.SetBool("melee", false);
		}

		if (Input.GetButtonDown("Reload")) {
			anim.SetBool("Reloading", true);
		} else if (Input.GetButtonUp("Reload")) {
			anim.SetBool("Reloading", false);
		}

		if (Input.GetButtonDown("Switch")) {
			anim.SetBool("SwitchWeapon", true);
		} else if (Input.GetButtonUp("Switch")) {
			anim.SetBool("SwitchWeapon", false);
		}
	}
}
