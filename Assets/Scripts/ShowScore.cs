using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowScore : MonoBehaviour {

	public TextMeshProUGUI[] scoreText;
	public GameObject showScore;
	JsonManager jsonMgr;
	// Use this for initialization
	void Start ()
	{
		scoreText = new TextMeshProUGUI[showScore.transform.childCount];
		jsonMgr = GameObject.FindObjectOfType<JsonManager>();
		//showScore = GameObject.Find("Text_Score");
		for (int i = 0; i < showScore.transform.childCount; i++) {
			//scoreText[i].text = showScore.transform.GetChild(i);
			//Debug.Log(showScore.transform.GetChild(5).GetType());
			scoreText[i] = showScore.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
			scoreText[i].text += "11";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
