using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunDamageUp : MonoBehaviour {

	void Start () {
		ResourcesScript.Instance.upgradeGunDamage = 1;
	}
}
