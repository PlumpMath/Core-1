using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchPanelScript : MonoBehaviour {
	Research script;
	public static ResearchPanelScript Instance { get; set;}

    public RectTransform scrollViewContent;
    //get skill container
	public GameObject researchBox;
    ResearchBoxScript researchBoxScript;
	
	// Use this for initialization
	void Start () {
		script = Research.Instance;
		 if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
		LoadResearch();
	}

	public void LoadResearch(){
		foreach (ResearchJson thing in script.research)
    	{
			if(thing.researchAvailable == true){
				GameObject clone = Instantiate(researchBox);
				researchBoxScript = clone.GetComponent<ResearchBoxScript>();
				researchBoxScript.PopulateBox(thing.researchName,thing.researchFoodCost, thing.researchResourceCost, thing.researchDescription, thing.researchSlug, thing.researchLearned);
				clone.transform.SetParent(scrollViewContent, false);
			}
    	}
	}
	 public void DestroySkillList()
    {
        foreach (Transform child in scrollViewContent)
        {
            Destroy(child.gameObject);
        }
    }
}
