using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class settingStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Sorted arrays to keep track of buttons for difficulty
		GameObject[] buttons1 = GameObject.FindGameObjectsWithTag ("button").OrderBy(go => go.name).ToArray();
		GameObject[] buttons2 = GameObject.FindGameObjectsWithTag ("button2").OrderBy(go => go.name).ToArray();

		// Color each button white in the first array
		foreach (GameObject button in buttons1) {
			ColorBlock cb = button.GetComponent<Button> ().colors;
			cb.normalColor = Color.white;
			button.GetComponent<Button> ().colors = cb;
		}
		// Color each button white in the second array
		foreach (GameObject button2 in buttons2) {
			ColorBlock cb = button2.GetComponent<Button> ().colors;
			cb.normalColor = Color.white;
			button2.GetComponent<Button> ().colors = cb;
		}

		// Get amount of targets and distractors
		int target = PlayerPrefs.GetInt ("Targets");
		int distractors = PlayerPrefs.GetInt ("Distractors");

		// Adjust amounts to fit targets (0 indexed arrays)
		target = target - 1;
		distractors = distractors - 3;

		// Color the button corresponding to the amount of targets cyan.
		ColorBlock cb1 = buttons1[target].GetComponent<Button> ().colors;
		cb1.normalColor = Color.cyan;
		buttons1[target].GetComponent<Button> ().colors = cb1;

		// Color the button coppesonding to the amount of distractors cyan. 
		ColorBlock cb2 = buttons2[distractors].GetComponent<Button> ().colors;
		cb2.normalColor = Color.cyan;
		buttons2[distractors].GetComponent<Button> ().colors = cb2;
	}
}
