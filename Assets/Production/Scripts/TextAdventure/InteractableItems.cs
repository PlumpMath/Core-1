using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InteractableItems : MonoBehaviour {
	public List<InteractableObject> usableItemList;
	public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
	public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
	[HideInInspector] public List<string> nounsInRooms = new List<string>();

	Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
	List<string> noundsInInventory = new List<string>();

	[HideInInspector] public RoomNavigation roomNavigation;
	GameController controller;

	Interaction interaction;
	bool actionResult;

	//bools for space ship
	bool powerOn;
	bool teleporterOn;
	public Room[] roomToChangeTo;
	void Awake(){
		controller = GetComponent<GameController>();
		roomNavigation = GetComponent<RoomNavigation>();
		powerOn = false;
		teleporterOn = false;
	}

	public string GetObjectNotInInventory(Room currentRoom, int i){
		InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

		if(!noundsInInventory.Contains(interactableInRoom.noun)){
			nounsInRooms.Add(interactableInRoom.noun);
			return interactableInRoom.description;
		}
		return null;
	}

	public void AddActionResponesToUseDictionary(){
		for (int i = 0; i < noundsInInventory.Count; i++)
		{
			string noun = noundsInInventory[i];
			InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
			if(interactableObjectInInventory == null){
				continue;
			}
			for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
			{
				interaction = interactableObjectInInventory.interactions[j];
				if(interaction.actionResponse == null){
					continue;
				}
				foreach(ActionResponse actionResponse in interaction.actionResponse){
					if(!useDictionary.ContainsKey(noun + actionResponse.name)){
					
						useDictionary.Add(noun + actionResponse.name, actionResponse);
					}
				}
			}
		}
	}

	InteractableObject GetInteractableObjectFromUsableList(string noun){
		for (int i = 0; i < usableItemList.Count; i++)
		{
			if(usableItemList[i].noun == noun){
				return usableItemList[i];
			}
		}
		return null;
	}


	public void DisplayInventory(){
		controller.LogStringWithReturn("You look in your backback, inside you have:");
		for (int i = 0; i < noundsInInventory.Count; i++)
		{
			controller.LogStringWithReturn(noundsInInventory[i]);
			controller.ScrollToBottom();
		}
	}

	public void ClearCollections(){
		examineDictionary.Clear();
		takeDictionary.Clear();
		nounsInRooms.Clear();
	}


	public Dictionary<string, string> Take (string[] seperatedInputWords){

		string noun = seperatedInputWords[1];
		if(nounsInRooms.Contains(noun)){
			noundsInInventory.Add(noun);
			AddActionResponesToUseDictionary();
			nounsInRooms.Remove(noun);
			return takeDictionary;
		} else{
			controller.LogStringWithReturn("There is no " + noun + " here to take.");
			controller.ScrollToBottom();
			return null;
		}
	}

	public void UseItem(string[] seperatedInputWords){
		string nounToUse = seperatedInputWords[1];
		

		//add a bunch of bools to check with noun change noun
		if(roomNavigation.currentRoom.roomName == "insideship"){
			//if use item probably need to change room
			if(nounToUse == "wires"){
				itemsToUse(nounToUse);
			} else{
				itemsToUse(nounToUse);
			}
			
		} else if(roomNavigation.currentRoom.roomName == "insideshipon"){
			if(nounToUse == "button"){

				controller.roomNavigation.currentRoom = roomToChangeTo[0] ;
				controller.DisplayRoomText();
				controller.ScrollToBottom();
			}else{
				itemsToUse(nounToUse);
			}
		} else if(roomNavigation.currentRoom.roomName == "insideshippressed"){
			if(nounToUse == "circle"){
				controller.roomNavigation.currentRoom = roomToChangeTo[1] ;
				controller.DisplayRoomText();
				controller.ScrollToBottom();
			}else{
				itemsToUse(nounToUse);
			}
		} else if(roomNavigation.currentRoom.roomName == "workshop"){
			if(nounToUse == "crowbar"){
				controller.LogStringWithReturn("Hang on a tick, you have an idea.  You pull out ol' reliable and walk to the case holding the Core you bring the Crowbar down with a resounding thwack.  Your arms reverberate with the force, but the case resolutely mocks your attempts.  Guess there are some problems even crowbars cannot solve.");
		
			} else {
				itemsToUse(nounToUse);
			}
		} else if(roomNavigation.currentRoom.roomName == "coreroom"){
			if(nounToUse == "core"){
				SceneManager.LoadScene("VictoryScene", LoadSceneMode.Single);
			} else {
				itemsToUse(nounToUse);
			}
		}
		else {
			itemsToUse(nounToUse);
		}
	}

	public void itemsToUse(string nounToUse){
		if(noundsInInventory.Contains(nounToUse)){
			foreach(ActionResponse actionResponse in interaction.actionResponse){
				if(useDictionary.ContainsKey(nounToUse + actionResponse.name)){
				 	actionResult = useDictionary[nounToUse + actionResponse.name].DoActionResponse(controller);
					if (actionResult == true){
						return;
					}
				}
			}
		
			if(!actionResult){
				controller.LogStringWithReturn("hmmm, nothing happens.");
				controller.ScrollToBottom();
					 
			} else {
				controller.LogStringWithReturn("You can't use the " + nounToUse);
				controller.ScrollToBottom();
			}
			
		} else{
			controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use.");
			controller.ScrollToBottom();
		}
	}
}
