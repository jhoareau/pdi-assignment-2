using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void LoadLevel ()
	{
		SceneManager.LoadScene (1);
	}

	public void Exit ()
	{
		Application.Quit ();
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene (0);
	}
}
