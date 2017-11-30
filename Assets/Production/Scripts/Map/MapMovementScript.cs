using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovementScript : MonoBehaviour {

    // public float panSpeed = 20f;
    // public Vector2 panLimit;
    // public Camera startCamera;
    //  RaycastHit2D hit;
    //  void Start()
    // {
	// 	startCamera = Camera.main;
    // }
    // // Update is called once per frame
    // void Update()
    // {
    //     Vector2 pos = transform.position;


	// 	if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
	// 	{
	// 		startCamera.orthographicSize++;
	// 	}
	// 	else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
	// 	{
	// 		startCamera.orthographicSize--;
	// 	}

    //     if (Input.GetKey("w"))
    //     {
    //         pos.y += panSpeed * Time.deltaTime;
    //         startCamera. transform.position = new Vector2(pos.y, 0);
    //     }
    //     if (Input.GetKey("s") )
    //     {
    //         pos.y -= panSpeed * Time.deltaTime;
    //         startCamera. transform.position = new Vector2(-pos.y, 0);
    //     }
    //     if (Input.GetKey("d"))
    //     {
    //         pos.x += panSpeed * Time.deltaTime;
    //         startCamera. transform.position = new Vector2(pos.x, 0);
    //     }
    //     if (Input.GetKey("a") )
    //     {
    //         pos.x -= panSpeed * Time.deltaTime;
    //        	startCamera. transform.position = new Vector2(-pos.x, 0);
    //     }

    //     pos.x = Mathf.Clamp(pos.x, -1, 10);
    //     pos.y = Mathf.Clamp(pos.y, -2, 2);
    //     transform.position = pos;

	// 	startCamera.orthographicSize = Mathf.Clamp(startCamera.orthographicSize, 2f, 15f);
    // }
}
