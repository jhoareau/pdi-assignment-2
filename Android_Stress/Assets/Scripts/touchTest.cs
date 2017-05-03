using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchTest : MonoBehaviour {

	Ray ray;
	RaycastHit hit;

	public GameObject con;
	public GameObject canvas;

	private Transform levelButton;
	private int maxTargets = 5;
	private int maxDistractors = 7;
	private float timer = 0;
	private int errors = 0;
	private int correct = 0;
	private bool targetsFound = false;
	
	// Update is called once per frame
	void Update () {

		// Get controller
		control cont = con.GetComponent<control> ();

		// Activate overview canvas, when all targets are found
		if(correct == PlayerPrefs.GetInt("Targets") && !targetsFound){
			targetsFound = true;
			canvas.SetActive (true);
			CheckNextLevelConditions ();

			Transform timetext = canvas.transform.Find ("TimeText").GetChild(0);
			Transform errortext = canvas.transform.Find ("ErrorText").GetChild(0);

			timetext.GetComponent<Text>().text = timer.ToString("F2");
			errortext.GetComponent<Text>().text = errors.ToString();

			cont.moving = true;
		}

		// Count time from all movement have stopped
		if (!cont.moving && correct != PlayerPrefs.GetInt("Targets")) {
			timer += Time.deltaTime;
		}

		// Touch controls
		// * If there is a touch and the touch is the first one in its beginning phase (start of touch)
		// * then we have a touch
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			// Create ray from touch position
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

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

	// Checking after the game has been played. Maybe the level should be adjusted
	void CheckNextLevelConditions (){
		levelButton = canvas.transform.Find ("NextButton");

		// Checking timer and errors to decide if next level should be available
		if (timer < 3 && errors == 0) {
			levelButton.gameObject.SetActive (true);
			if(maxTargets >= PlayerPrefs.GetInt("Targets") + 1){
				PlayerPrefs.SetInt ("Targets", PlayerPrefs.GetInt("Targets") + 1);
			}
			if (maxDistractors >= PlayerPrefs.GetInt ("Distractors") + 1) {
				PlayerPrefs.SetInt ("Distractors", PlayerPrefs.GetInt ("Distractors") + 1);
			}
		} else if (timer < 3 && errors > 0 && PlayerPrefs.GetInt("Targets") > 1 && errors < (int)(PlayerPrefs.GetInt("Targets") / 2)) {
			levelButton.gameObject.SetActive (true);
			if(maxTargets >= PlayerPrefs.GetInt("Targets") + 1){
				PlayerPrefs.SetInt ("Targets", PlayerPrefs.GetInt("Targets") + 1);
			}
			if (maxDistractors >= PlayerPrefs.GetInt ("Distractors") + 1) {
				PlayerPrefs.SetInt ("Distractors", PlayerPrefs.GetInt ("Distractors") + 1);
			}
		}
	}
}
