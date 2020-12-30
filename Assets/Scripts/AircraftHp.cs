using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftHp : MonoBehaviour {
	public GameObject[] playerHpUI;
	int playerHp = 3;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EBullet" || other.tag == "Enemy")// 적총알에 맞았을때
		{
			playerHp -= 1;
			playerHpUI[playerHp].SetActive(false);
			if (playerHp <= 0)
				GameManager.instance.GameOver();
		}
		else if (other.tag == "Item_Hp")
		{
			if (playerHp < 3)
			{
				playerHpUI[playerHp].SetActive(true);
				playerHp += 1;
			}
			Destroy(other.gameObject);
		}
	}
}
