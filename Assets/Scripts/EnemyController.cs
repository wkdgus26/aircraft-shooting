using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public BulletManager bulletMgr;
	public MakeObjectPool objectPool;
	public Transform targetPos;
	public int offset;
	public float speed;
	GameObject eBullet;
	GameObject enemyExplosion;
	Vector3 difference;
	int enemyHp;
	float ranFireNum;
	float fireRate;
	float rotationZ;
	bool isFire = false;
	void OnEnable () {
		enemyExplosion.SetActive(false);
		enemyHp = 2;
		ranFireNum =  Random.Range(0, 3);
		fireRate = 0;
		if (Random.value>0.4f)
			isFire = true;
	}
	void Awake() {
		enemyExplosion = transform.parent.GetChild(1).gameObject;
	}
	void Update () {
		SetRotation();
		EnemyFire();
		if(enemyHp==0 && !enemyExplosion.activeSelf)
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
			bulletMgr = eBullet.GetComponent<BulletManager>(); // 생성된 enemyBullet의 BulletManager script 정보
			eBullet.transform.position = transform.position;
			bulletMgr.targetPos = transform.GetChild(0).transform.position;
			bulletMgr.originPos = transform.position;
        }
    }
	void EnemyDie()
	{
		enemyExplosion.transform.position = transform.position;
		enemyExplosion.SetActive(true);
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
			enemyHp = 0;
		}
	}
}
