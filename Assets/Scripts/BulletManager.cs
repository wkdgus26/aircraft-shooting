using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
	float destroyTime = 0f; // 총알이 사라지는데 걸리는 시간
	string bulletName;
	void OnEnable()
	{
		destroyTime = 0f;
	}
	void Start() {
		bulletName = gameObject.name;
	}
	void Update () {
		bulletActive();
	}
	void bulletActive() {
		destroyTime += Time.deltaTime;
		if (bulletName == "PlayerBullet(Clone)") //플레이어 bullet
		{
			gameObject.transform.position += Vector3.up * 40f * Time.deltaTime;
		}
		else //적 bullet
			gameObject.transform.position += Vector3.down * 40f * Time.deltaTime;
		if (destroyTime > 3f)
			bulletActiveFalse();
	}
	void bulletActiveFalse() {
		gameObject.SetActive(false);
	}
	
	void OnTriggerEnter(Collider other) {
		if (bulletName == "EnemyBullet(Clone)" && other.tag == "Player")// 적총알에 맞았을때
		{
			bulletActiveFalse();
		}
		else if (bulletName == "PlayerBullet(Clone)" && other.tag == "Enemy") // 적을 맞췄을때
		{
			bulletActiveFalse();
		}
	}
}
