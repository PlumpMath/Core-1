using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Help")]
public class Help : InputAction {
	public override void RespondToInput(GameController controller, string[] seperatedInputWords){
		controller.LogStringWithReturn("Below is a list of words you can use to make your way through the core. Use them with words surrounded by - - to perform the action.");
		controller.LogStringWithReturn(" Go, Take, Use, Examine");
		controller.LogStringWithReturn(" You can also view your inventory using inventory.");
	}
}