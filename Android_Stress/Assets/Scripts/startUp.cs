using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUp : MonoBehaviour {

	private int targetAmount;
	private int distractorAmount;

	void Start () 
	{
		// Find target and distractor amount
		targetAmount = PlayerPrefs.GetInt("Targets");
		distractorAmount = PlayerPrefs.GetInt ("Distractors");

		// If not targets found, set targets
		if (targetAmount == 0) 
		{
			PlayerPrefs.SetInt ("Targets", 1);
		}
		// If not distractors found, set distractors
		if (distractorAmount == 0) 
		{
			PlayerPrefs.SetInt ("Distractors", 3);
		}
	}
}
