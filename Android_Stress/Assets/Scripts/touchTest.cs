using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchTest : MonoBehaviour {

	Ray ray;
	RaycastHit hit;

	public GameObject con;
	public GameObject canvas;

	float timer = 0;
	int errors = 0;
	int correct = 0;

	// Use this for initialization
	void Start () {
		canvas.active = false;
	}
	
	// Update is called once per frame
	void Update () {

		control cont = con.GetComponent<control> ();

		if(correct == cont.amount){
			canvas.active = true;

			Transform timetext = canvas.transform.Find ("TimeText").GetChild(0);
			Transform errortext = canvas.transform.Find ("ErrorText").GetChild(0);

			timetext.GetComponent<Text>().text = timer.ToString("F2");
			errortext.GetComponent<Text>().text = errors.ToString();

			cont.moving = true;
		}


		if (!cont.moving && correct != cont.amount) {
			timer += 1 * Time.deltaTime;
			Debug.Log ("time: " + timer);
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			Debug.DrawRay (ray.origin, ray.direction * 20f, Color.red);

			if (Physics.Raycast (ray,out hit,Mathf.Infinity) && !cont.moving) {
				Debug.Log ("HIT");

				if (hit.collider.tag == "Special") {
					hit.transform.gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", Color.green);
					correct += 1;
				}
				if (hit.collider.tag == "Distractor") {
					hit.transform.gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
					errors += 1;
				}
			}
		}
	}
}
