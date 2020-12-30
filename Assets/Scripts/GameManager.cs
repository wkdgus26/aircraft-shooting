using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public int bulletCount = 2; // 총알갯수
	public int score = 0;
	public GameObject player;
	public GameObject gameOverUI; 
	public GameObject playerExplosion;
	public JsonManager jsonMgr;
	
	// Use this for initialization
	void Awake ()
	{
		Time.timeScale = 1;
		if (instance == null)
			instance = this;
		else
			Destroy(this);
		
	}
	
	public void GameOver() {
		jsonMgr.DataAdd(score);
		playerExplosion.transform.position = player.transform.position;
		player.SetActive(false);
		playerExplosion.SetActive(true);
		StartCoroutine(GameOverCoroutine());
	}
	IEnumerator GameOverCoroutine()
	{
		yield return new WaitForSeconds(2f);
		gameOverUI.SetActive(true);
	}
}
