using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerPopulationScript : MonoBehaviour {
	ResourcesScript script;
 	void Start()
 	{
		script = ResourcesScript.Instance;
    	StartCoroutine(Births());
 	}
 	IEnumerator Births()
 	{
    	 while(true)
     	{
        	 checkIfBirth();
        	 yield return new WaitForSeconds(10);
     	}
 	}

	public void checkIfBirth(){
		if(script.totalPopulation >= script.maxPopulation){

		} else{
			int popProb = Random.Range(0,101);
			int numTocheck = (80 - (script.numberOfHospitals * 10)) - script.upgradeFirtility;
			if(popProb > numTocheck ){
				int born = Random.Range(1,5);
				script.totalPopulation = script.totalPopulation + born;
				script.updateWorkers();
			}
		}
	}
}
