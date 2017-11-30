using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasScript : MonoBehaviour {

	public ResourceBuildingScript resourceBuildingScript;
	// Use this for initialization
	void Start () {
		resourceBuildingScript = gameObject.GetComponent<ResourceBuildingScript>();
		resourceBuildingScript.maxResource = 200;
		resourceBuildingScript.availableResource = 0;
		resourceBuildingScript.speedOfGeneration = 2f;
		resourceBuildingScript.nextGenerate = 2f;
		resourceBuildingScript.resourceGenerated = 30;
	}
	
	// Update is called once per frame
	void Update () {
		resourceBuildingScript.Gather("resource", ResourcesScript.Instance.numberOfGas, ResourcesScript.Instance.resourceWorkers);
	}
}
