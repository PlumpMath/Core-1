using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerHealthScript : MonoBehaviour {
	public int heatlth;
	Color[] colors = {Color.yellow, Color.red};
	Color fullColor;
	public GameObject gameOver;
	void Start(){
		fullColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	public void PlanetHit(int damage){
		heatlth = heatlth - damage;
		if(heatlth == 3){
			gameObject.GetComponent<SpriteRenderer>().color = fullColor;
		}
		else if(heatlth == 2 ){
			gameObject.GetComponent<SpriteRenderer>().color = colors[0];
		} else if(heatlth == 1){
			gameObject.GetComponent<SpriteRenderer>().color = colors[1];
		} else{
			gameObject.SetActive(false);
		}
	}
	public void CoreDamage(){
		if(heatlth <= 0){
			gameOver.SetActive(true);
		}
	}
}
