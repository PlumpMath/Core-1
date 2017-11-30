using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterToContinueScript : MonoBehaviour {

	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene("MainGameScene", LoadSceneMode.Single);
		}
            
	}
}
