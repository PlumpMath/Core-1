using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour {
	public Sprite[] homes;
	private SpriteRenderer spriteRenderer;

	void Start () {
		int mineNumber = Random.Range(0, homes.Length);
		spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = homes[mineNumber];
	}
	

}
