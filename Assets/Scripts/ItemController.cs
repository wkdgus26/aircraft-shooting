﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	int speed; 
	float destroyTime = 0f;
	// Use this for initialization
	void OnEnable() {
		speed = Random.Range(-15, -40);
	}
	
	// Update is called once per frame
	void Update () {
		ItemMove();
		ItemDestroy();
	}
	void ItemMove()
	{
		transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
	}
	void ItemDestroy() {
		destroyTime += Time.deltaTime;
		if (destroyTime > 6f)
			Destroy(gameObject);
	}
	void OnTriggerEnter(Collider other)
	{
		if (gameObject.tag == "Item_Power"&&other.tag == "Player")
		{
			if (GameManager.instance.bulletNum < 8)
				GameManager.instance.bulletNum += 2;
			Destroy(gameObject);
		}
	}
}
