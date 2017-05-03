using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	// Load settings screen
	public void LoadSettings () 
	{
		SceneManager.LoadScene (1);
	}

	// Load game screen
	public void LoadLevel ()
	{
		SceneManager.LoadScene (2);
	}

	// Load help screen
	public void LoadHelp ()
	{
		SceneManager.LoadScene (3);
	}

	// Quit application
	public void Exit ()
	{
		Application.Quit ();
	}

	// Load main menu
	public void MainMenu ()
	{
		SceneManager.LoadScene (0);
	}

	// Settings fuctions

	// Set values according to selected buttons
	public void buttonSelect(int button)
	{
		// Button 0 to 4 is target buttons, and higher are distractor buttons
		if (button < 5) {
			PlayerPrefs.SetInt ("Targets", button + 1);
		} else {
			PlayerPrefs.SetInt ("Distractors", button - 2);
		}
	}

	// Set the selected buttons color
	public void SetButtonColor(GameObject b)
	{
		GameObject[] buttons = GameObject.FindGameObjectsWithTag ("button");

		foreach (GameObject button in buttons) {
			ColorBlock cb = button.GetComponent<Button> ().colors;
			cb.normalColor = Color.white;
			button.GetComponent<Button> ().colors = cb;
		}

		ColorBlock cb2 = b.GetComponent<Button> ().colors;
		cb2.normalColor = Color.cyan;
		b.GetComponent<Button> ().colors = cb2;
	}

	// Set selected buttons color
	public void SetButtonColor2(GameObject b)
	{
		GameObject[] buttons = GameObject.FindGameObjectsWithTag ("button2");

		foreach (GameObject button in buttons) {
			ColorBlock cb = button.GetComponent<Button> ().colors;
			cb.normalColor = Color.white;
			button.GetComponent<Button> ().colors = cb;
		}

		ColorBlock cb2 = b.GetComponent<Button> ().colors;
		cb2.normalColor = Color.cyan;
		b.GetComponent<Button> ().colors = cb2;
	}
}
