using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public MakeObjectPool objectPool;
	float spwanTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spwanTime += Time.deltaTime;
		if (spwanTime > 1.5f) {
			GameObject ePosition = objectPool.MakePool("enemy");
			spwanTime = 0;
		}
	}
}
