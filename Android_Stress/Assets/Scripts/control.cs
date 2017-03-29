using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

	public GameObject special;
	public GameObject distractor;

	private int amount = 1;
	private int distractors = 3;
	public bool moving = true;

	bool spawned = false;
	bool spawning = false;
	bool stopmovement = true;


	// Use this for initialization
	void Start ()
	{
		// Get amount of targets and distractors
		amount = PlayerPrefs.GetInt ("Targets");
		distractors = PlayerPrefs.GetInt ("Distractors");

		// Get movement script and set controller for it
		movement mm = special.GetComponent<movement> ();
		mm.SetController (this.gameObject);

		// Array to keep track of specials
		GameObject[] specials = GameObject.FindGameObjectsWithTag("Special");

		// Launch all targets (specials)
		for (int i = 0; i < amount; i++) {
			Vector3 pos = new Vector3 (Random.Range(-13,13), Random.Range(-5,5), -2f);

			// Loop to check if spawning inside other object
			bool free = false;
			while (!free) {
				bool check = true;
				foreach (GameObject sp in specials) {
					if (Vector3.Distance (sp.transform.position, pos) < 4) {
						pos = new Vector3 (Random.Range (-13, 13), Random.Range (-5, 5), -2f);
						check = false;
						break;
					}
				}
				if (check)
					free = true;
			}

			Instantiate (special, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
			specials = GameObject.FindGameObjectsWithTag("Special");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		// Spawn distractors
		if (!spawned) {
			StartCoroutine (ActivateDistractors ());
			spawned = true;
		}

		// Stop all movement
		if (spawning && stopmovement) {
			StartCoroutine (StopMovement ());
			stopmovement = false;
		}
			
	}

	// Launch Distractors after 3 seconds
	IEnumerator ActivateDistractors ()
	{
		yield return new WaitForSeconds (3);

		// attach movement to controller
		movement mm = distractor.GetComponent<movement> ();
		mm.SetController (this.gameObject);

		// Arrays ti 
		GameObject[] specials = GameObject.FindGameObjectsWithTag("Special");
		GameObject[] dists = GameObject.FindGameObjectsWithTag ("Distractor");

		for (int i = 0; i < distractors; i++) {
			Vector3 pos = new Vector3 (Random.Range(-13,13), Random.Range(-5,5), -2f);

			// Loops to check if spawning is happening inside another object
			bool free = false;
			while (!free) {
				bool check = true;
				foreach (GameObject sp in specials) {
					if (Vector3.Distance (sp.transform.position, pos) < 4) {
						pos = new Vector3 (Random.Range (-13, 13), Random.Range (-5, 5), -2f);
						check = false;
						break;
					}
				}
				foreach (GameObject dis in dists) {
					if (Vector3.Distance (dis.transform.position, pos) < 4) {
						pos = new Vector3 (Random.Range (-13, 13), Random.Range (-5, 5), -2f);
						check = false;
						break;
					}
				}

				if (check)
					free = true;
			}

			Instantiate (distractor, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
			dists = GameObject.FindGameObjectsWithTag ("Distractor");
		}

		spawning = true;
	}

	// Stop all movement after 4 seconds
	IEnumerator StopMovement ()
	{
		yield return new WaitForSeconds (4);

		moving = false;
	}
}
	