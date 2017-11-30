using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisableAdd : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(ResourcesScript.Instance.availableworkers <= 0){
			 gameObject.GetComponent<Button>().interactable = false;
		} else {
			 gameObject.GetComponent<Button>().interactable = true;
		}
	}
}
