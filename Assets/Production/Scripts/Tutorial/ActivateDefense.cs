using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDefense : MonoBehaviour {
	MapScrollScript mapScrollScript;
	void Start () {
		mapScrollScript = GameObject.Find("MapCycle").GetComponent<MapScrollScript>();
		mapScrollScript.TutorialChange(0);
	}

}
