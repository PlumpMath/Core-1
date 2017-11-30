using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchBoxScript : MonoBehaviour {

	public Text researchName;
	public Text researchResourceCost;
	public Text researchFoodCost;
	public Text researchDescription;
	int researchFoodCostInt;
	int researchResourceCostInt;
	string researchSlug;
	public Button LearnResearch;
	public GameObject ResearhCostBox;
	public GameObject hasResearchedBox;
	public GameObject isResearching;
	public void PopulateBox( string name, int foodCost, int resourceCost, string description, string slug, bool hasResearhced){
		researchName.text = name;
		researchFoodCost.text = foodCost.ToString();
		researchResourceCost.text = resourceCost.ToString();
		researchDescription.text = description;
		researchFoodCostInt = foodCost;
		researchResourceCostInt = resourceCost;
		researchSlug = slug;
		if(hasResearhced == true){
			hasResearchedBox.SetActive(true);
			ResearhCostBox.SetActive(false);
			isResearching.SetActive(false);
		} else {
			hasResearchedBox.SetActive(false);
			ResearhCostBox.SetActive(true);
			isResearching.SetActive(false);
		}
	}

	public void ResearchItem(){
		if(ResourcesScript.Instance.foodAvailable >= researchFoodCostInt){
			if(ResourcesScript.Instance.resourceAvailable >= researchResourceCostInt){
				Research.Instance.LearnResearch(researchSlug);
				ResourcesScript.Instance.SubtractFood(researchFoodCostInt);
				ResourcesScript.Instance.SubtractResources(researchResourceCostInt);
				 AudioSource audio = GetComponent<AudioSource>();

         audio.Play(); 
			}
		}
	}

	void Update(){
		if(ResourcesScript.Instance.foodAvailable <= researchFoodCostInt || ResourcesScript.Instance.resourceAvailable <= researchResourceCostInt){
			LearnResearch.interactable = false;
		} else {
			LearnResearch.interactable = true;
		}
		if(Research.Instance.researching == true){
			hasResearchedBox.SetActive(false);
			ResearhCostBox.SetActive(false);
			isResearching.SetActive(true);
		}
	}

}
