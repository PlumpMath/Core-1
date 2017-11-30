using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour {
	public GameObject StepHolder;
	public GameObject[] steps;
	public int currentStep;
	public GameObject next;
	public GameObject finish;
	ProjectileSpawnerScript projectileSpawnerScript;
	void Start(){
		finish.SetActive(false);
		currentStep = 0;
		steps[currentStep].SetActive(true);
	}

	public void NextStep(){
		steps[currentStep].SetActive(false);
		currentStep++;
		 AudioSource audio = GetComponent<AudioSource>();
        	audio.Play();
		if(currentStep < steps.Length - 1){
			steps[currentStep].SetActive(true);
		} else if (currentStep == steps.Length -1) {
			steps[currentStep].SetActive(true);
			next.SetActive(false);
			finish.SetActive(true);
		} else {
			StartEnemies();
		}
	}

	public void SkipSteps(){
		 AudioSource audio = GetComponent<AudioSource>();
        	audio.Play();
		StartEnemies();
	}

	public void StartEnemies(){
		StepHolder.SetActive(false);
		projectileSpawnerScript = GameObject.Find("Main Camera").GetComponent<ProjectileSpawnerScript>();
		projectileSpawnerScript.StartGame();
	}

}
