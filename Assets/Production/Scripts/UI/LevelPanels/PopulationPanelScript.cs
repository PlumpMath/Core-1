using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopulationPanelScript : MonoBehaviour {

	ResourcesScript script;

	public Text maxPopulation;
	public Text agricultureWorker;
	public Text resourceWorker;
	public Text researchWorker;
	public Text totalWorker;
	public Text availableworker;

	public Transform toBuildIn;
	//house stuff
	public Text numOfHouses;
	int costOfHouse;
	public Button houseBtn;
	public GameObject house;
	//hospital stuff
	public Text numOfHospitals;
	int costOfHospital;
	public Button hospitalBtn;
	public GameObject hospital;
	public AudioSource[] AudioClips;
	// Use this for initialization
	void  OnEnable() {
		costOfHouse = 200;
		costOfHospital = 800;
		script = ResourcesScript.Instance;

		//population stuff
		agricultureWorker.text = script.agricultureWorkers.ToString();
		resourceWorker.text = script.resourceWorkers.ToString();
		researchWorker.text = script.researchWorkers.ToString();

		totalWorker.text = script.totalPopulation.ToString();
		availableworker.text = script.availableworkers.ToString();

		maxPopulation.text = script.maxPopulation.ToString();

		//house stuff
		numOfHouses.text = script.numberOfHouses.ToString();

		//hospital stuff
		numOfHospitals.text = script.numberOfHospitals.ToString();

		
	}
	
	void Update(){
		availableworker.text = script.availableworkers.ToString();
		totalWorker.text = script.totalPopulation.ToString();
		if(script.resourceAvailable >= costOfHouse){
			houseBtn.interactable = true;
		} else{
			houseBtn.interactable = false;
		}
		if(script.resourceAvailable >= costOfHospital){
			hospitalBtn.interactable = true;
		} else{
			hospitalBtn.interactable = false;
		}
	}

	public void AddPerson(string type){
		if(type == "agriculture"){
			script.agricultureWorkers++;
		} else if(type == "resource"){
			script.resourceWorkers++;
		} else {
			script.researchWorkers++;
		}
        	AudioClips[0].Play();
		UpdateGUI();
	}

	public void removePerson(string type){
		if(type == "agriculture"){
			script.agricultureWorkers--;
		} else if(type == "resource"){
			script.resourceWorkers--;
		} else {
			script.researchWorkers--;
		}
        AudioClips[0].Play();
		UpdateGUI();
	}

	public void BuildHouse(){
		if( script.resourceAvailable >= costOfHouse){
			script.resourceAvailable = script.resourceAvailable - costOfHouse;
			script.numberOfHouses++;
			script.maxPopulation = script.numberOfHouses * 4;
			script.UpdateGUI();
			UpdateGUI();
		AudioClips[0].Play();
		AudioClips[1].Play();
			GameObject building =  Instantiate(house, new Vector3(-633.6107f,-321.2444f, -10f), Quaternion.Euler(0, 0, Random.Range(0, 360)));
			building.transform.SetParent(toBuildIn, false);
		}
	}

	public void BuildHospital(){
		if( script.resourceAvailable >= costOfHospital){
			script.resourceAvailable = script.resourceAvailable - costOfHospital;
			script.numberOfHospitals++;
			UpdateGUI();
			GameObject building =  Instantiate(hospital, new Vector3(-633.6107f,-321.2444f, -10f), Quaternion.Euler(0, 0, Random.Range(0, 360)));
			building.transform.SetParent(toBuildIn, false);
			AudioClips[0].Play();
		AudioClips[1].Play();
		}
	}

	public void UpdateGUI(){
		
		script.updateWorkers();
		agricultureWorker.text = script.agricultureWorkers.ToString();
		resourceWorker.text = script.resourceWorkers.ToString();
		researchWorker.text = script.researchWorkers.ToString();

		totalWorker.text = script.totalPopulation.ToString();
		availableworker.text = script.availableworkers.ToString();

		maxPopulation.text = script.maxPopulation.ToString();

		//house stuff
		numOfHouses.text = script.numberOfHouses.ToString();

		//hospital
		numOfHospitals.text = script.numberOfHospitals.ToString();
	}
}
