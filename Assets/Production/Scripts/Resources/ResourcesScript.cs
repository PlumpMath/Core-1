using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesScript : MonoBehaviour {
	public static ResourcesScript Instance {get; set;}
	//For Resource
	public Text resourceAmount;
	public int resourceAvailable;
	public int numberOfMines;
	public int numberOfGas;
	//for population
	public int maxPopulation;
	public Text workerAmount;
	public int workersAvailable;
	public int agricultureWorkers;
	public int resourceWorkers;
	public int researchWorkers;
	public int totalPopulation;
	public int availableworkers;
	public int numberOfHouses;
	public int numberOfHospitals;

	//For food
	public Text foodAmount;
	public int foodAvailable;
	public int numberOfFarms;
	
	//for upgrades
	public int upgradeEquipmentUpgrade;
	public int upgradeFirtility;
	public int upgradeGatherAmount;
	public float upgradeGatherSpeed;
	public int upgradeGunRange;
	public int upgradeGunRangeTwo;
	public float upgradeGunFireRate;
	public float upgradeGunFireRateTwo;
	public int upgradeGunDamage;

	// Use this for initialization
	void Start () {
		 if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
		//for resource
		resourceAmount.text = GameStats.gameStats.resourceAmount.ToString();
		resourceAvailable = GameStats.gameStats.resourceAmount;
		numberOfMines = 1;
		numberOfFarms = 1;
		numberOfGas = 1;

		//for people
		numberOfHouses = 5;
		numberOfHospitals = 1;
		maxPopulation = numberOfHouses * 4;
		totalPopulation = 10;
		researchWorkers = 1;
		resourceWorkers = 1;
		agricultureWorkers = 1;
		availableworkers = totalPopulation - researchWorkers - resourceWorkers - agricultureWorkers;
		
		workerAmount.text = availableworkers.ToString();

		//for food
		foodAvailable = 1000;
		foodAmount.text = foodAvailable.ToString();

		//for upgrade
		upgradeEquipmentUpgrade = 1;
		upgradeFirtility = 0;
		upgradeGatherAmount = 1;
		upgradeGatherSpeed = 0;
		upgradeGunRange = 0;
		upgradeGunRangeTwo = 0;
		upgradeGunFireRate = 0;
		upgradeGunFireRateTwo = 0;
		upgradeGunDamage = 0;
	}


	public void updateWorkers(){
		availableworkers = totalPopulation - researchWorkers - resourceWorkers - agricultureWorkers;
		UpdateGUI();
	}

	public void SubtractResources(int amount){
		 GameStats.gameStats.resourceAmount = resourceAvailable - amount;
		 resourceAvailable = GameStats.gameStats.resourceAmount;
		 UpdateGUI();
	}

	public void AddResources(int amount){
		 GameStats.gameStats.resourceAmount = resourceAvailable + amount;
		 resourceAvailable = GameStats.gameStats.resourceAmount;
		 UpdateGUI();
	}

	public void SubtractFood(int amount){
		 foodAvailable = foodAvailable - amount;
		 UpdateGUI();
	}

	public void AddFood(int amount){
		 foodAvailable = foodAvailable + amount;
		 UpdateGUI();
	}

	public void UpdateGUI(){
		
		resourceAmount.text = resourceAvailable.ToString();
		workerAmount.text = availableworkers.ToString();
		foodAmount.text = foodAvailable.ToString();
	}
}
