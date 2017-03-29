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
	
	// Update is called once per frame
	void Update () {

		// Get controller
		control cont = con.GetComponent<control> ();

		// Activate overview canvas, when all targets are found
		if(correct == PlayerPrefs.GetInt("Targets")){
			canvas.SetActive (true);

			Transform timetext = canvas.transform.Find ("TimeText").GetChild(0);
			Transform errortext = canvas.transform.Find ("ErrorText").GetChild(0);

			timetext.GetComponent<Text>().text = timer.ToString("F2");
			errortext.GetComponent<Text>().text = errors.ToString();

			cont.moving = true;
		}

		// Count time from all movement have stopped
		if (!cont.moving && correct != PlayerPrefs.GetInt("Targets")) {
			timer += 1 * Time.deltaTime;
		}

		// Touch controls
		// * If there is a touch and the touch is the first one in its beginning phase (start of touch)
		// * then we have a touch
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			// Create ray from touch position
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			Debug.DrawRay (ray.origin, ray.direction * 20f, Color.red);

			// Cast ray and react if all movement have stopped
			if (Physics.Raycast (ray,out hit,Mathf.Infinity) && !cont.moving) {
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
