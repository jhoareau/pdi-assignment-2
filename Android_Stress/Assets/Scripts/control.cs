﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

	public GameObject special;
	public GameObject distractor;

	public int amount = 1;
	public bool moving = true;

	bool spawned = false;
	bool spawning = false;
	bool stopmovement = true;


	// Use this for initialization
	void Start ()
	{
		movement mm = special.GetComponent<movement> ();
		mm.SetController (this.gameObject);

		for (int i = 0; i < amount; i++) {
			Vector3 pos = new Vector3 (Random.Range(-13,13), Random.Range(-5,5), -2f);
			Instantiate (special, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		Debug.Log ("Moving: " + moving);

		if (!spawned) {
			StartCoroutine (ActivateDistractors ());
			spawned = true;
		}

		if (spawning && stopmovement) {
			StartCoroutine (StopMovement ());
			stopmovement = false;
		}
			
	}

	IEnumerator ActivateDistractors ()
	{
		yield return new WaitForSeconds (2);

		movement2 mm = distractor.GetComponent<movement2> ();
		mm.SetController (this.gameObject);

		for (int i = 0; i < amount + 5; i++) {
			Vector3 pos = new Vector3 (Random.Range(-13,13), Random.Range(-5,5), -2f);
			Instantiate (distractor, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		}

		spawning = true;
	}

	IEnumerator StopMovement ()
	{
		yield return new WaitForSeconds (2);
		Debug.Log ("10 sec");

		moving = false;
	}
}
	