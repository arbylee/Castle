using UnityEngine;
using System.Collections;

public interface IPlayerAttackState {
	void UpdateState();
	void ToAttackChargingState ();
	void ToNonAttackingState ();
}
