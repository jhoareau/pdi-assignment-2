using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchTest : MonoBehaviour {

	Ray ray;
	RaycastHit hit;

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
					hit.transform.gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", Color.green);
				}
				if (hit.collider.tag == "Dsitractor") {
					hit.transform.gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
				}
			}
		}
	}
}
