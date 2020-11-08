using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ButtonClick(string idx)
	{
		switch (idx)
		{
			case "1P":
				SceneManager.LoadScene("PlayScene");
				break;
			case "2P":
				Debug.Log("2");
				break;
			case "Rank":
				Debug.Log("rank");
				break;
			case "Exit":
				Debug.Log("exit");
				break;
		}
	}
}
