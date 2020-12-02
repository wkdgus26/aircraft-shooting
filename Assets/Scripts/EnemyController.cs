using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public BulletManager bulletMan;
	public MakeObjectPool objectPool;
	public Transform targetPos;
	public int offset;
	public float speed;
	GameObject eBullet;
	Vector3 difference;
	int enemyHp;
	float ranFireNum;
	float fireRate;
	float rotationZ;
	bool isFire = false;
	// Use this for initialization
	void OnEnable () {
		enemyHp = 2;
		ranFireNum =  Random.Range(0, 3);
		fireRate = 0;
		if (Random.value>0.4f)
			isFire = true;
	}
	
	// Update is called once per frame
	void Update () {
		SetRotation();
		EnemyFire();
		if(enemyHp==0)
			EnemyDie();
	}
	void SetRotation()
	{
		difference = targetPos.position - transform.position;
		rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + offset);
	}
	void EnemyFire() {
		fireRate += Time.deltaTime;
		if (isFire&& fireRate >1f && fireRate > ranFireNum) {
			isFire = false;
			eBullet = objectPool.MakePool("enemyBullet"); // eBullet 생성 및 대입
			bulletMan = eBullet.GetComponent<BulletManager>(); // 생성된 enemyBullet의 BulletManager script 정보
			eBullet.transform.position = transform.position;
			bulletMan.targetPos = transform.GetChild(0).transform.position;
			bulletMan.originPos = transform.position;
        }
    }
	void EnemyDie()
	{
		gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PBullet") 
		{
			other.gameObject.SetActive(false);
			enemyHp--;
		}
		if (other.tag == "Player")
		{
			gameObject.SetActive(false);
		}
	}
}
