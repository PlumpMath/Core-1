using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameStats : MonoBehaviour {
	public static GameStats Instance {get; set;}
	public static GameStatsJson gameStats;
	void Awake(){
		 if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
		LoadData();
	}
	public void SaveData(){
		var outputString = JsonUtility.ToJson(gameStats);
		File.WriteAllText(Application.streamingAssetsPath + "/test.json", outputString);
	}

	public void LoadData(){
		string datajson = File.ReadAllText(Application.streamingAssetsPath + "/test.json");
		gameStats = JsonUtility.FromJson<GameStatsJson>(datajson);
	}

	public void ResetData(){
		gameStats.resourceAmount = 400;
		gameStats.westDefenseBasic = 1;
		gameStats.westDefenseBasic = 0;
	}
}
