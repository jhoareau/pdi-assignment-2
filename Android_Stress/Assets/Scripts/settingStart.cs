using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class settingStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] buttons1 = GameObject.FindGameObjectsWithTag ("button").OrderBy(go => go.name).ToArray();
		GameObject[] buttons2 = GameObject.FindGameObjectsWithTag ("button2").OrderBy(go => go.name).ToArray();

		foreach (GameObject button in buttons1) {
			ColorBlock cb = button.GetComponent<Button> ().colors;
			cb.normalColor = Color.white;
			button.GetComponent<Button> ().colors = cb;
		}
		foreach (GameObject button2 in buttons2) {
			ColorBlock cb = button2.GetComponent<Button> ().colors;
			cb.normalColor = Color.white;
			button2.GetComponent<Button> ().colors = cb;
		}

		int target = PlayerPrefs.GetInt ("Targets");
		int distractors = PlayerPrefs.GetInt ("Distractors");

		Debug.Log ("Target: " + target);
		Debug.Log ("Distractors: " + distractors);

		target = target - 1;
		distractors = distractors - 3;

		ColorBlock cb1 = buttons1[target].GetComponent<Button> ().colors;
		cb1.normalColor = Color.cyan;
		buttons1[target].GetComponent<Button> ().colors = cb1;

		ColorBlock cb2 = buttons2[distractors].GetComponent<Button> ().colors;
		cb2.normalColor = Color.cyan;
		buttons2[distractors].GetComponent<Button> ().colors = cb2;
	}
}
