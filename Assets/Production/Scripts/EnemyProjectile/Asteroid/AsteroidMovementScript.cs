using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementScript : MonoBehaviour {
	public int asteroidHealth;
	 public GameObject target; //the enemy's target
    public float moveSpeed = 3; //move speed
	 private float playerScaleX;
    private float playerScaleY;
	public float scaleDown = 1f;
	public int damage;
	private int incommingDamage;
    private Rigidbody2D rb;
	AudioSource audiosource;
	public Sprite[] asteroids;
	private SpriteRenderer spriteRenderer;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource>();
		target = GameObject.Find("World");
		rb = GetComponent<Rigidbody2D>();
		int mineNumber = Random.Range(0, asteroids.Length);
		spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = asteroids[mineNumber];
		transform.Rotate(0, 0, Random.Range(0, 360));
	}
	
	// Update is called once per frame
	void Update () {
		//move towards the player
      	transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
		  transform.Rotate(0, 0, Random.Range(1, 6));
	}
	void OnTriggerEnter2D(Collider2D other) {
		
        if (other.tag == "shot") 
        {
           other.GetComponent<fireScript>().DestroySelf();
		   incommingDamage = other.GetComponent<fireScript>().damage;
        } else if( other.tag == "Planet"){
			 other.GetComponent<LayerHealthScript>().PlanetHit(damage);
			 incommingDamage = 1;
		} else if(other.tag == "Core"){
			other.GetComponent<LayerHealthScript>().PlanetHit(damage);
			other.GetComponent<LayerHealthScript>().CoreDamage();
		} 
		else {

		}
		
        Hit(incommingDamage);	
    }
	public void Hit( int damageAmount){
		asteroidHealth = asteroidHealth - damageAmount;
		playerScaleX = gameObject.transform.localScale.x;
        playerScaleY = gameObject.transform.localScale.y;
		playerScaleX = playerScaleX - damageAmount;
        playerScaleY = playerScaleY - damageAmount;
		gameObject.transform.localScale = new Vector3(playerScaleX, playerScaleY, 1);
		damage = damage - damageAmount;
		Instantiate(explosion, transform.position, transform.rotation);
			
        	audiosource.Play();
		if(asteroidHealth <= 0 ){
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			Destroy(gameObject,.2f);	
		}
	}
}
