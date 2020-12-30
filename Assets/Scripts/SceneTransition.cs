using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {
	public GameObject mainUI;
	public GameObject rankUI;
	void Start()
	{
	}
	public void ButtonClick(string idx)
	{
		switch (idx)
		{
			case "Play":
				SceneManager.LoadScene("PlayScene");
				break;
			case "Rank":
				mainUI.SetActive(false);
				rankUI.SetActive(true);
				break;
			case "Back":
				rankUI.SetActive(false);
				mainUI.SetActive(true);
				break;
			case "Exit":
				Debug.Log("exit");
				break;
		}
	}
}
