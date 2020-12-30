using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public Transform[] curvePoint;
	public GameObject item_power;
	public GameObject item_hp;
	public MakeObjectPool objectPool;
	GameObject item;
	float delayTime = 0f;
	float itemTime = 0f;
	float enemySpawnTime = 0f;
	int ranEnemyNum;
	int positiveNum;
	bool isEnemySpawn = false;
	bool isPositiveNum = false;

	void Update ()
	{
		ItemSpwan(); // 아이템 생성
		EnemySpwan(); // 적 생성
	}
	void ItemSpwan()
	{
		itemTime += Time.deltaTime;
		if (itemTime > 10f)
		{
			itemTime = 0f;
			if (Random.value >0.5)
				item = item_power;
			else
				item = item_hp;
			int rX = Random.Range(-20, 25);
			int rZ = Random.Range(-10, 10);
			GameObject itemPos = Instantiate(item, new Vector3(rX, 66, 89), Quaternion.Euler(0f, 0f, rZ));
			itemPos.SetActive(true);
		}
	}
	void EnemySpwan()
	{
		enemySpawnTime += Time.deltaTime; 
		if (enemySpawnTime > 5f) // 5초마다 적생성, 루트 재생성
		{
			setRandomPoint();
			isEnemySpawn = true;
			ranEnemyNum = Random.Range(3, 6); 
			enemySpawnTime = 0f;
		}
		if (isEnemySpawn)
		{
			delayTime += Time.deltaTime;
			if (delayTime > 0.3f) // ranEnemyNum 만큼 enemy생셩
			{
				delayTime = 0f;
				objectPool.MakePool("enemy");
				ranEnemyNum -= 1;
			}
			if (ranEnemyNum == 0)
				isEnemySpawn = false;
		}
	}

	void setRandomPoint()
	{
		isPositiveNum = (Random.value >0.5);
		if (isPositiveNum)
			positiveNum = 1;
		else
			positiveNum = -1;
		curvePoint[0].position = new Vector3(curvePoint[0].position.x * positiveNum, Random.Range(-25, 25), curvePoint[0].position.z);
		curvePoint[1].position = new Vector3(Random.Range(-8, 8), Random.Range(-25, 25), curvePoint[1].position.z);
		curvePoint[2].position = new Vector3(Random.Range(-12, 12), curvePoint[2].position.y, curvePoint[2].position.z);
	}
}
