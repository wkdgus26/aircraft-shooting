using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	int speed; 
	void OnEnable() {
		speed = Random.Range(-15, -40);
	}
	
	void Update () {
		ItemDrop(); // 아이템 움직임
	}
	void ItemDrop()
	{
		transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if (gameObject.tag == "Item_Power"&&other.tag == "Player")
		{
			if (GameManager.instance.bulletCount < 8)
				GameManager.instance.bulletCount += 2;
			Destroy(gameObject);
		}
		if (other.tag == "Destroy")
			Destroy(gameObject);
	}
}
