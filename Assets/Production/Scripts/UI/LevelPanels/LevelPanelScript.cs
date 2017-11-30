using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanelScript : MonoBehaviour {
	public GameObject[] panelList;
	
	void Start(){
		foreach(GameObject panel in panelList){
			panel.SetActive(false);
		}
		panelList[0].SetActive(true);
	}
	public void ActivatePanel(int panelIndex){
		foreach(GameObject panel in panelList){
			panel.SetActive(false);
		}
		panelList[panelIndex].SetActive(true);
	}
}
