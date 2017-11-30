using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IsEndOfTextScript : MonoBehaviour {
	public GameObject enterToContinue;
	void OnBecameVisible() {
		enterToContinue.SetActive(true);
        Debug.Log("Good to go");
    }
 
    public float startTime = 0f;
    public float holdTime = 5.0f; // 5 seconds
 
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
                SceneManager.LoadScene("MainGameScene", LoadSceneMode.Single);
        }
    }
}
