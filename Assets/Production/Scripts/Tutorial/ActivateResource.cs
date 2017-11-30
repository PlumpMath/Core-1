using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateResource : MonoBehaviour {

	MapScrollScript mapScrollScript;
	void Start () {
		mapScrollScript = GameObject.Find("MapCycle").GetComponent<MapScrollScript>();
		mapScrollScript.TutorialChange(1);
	}
}
