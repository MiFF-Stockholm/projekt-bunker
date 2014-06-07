using UnityEngine;
using System.Collections;

public class ZombieAnimTriggers : MonoBehaviour {

	private NavMeshAgent agent;
	private EnemyDeath enemyDeath;
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		enemyDeath = GetComponent<EnemyDeath> ();
	}

	void Update () {
		if(!enemyDeath.isDead()) {
			if(agent.velocity.magnitude > 0) {
				playAnimationState(CharacterState.run);
			} else {
				playAnimationState(CharacterState.idle);
			}
		} else {
			animation.Stop();
		}
	}

	public void playAttack() {
		playAnimationState (CharacterState.meleeAttack);
	}

	public enum CharacterState {
		idle,
		run,
		meleeAttack
	}
	
	void playAnimationState(CharacterState animState) {
		switch(animState) {
			case CharacterState.idle:
				animation.CrossFade("idle");
				break;
				
			case CharacterState.run:
				animation.wrapMode = WrapMode.Loop;
				animation.Play("RUn");
				break;

			case CharacterState.meleeAttack:
				animation.wrapMode = WrapMode.Once;
				animation.Play("Atack", PlayMode.StopAll);
				break;
		}
	}
}
