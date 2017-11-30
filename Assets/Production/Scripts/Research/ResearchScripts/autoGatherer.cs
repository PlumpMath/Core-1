using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoGatherer : MonoBehaviour {

	public int maxResource;
	public int availableResource;
	public float speedOfGeneration;
	public float nextGenerate;
	public int resourceGenerated;
	void Start(){
		nextGenerate = 2f;
		speedOfGeneration = 2f;
	}
	// Update is called once per frame
	void Update () {
		
	}
	void Produce(){
		if (Time.time > nextGenerate)
        {
			 nextGenerate = Time.time + speedOfGeneration;
				ResourcesScript.Instance.AddResources(30);
				ResourcesScript.Instance.AddFood(30);
		}
	}
}
