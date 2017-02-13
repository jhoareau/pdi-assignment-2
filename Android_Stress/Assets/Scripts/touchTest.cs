using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchTest : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	bool colorChange = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			Debug.DrawRay (ray.origin, ray.direction * 20f, Color.red);

			if (Physics.Raycast (ray,out hit,Mathf.Infinity)) {
				Debug.Log ("HIT");

				if (hit.collider.tag == "Special") {
					if (colorChange) {
						hit.transform.gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", Color.blue);
						colorChange = false;
					} else {
						hit.transform.gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red); 
						colorChange = true;
					}
				}
			}
		}
	}
}
