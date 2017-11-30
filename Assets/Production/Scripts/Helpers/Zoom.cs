using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zoom : MonoBehaviour {
	public GameObject zoomIn;
	public GameObject zoomOut;
	 Camera m_MainCamera;
	// Use this for initialization
	void Start () {
		m_MainCamera = Camera.main;
		zoomOut.SetActive(false);
	}
	
	public void ZoomInCamera(){
		m_MainCamera.transform.position = new Vector3(1.3f, 0, -100);
		m_MainCamera.orthographicSize = 4;
		zoomOut.SetActive(true);
		zoomIn.SetActive(false);
	}

	public void ZoomOutCamera(){
		m_MainCamera.transform.position = new Vector3(6.5f, 0, -100);
		m_MainCamera.orthographicSize = 18;
		zoomIn.SetActive(true);
		zoomOut.SetActive(false);
	}
}
