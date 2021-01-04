﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public int bulletCount = 2; // 총알갯수
	public int score = 0;
	public GameObject player;
	public GameObject gameOverUI; 
	public GameObject playerExplosion;
	
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
		if(JsonManager.instance)
			JsonManager.instance.DataAdd(score); // 데이터 전달
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
