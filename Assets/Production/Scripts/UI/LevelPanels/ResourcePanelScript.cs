using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResourcePanelScript : MonoBehaviour {

	ResourcesScript script;

	public string item;
	public Text nameOfItem;
	public Text numOfItems;
	public int costOfItem;
	public Text costOfItemText;
	public Button buildItem;

	public GameObject itemObject;

	public Transform toBuildIn;
	public AudioSource[] AudioClips = null;
	void Start () {
		script = ResourcesScript.Instance;
		
		nameOfItem.text = item;
		costOfItemText.text = costOfItem.ToString();
		if(item == "Mines"){

			numOfItems.text = script.numberOfMines.ToString();
		} else if (item == "Farms"){
			numOfItems.text = script.numberOfFarms.ToString();
		} 
		else {
			numOfItems.text = script.numberOfGas.ToString();
		}
	}
	
	void Update(){
		if(script.resourceAvailable >= costOfItem){
			buildItem.interactable = true;
		} else {
			buildItem.interactable = false;
		}
	}

	public void BuildItem(){
		if(script.resourceAvailable >= costOfItem){
			if(item == "Mines"){
				script.numberOfMines++;
			} else if (item == "Farms"){
				script.numberOfFarms++;
			} else {
				script.numberOfGas++;
			}
			AudioClips[0].Play();
			PlaceItem();
			script.resourceAvailable = script.resourceAvailable - costOfItem;
			script.UpdateGUI();
			UpdateGUI();

		}
	}

	public void PlaceItem(){
		GameObject building =  Instantiate(itemObject, new Vector3(-633.6107f,-321.2444f, -10f), Quaternion.Euler(0, 0, Random.Range(0, 360)));
		building.transform.SetParent(toBuildIn, false);
		 AudioClips[1].Play();
	}

	void UpdateGUI(){
		if(item == "Mines"){
			numOfItems.text = script.numberOfMines.ToString();
		} else if(item == "Farms"){
			numOfItems.text = script.numberOfFarms.ToString();
		} else {
			numOfItems.text = script.numberOfGas.ToString();
		}
	}
}
