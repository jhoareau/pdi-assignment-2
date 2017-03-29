using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	// Screen change functions
	public void LoadSetings () 
	{
		SceneManager.LoadScene (1);
	}

	public void LoadLevel ()
	{
		SceneManager.LoadScene (2);
	}

	public void LoadHelp(){
		SceneManager.LoadScene (3);
	}

	public void Exit ()
	{
		Application.Quit ();
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene (0);
	}

	// Settings fuctions

	public void buttonSelect(int button)
	{
		if (button < 5) {
			PlayerPrefs.SetInt ("Targets", button + 1);
		} else {
			PlayerPrefs.SetInt ("Distractors", button - 2);
		}
		Debug.Log ("Targets" + PlayerPrefs.GetInt("Targets"));
		Debug.Log ("Distractors" + PlayerPrefs.GetInt("Distractors"));
	}

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
