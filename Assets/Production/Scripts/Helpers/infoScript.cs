using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoScript : MonoBehaviour {

	public bool infoOn;
	public GameObject infoObject;
	void Start(){
		infoOn = false;
	}

	public void ShowInfo(){
		infoOn = !infoOn;
		if(infoOn){
			infoObject.SetActive(true);
		} else{
			infoObject.SetActive(false);
		}
	}
}
