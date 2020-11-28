using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectPool : MonoBehaviour {

	public GameObject playerBullet;
	public GameObject enemyBullet;
	public GameObject enemy;
	GameObject[] playerBullets;
	GameObject[] enemyBullets;
	GameObject[] enemies;
	GameObject[] tempPool;
	// Use this for initialization
	void Awake () {
		playerBullets = new GameObject[150];
		enemyBullets = new GameObject[80];
		enemies = new GameObject[30];
		for (int i = 0; i < playerBullets.Length; i++)
		{
			playerBullets[i] = Instantiate(playerBullet);
			playerBullets[i].transform.SetParent(GameObject.Find("ObjectPool").transform);
		}
		for (int i = 0; i < enemyBullets.Length; i++)
		{
			enemyBullets[i] = Instantiate(enemyBullet);
			enemyBullets[i].transform.SetParent(GameObject.Find("ObjectPool").transform);
		}
		for (int i = 0; i < enemies.Length; i++)
		{
			enemies[i] = Instantiate(enemy);
			enemies[i].transform.SetParent(GameObject.Find("ObjectPool").transform);
		}
	}

	public GameObject MakePool(string type)
	{
        switch (type)
        {
            case "playerBullet":
                tempPool = playerBullets;
                break;
            case "enemyBullet":
                tempPool = enemyBullets;
                break;
			case "enemy":
				tempPool = enemies;
				break;
		}
        for (int i = 0; i < tempPool.Length; i++)
        {
            if (!tempPool[i].activeSelf)
            {
                tempPool[i].SetActive(true);
                return tempPool[i];
            }
        }
        return null;
	}
}
