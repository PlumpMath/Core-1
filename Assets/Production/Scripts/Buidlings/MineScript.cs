using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour {
	 public ResourceBuildingScript resourceBuildingScript;

	 public Sprite[] buildings;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		resourceBuildingScript = gameObject.GetComponent<ResourceBuildingScript>();
		resourceBuildingScript.maxResource = 100;
		resourceBuildingScript.availableResource = 0;
		resourceBuildingScript.speedOfGeneration = 2f;
		resourceBuildingScript.nextGenerate = 2f;
		resourceBuildingScript.resourceGenerated = 20;

		int mineNumber = Random.Range(0, buildings.Length);
		spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = buildings[mineNumber];
	}
	
	// Update is called once per frame
	void Update () {
		resourceBuildingScript.Gather("resource", ResourcesScript.Instance.numberOfMines, ResourcesScript.Instance.resourceWorkers);
	}
}
