using UnityEngine;
using System.Collections;

public class AttackChargingState : IPlayerAttackState {
	private readonly Player player;

	private float maxForce = 95f;
	private float minForce = 15f;
	private float currentForce = 15f;
	private float chargeAmount = 10f;
	private float chargeCD = 0.1f;
	private float chargeCDLeft = 0.1f;

	public AttackChargingState(Player thePlayer){
		player = thePlayer;
	}

	public void UpdateState(){
		chargeCDLeft -= Time.deltaTime;
		if(chargeCDLeft <= 0 && currentForce < maxForce){
			currentForce += chargeAmount;
			chargeCDLeft = chargeCD;
		}
		if (Input.GetButtonUp ("Fire1")) {
			player.force = currentForce;
			player.ReleaseArrow ();
			ToNonAttackingState ();
		}
	}

	public void ToAttackChargingState (){
	}

	public void ToNonAttackingState (){
		player.crosshairAnimator.SetTrigger ("ChargeEnd");
		player.currentAttackState = player.nonAttackingState;
	}

	public void OnStateEnter(){
		player.crosshairAnimator.SetTrigger ("ChargeStart");
		currentForce = minForce;
	}
}
