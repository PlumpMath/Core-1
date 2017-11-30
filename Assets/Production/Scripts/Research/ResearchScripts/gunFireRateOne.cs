using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunFireRateOne : MonoBehaviour {

	void Start () {
		ResourcesScript.Instance.upgradeGunFireRate = .5f; 	
	}
}
