using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisableSubtract : MonoBehaviour {

	public string type;
	public int typeAmount;
	// Use this for initialization
	void Start () {
		if( type == "agriculture"){
			typeAmount = ResourcesScript.Instance.agricultureWorkers;
		} else if(type == "research"){
			typeAmount = ResourcesScript.Instance.researchWorkers;
		} else {
			typeAmount = ResourcesScript.Instance.resourceWorkers;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if( type == "agriculture"){
			typeAmount = ResourcesScript.Instance.agricultureWorkers;
		} else if(type == "research"){
			typeAmount = ResourcesScript.Instance.researchWorkers;
		} else {
			typeAmount = ResourcesScript.Instance.resourceWorkers;
		}
		if(typeAmount > 0){
			 gameObject.GetComponent<Button>().interactable = true;
		} else {
			gameObject.GetComponent<Button>().interactable = false;
		}
	}
}
