using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuildingScript : MonoBehaviour {
	//for producing
	public int maxResource;
	public int availableResource;
	public float speedOfGeneration;
	public float nextGenerate;
	public int resourceGenerated;

	//for gathering
	public int baseHold;
	public int canHold;
	public float nextGather;
	public float gatherSpeed;
	public int gatheredResource;

	// Use this for initialization
	void Start () {

		
		//for gathering
		baseHold = 2;
		canHold = 2;
		nextGather = 2f;
		gatherSpeed = 2f;
		gatheredResource = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Produce();
	}

	void Produce(){
		if (Time.time > nextGenerate)
        {
			speedOfGeneration = speedOfGeneration / ResourcesScript.Instance.upgradeEquipmentUpgrade;
			 nextGenerate = Time.time + speedOfGeneration;
			if(availableResource <= maxResource){
				availableResource = availableResource + resourceGenerated;
				if(availableResource > maxResource){
					availableResource = maxResource;
				}
			}
		}
	}
	public void Gather(string resourceType, int numberOfBuildings, int numberOfWorkers){
		if (Time.time > nextGather)
        {	
			if( numberOfWorkers <= 0){
				canHold = 0;
			} else {
				canHold = ((numberOfWorkers * numberOfBuildings) * ResourcesScript.Instance.upgradeGatherAmount) + 1;
			}
			nextGather = (Time.time + gatherSpeed) - ResourcesScript.Instance.upgradeGatherSpeed;
			if(availableResource <= 0){

			} else if(availableResource <= canHold){
				gatheredResource = availableResource;
				availableResource = availableResource - gatheredResource;
				if(resourceType == "resource"){
					ResourcesScript.Instance.AddResources(gatheredResource);
				} else {
					ResourcesScript.Instance.AddFood(gatheredResource);
				}
				
			} else {
				gatheredResource = canHold;
				availableResource = availableResource - gatheredResource;
				if(resourceType == "resource"){
					ResourcesScript.Instance.AddResources(gatheredResource);
				} else {
					ResourcesScript.Instance.AddFood(gatheredResource);
				}
			}
		}
	}
}
