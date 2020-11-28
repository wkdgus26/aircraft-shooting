using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftHp : MonoBehaviour {
	public GameObject gameOverUI;
	public GameObject[] playerHp;
	void Update() {
		GameOver();
	}

	void GameOver() {
		if (GameManager.instance.hp <= 0)
		{
			gameObject.SetActive(false);
			gameOverUI.SetActive(true);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EBullet" || other.tag == "Enemy")// 적총알에 맞았을때
		{
			GameManager.instance.hp -= 1;
			playerHp[GameManager.instance.hp].SetActive(false);
			other.gameObject.SetActive(false);
		}
		else if (other.tag == "Item_Hp")
		{
			if (GameManager.instance.hp < 3)
			{
				playerHp[GameManager.instance.hp].SetActive(true);
				GameManager.instance.hp += 1;
			}
			Destroy(other.gameObject);
		}
	}
}
