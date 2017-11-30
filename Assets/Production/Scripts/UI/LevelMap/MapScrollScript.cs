using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScrollScript : MonoBehaviour {

	public GameObject[] menuItems;
	public GameObject activeMenuObject;
	public Button upMap,downMap;
	LevelPanelScript levelPanelScript;
	public int activeMenuIndex;

	Color activeColor = new Color(0.2F, 0.5F, 0.8F, .5f);
	Color inactiveColor = new Color(0.2F, 0.5F, 0.8F, .0f);
	// Use this for initialization
	void Start () {
		levelPanelScript = GameObject.Find("Panels").GetComponent<LevelPanelScript>();
		activeMenuIndex = 0;
		activeMenuObject = menuItems[0];
		ChangeColor();
	}
	
	public void UpMapPressed(){
		menuItems[activeMenuIndex].GetComponent<Image>().color = inactiveColor;
		activeMenuIndex--;
		if(activeMenuIndex < 0){
			activeMenuIndex = menuItems.Length - 1;
			activeMenuObject = menuItems[activeMenuIndex];
		} else {
			activeMenuObject = menuItems[activeMenuIndex];
		}
		 AudioSource audio = GetComponent<AudioSource>();
        	audio.Play();
		ChangeColor();
		SetActivePanel();
	}

	public void DownMapPressed(){
		menuItems[activeMenuIndex].GetComponent<Image>().color = inactiveColor;
		activeMenuIndex++;
		if(activeMenuIndex > menuItems.Length - 1){
			activeMenuIndex = 0;
			activeMenuObject = menuItems[activeMenuIndex];
		} else {
			activeMenuObject = menuItems[activeMenuIndex];
		}
		 AudioSource audio = GetComponent<AudioSource>();
        	audio.Play();
		ChangeColor();
		SetActivePanel();
	}

	void ChangeColor(){
		activeMenuObject.GetComponent<Image>().color = activeColor;
	}
	void SetActivePanel(){
		levelPanelScript.ActivatePanel(activeMenuIndex);
	}

	public void TutorialChange(int toChangeTo){
		menuItems[activeMenuIndex].GetComponent<Image>().color = inactiveColor;
		activeMenuIndex = toChangeTo;
		activeMenuObject = menuItems[activeMenuIndex];
		ChangeColor();
		SetActivePanel();
	}
}
