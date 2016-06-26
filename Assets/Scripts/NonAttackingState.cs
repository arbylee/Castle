using UnityEngine;
using System.Collections;

public class NonAttackingState : IPlayerAttackState {
	private readonly Player player;

	public NonAttackingState(Player thePlayer){
		player = thePlayer;
	}
	public void UpdateState(){
		if (Input.GetButtonDown ("Fire1")) {
			ToAttackChargingState ();
		}
	}
	public void ToAttackChargingState (){
		player.currentAttackState = player.attackChargingState;
		player.attackChargingState.OnStateEnter ();
	}
	public void ToNonAttackingState (){
	}
}
