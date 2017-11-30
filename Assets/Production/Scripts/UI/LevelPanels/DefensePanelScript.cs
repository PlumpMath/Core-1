using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DefensePanelScript : MonoBehaviour {
	public Text basicTowers;
	public Text advanceTowers;
	public Text amountAdvanceCanBuild;

	public Button buildButton;
	public Button upgradeButton;
	public Text buildCost;
	 int[] buildCosts = {200,500,1100, 2300,4700};

	public Text advanceCost;
	 int[] advanceCosts = {500,1300,2800, 5600,12000};
	int amountToSpend;

	int basicTowerAmount = 1;
	int advanceTowerAmount = 0;
	public GameObject[] Guns;
	public GameObject advanceMarker;
	public AudioSource[] AudioClips = null;
	void Start () {
		if(gameObject.name == "WestGunPanel"){
			basicTowerAmount = GameStats.gameStats.westDefenseBasic;
			advanceTowerAmount =  GameStats.gameStats.westDefenseAdvance;
		} else if (gameObject.name == "EastGunPanel"){
			basicTowerAmount = GameStats.gameStats.eastDefenseBasic;
			advanceTowerAmount =  GameStats.gameStats.eastDefenseAdvance;
		} else if (gameObject.name == "NorthGunPanel"){
			basicTowerAmount = GameStats.gameStats.northDefenseBasic;
			advanceTowerAmount =  GameStats.gameStats.northDefenseAdvance;
		} else {
			basicTowerAmount = GameStats.gameStats.southDefenseBasic;
			advanceTowerAmount =  GameStats.gameStats.southDefenseAdvance;
		}

        buildButton.onClick.AddListener(BuildBasicTower);
		upgradeButton.onClick.AddListener(BuildAdvanceTower);
		
		basicTowers.text = basicTowerAmount.ToString();
		advanceTowers.text = advanceTowerAmount.ToString();
		amountAdvanceCanBuild.text = basicTowers.text;
		buildCost.text = buildCosts[basicTowerAmount - 1].ToString();
		advanceCost.text = advanceCosts[advanceTowerAmount].ToString();

		for(int i = 0; i < basicTowerAmount; i++)
        {
            Guns[i].SetActive(true);
        }
	}

	void Update(){
		int amoutOfResources = ResourcesScript.Instance.resourceAvailable;

		if(buildCosts[basicTowerAmount - 1] <= amoutOfResources && basicTowerAmount < 5){
			buildButton.interactable = true;
		} else{
			buildButton.interactable = false;
		}
		if(advanceCosts[advanceTowerAmount] <= amoutOfResources && advanceTowerAmount < 5){
			upgradeButton.interactable = true;
		} else{
			upgradeButton.interactable = false;
		}
	}

	void BuildBasicTower(){
		if(basicTowerAmount < 5){
			bool built  = BuildTower(
				buildCosts[basicTowerAmount-1]
			);
			if(built == true){
				basicTowerAmount++;
				DisplayTower();
				SendData();	
				 AudioSource audio = GetComponent<AudioSource>();
        	AudioClips[0].Play();
			}
		}
	}

	void BuildAdvanceTower(){
		if(advanceTowerAmount < 5){
			bool built  = BuildTower(
				advanceCosts[advanceTowerAmount]
			);
			if(built == true){
				advanceTowerAmount++;
				Guns[advanceTowerAmount - 1].transform.Find("AdvanceMarker").gameObject.SetActive(true);
				Guns[advanceTowerAmount - 1].GetComponent<BasicGunScript>().damage = 2;
				SendData();	
				 AudioSource audio = GetComponent<AudioSource>();
        	audio.Play();
			}
		}
	}

	bool BuildTower( int towerCost){
		if (ResourcesScript.Instance.resourceAvailable >= towerCost ){
			amountToSpend = towerCost;
			return true;
		} else{
			return false;
		}	
	}

	void DisplayTower(){
		for(int i = 0; i < basicTowerAmount; i++)
        {
            Guns[i].SetActive(true);
			AudioClips[1].Play();
        }
	}

	void SendData(){
		ResourcesScript.Instance.SubtractResources(amountToSpend);
		if(gameObject.name == "WestGunPanel"){
			GameStats.gameStats.westDefenseBasic = basicTowerAmount ;
			GameStats.gameStats.westDefenseAdvance = advanceTowerAmount;
		} else if (gameObject.name == "EastGunPanel"){
			GameStats.gameStats.eastDefenseBasic = basicTowerAmount;
			GameStats.gameStats.eastDefenseAdvance = advanceTowerAmount;
		} else if (gameObject.name == "NorthGunPanel"){
			GameStats.gameStats.northDefenseBasic = basicTowerAmount;
			GameStats.gameStats.northDefenseAdvance = advanceTowerAmount;
		} else{
			GameStats.gameStats.southDefenseBasic = basicTowerAmount;
			GameStats.gameStats.southDefenseAdvance = advanceTowerAmount;
		}
		UpdateGUI();
	}
	public void UpdateGUI(){
		
			basicTowers.text = basicTowerAmount.ToString();
			advanceTowers.text = advanceTowerAmount.ToString();
			amountAdvanceCanBuild.text = basicTowers.text;
			buildCost.text = buildCosts[basicTowerAmount - 1].ToString();
			advanceCost.text = advanceCosts[advanceTowerAmount].ToString();
		
	}
}
