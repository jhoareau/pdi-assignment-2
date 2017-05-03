using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
	public GameObject target;
	public GameObject distractor;
	public bool moving = true;

	private int amount = 1;
	private int distractors = 3;
	private bool spawned = false;
	private bool spawning = false;
	private bool stopmovement = true;
	private bool fading = false;

	// Use this for initialization
	void Start ()
	{
		// Get amount of targets and distractors
		amount = PlayerPrefs.GetInt ("Targets");
		distractors = PlayerPrefs.GetInt ("Distractors");

		// Get movement script and set controller for it
		movement mm = target.GetComponent<movement> ();
		mm.SetController (this.gameObject);

		// Array to keep track of targets
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Special");

		// Launch all targets
		for (int i = 0; i < amount; i++) {
			Vector3 pos = new Vector3 (Random.Range(-13,13), Random.Range(-5,5), -2f);
			// Loop to check if spawning inside other object
			bool free = false;
			while (!free) {
				bool check = true;
				foreach (GameObject t in targets) {
					if (Vector3.Distance (t.transform.position, pos) < 4) {
						pos = new Vector3 (Random.Range (-13, 13), Random.Range (-5, 5), -2f);
						check = false;
						break;
					}
				}
				if (check)
					free = true;
			}

			// Spawn target
			Instantiate (target, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
			targets = GameObject.FindGameObjectsWithTag("Special");
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

		// Arrays to keep track of targets and distractors
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Special");
		GameObject[] dists = GameObject.FindGameObjectsWithTag ("Distractor");

		// Launch all distractors
		for (int i = 0; i < distractors; i++) {
			Vector3 pos = new Vector3 (Random.Range(-13,13), Random.Range(-5,5), -2f);

			// Loops to check if spawning is happening inside another object
			bool free = false;
			while (!free) {
				bool check = true;
				foreach (GameObject t in targets) {
					if (Vector3.Distance (t.transform.position, pos) < 4) {
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

			// Instantiate distractor and set color alpha to 0. 
			GameObject ob = Instantiate (distractor, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
			Color color  = ob.GetComponent<Renderer> ().material.color;
			color.a = 0;
			ob.GetComponent<Renderer> ().material.color = color;
			dists = GameObject.FindGameObjectsWithTag ("Distractor");
		}

		spawning = true;
		fading = true;
		StartCoroutine (FadeIn());
	}

	// Control fading-in of distractors
	IEnumerator FadeIn(){
		GameObject[] dists = GameObject.FindGameObjectsWithTag ("Distractor");
		if (fading) {
			for (float j = 0; j <= 1; j += Time.deltaTime) {
				for (int i = 0; i < dists.Length; i++) {
					Color color  = dists [i].GetComponent<Renderer> ().material.color;
					color.a = j;
					dists [i].GetComponent<Renderer> ().material.color = color;
				}
				if (j >= 1)
					fading = false;
				yield return null;
			}
		}
	}

	// Stop all movement after 4 seconds
	IEnumerator StopMovement ()
	{
		yield return new WaitForSeconds (4);
		moving = false;
	}
}
	