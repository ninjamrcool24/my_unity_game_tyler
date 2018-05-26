using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentBoostPad : MonoBehaviour {

	float boostPadRotation;
	public static float BoostPadRotation = boostPadRotation;
		
	void OnTriggerEnter(Collider col){
		boostPadRotation == transform.localRotation.z;
	}
}
