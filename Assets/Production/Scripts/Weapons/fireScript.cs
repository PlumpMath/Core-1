using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScript : MonoBehaviour {

 public GameObject target; 
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
	public int damage = 1;
	void Start () {
		 rb = GetComponent<Rigidbody2D>();
		  StartCoroutine(Die());
		  AudioSource audio = GetComponent<AudioSource>();
        	audio.Play();
	}
	
	public void GetTarget(GameObject item) {
		target = item;
	}
	void Update () {
		 //move towards the player
		 if(target != null){
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);	
		 } else{
			 Destroy(gameObject);
		 }
	}
	public void DestroySelf(){
		Destroy(gameObject);
	}

	IEnumerator Die(){
		yield return new WaitForSeconds(3); 
		Destroy(gameObject); 
	}
}
