using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public MakeObjectPool objectPool;
	float fireNum;
	bool isFire = false;
	// Use this for initialization
	void OnEnable () {
		fireNum =  Random.Range(0, 10); 
		if(fireNum < 7f)
			isFire = true;
	}
	
	// Update is called once per frame
	void Update () {
		EnemyFire();
	}
	void EnemyFire() {
		if (isFire) {
			fireNum = 10;
			isFire = false;
			GameObject eB = objectPool.MakePool("enemyBullet");
			eB.transform.position = gameObject.transform.position;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PBullet" || other.tag == "Player") // 적 제거
		{
			gameObject.SetActive(false);
		}
	}
}
