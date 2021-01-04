using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowScore : MonoBehaviour {

	public TextMeshProUGUI[] scoreText;
	public GameObject showScore;
	void Start ()
	{
		scoreText = new TextMeshProUGUI[showScore.transform.childCount];
		for (int i = 0; i < showScore.transform.childCount; i++) {
			scoreText[i] = showScore.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
			scoreText[i].text = JsonManager.instance.scoreData.scoreArray[i].ToString();
		}
	}
}
