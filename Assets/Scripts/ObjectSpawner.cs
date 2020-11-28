using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	float itemTime = 0f;
	float enemyTime = 0f;
	GameObject item;
	public GameObject item_power;
	public GameObject item_hp;
	public MakeObjectPool objectPool;
	// Update is called once per frame
	void Update ()
	{
		ItemSpwan(); // 아이템 생성
		EnemySpwan(); // 적 생성
	}
	void ItemSpwan()
	{
		itemTime += Time.deltaTime;
		if (itemTime > 3f)
		{
			itemTime = 0f;
			if (Random.Range(0, 10) < 5)
				item = item_power;
			else
				item = item_hp;
			int rX = Random.Range(-20, 25);
			int rZ = Random.Range(-10, 10);
			GameObject itemPos = Instantiate(item, new Vector3(rX, 66, 89), Quaternion.Euler(0f, 0f, rZ));
			itemPos.SetActive(true);
		}
	}
	void EnemySpwan() {
		enemyTime += Time.deltaTime;
		if (enemyTime > 1.5f)
		{
			enemyTime = 0f;
			GameObject enemyPos = objectPool.MakePool("enemy");
		}
	}
}
