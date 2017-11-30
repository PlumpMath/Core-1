using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScript : MonoBehaviour {
 public ResourceBuildingScript resourceBuildingScript;
	// Use this for initialization
	void Start () {
		resourceBuildingScript = gameObject.GetComponent<ResourceBuildingScript>();
		resourceBuildingScript.maxResource = 100;
		resourceBuildingScript.availableResource = 0;
		resourceBuildingScript.speedOfGeneration = 2f;
		resourceBuildingScript.nextGenerate = 2f;
		resourceBuildingScript.resourceGenerated = 20;

	}
	
	// Update is called once per frame
	void Update () {
		resourceBuildingScript.Gather("food", ResourcesScript.Instance.numberOfFarms, ResourcesScript.Instance.agricultureWorkers);
	}
}
