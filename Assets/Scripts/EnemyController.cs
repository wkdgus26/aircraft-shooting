using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public MakeObjectPool objectPool;
	float fireNum;
	// Use this for initialization
	void OnEnable () {
		fireNum =  Random.Range(0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		EnemyFire();
	}
	void EnemyFire() {
		if (fireNum < 7f) {
			fireNum = 10;
			GameObject eB = objectPool.MakePool("enemyBullet");
			eB.transform.position = gameObject.transform.position;
		}
	}
}
