using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
	public Vector3 originPos; // 총알이 날라간 시점의 위치
	public Vector3 targetPos; // 총알이 날아갈 위치
	float destroyTime = 0f; // 총알이 사라지는데 걸리는 시간
	float time=0;
	string bulletName;
	public float speed; // 총알이 날아가는 속도
	void OnEnable()
	{
		time = 0;
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
			gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
		}
        else //적 bullet 
        {
            time += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(originPos, targetPos, speed * time);
        }
        if (destroyTime > 3f)
			bulletActiveFalse();
	}
	void bulletActiveFalse() {
		gameObject.SetActive(false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (bulletName == "PlayerBullet(Clone)" && other.tag == "Enemy") // 적을 맞췄을때
			bulletActiveFalse();
		if (bulletName == "EnemyBullet(Clone)" && other.tag == "Player") 
			bulletActiveFalse();
	}
}
