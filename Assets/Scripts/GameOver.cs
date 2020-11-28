using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text scoreText;
	// Use this for initialization
	void OnEnable ()
	{
		scoreText.text += GameManager.instance.score.ToString();
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GameOverButton(string idx)
	{
		switch (idx)
		{
			case "restart":
				SceneManager.LoadScene("PlayScene");
				break;
			case "mainmenu":
				SceneManager.LoadScene("MainMenu");
				break;
			case "exit":
				Application.Quit();
				break;
		}
	}

}
