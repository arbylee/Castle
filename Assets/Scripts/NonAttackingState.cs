using UnityEngine;
using System.Collections;

public class NonAttackingState : IPlayerAttackState {
	private readonly Player player;
	private float reloadTime = 0.5f;
	private float reloadTimeLeft = 0f;

	public NonAttackingState(Player thePlayer){
		player = thePlayer;
	}
	public void UpdateState(){
		reloadTimeLeft -= Time.deltaTime;
		if (reloadTimeLeft <= 0 && Input.GetButtonDown ("Fire1")) {
			ToAttackChargingState ();
			reloadTimeLeft = reloadTime;
		}
	}
	public void ToAttackChargingState (){
		player.currentAttackState = player.attackChargingState;
		player.attackChargingState.OnStateEnter ();
	}
	public void ToNonAttackingState (){
	}
}
