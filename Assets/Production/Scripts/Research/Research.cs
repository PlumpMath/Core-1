using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Research : MonoBehaviour {
	 public ResearchItem[] researchItem;
	public static Research Instance { get; set;}
	public ResearchJson[] research;

	public bool researching;
	public Transform newParent;
	void Awake(){
		 if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

		researching = false;

		LoadData();
	}
	
	public void LoadData(){
		string datajson = File.ReadAllText(Application.streamingAssetsPath + "/Research.json");
		//research = JsonUtility.FromJson<ResearchJson>(datajson);
		research = JsonHelper.getJsonArray<ResearchJson> (datajson);
		// Debug.Log(research[1].researchName);
		//  foreach (ResearchJson thing in research)
    	// {
		// 	Debug.Log(thing.researchName);
    	// }
	}

	public void LearnResearch(string name){
		
		researching = true;
		float finalWait = 25f - (ResourcesScript.Instance.researchWorkers * 2);
		StartCoroutine(ResearchTime(finalWait, name));
	}

	IEnumerator ResearchTime(float waitTime, string researchString)
    {
		int researchIndex = 0;
        yield return new WaitForSeconds(waitTime);
		foreach (ResearchJson thing in research)
        {
            if(thing.researchSlug == researchString)
            {
               thing.researchLearned = true;
			   GameObject finishedResearch = researchItem[researchIndex].research;
			   Instantiate(finishedResearch);
				finishedResearch.transform.SetParent(newParent);
            }
			if(thing.researchParent == researchString){
				thing.researchAvailable = true;
			}
			researchIndex++;
        }
		researching = false;
		AudioSource audio = GetComponent<AudioSource>();
         audio.Play(); 
		ResearchPanelScript.Instance.DestroySkillList();
		ResearchPanelScript.Instance.LoadResearch();
		StopCoroutine(ResearchTime(0f, "nothing"));
    }

}
