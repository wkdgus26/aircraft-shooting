using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	int speed;
	// Use this for initialization
	void OnEnable() {
		speed = Random.Range(-15, -40);
	}
	
	// Update is called once per frame
	void Update () {
		ItemMove();
	}
	void ItemMove()
	{
		transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			gameObject.SetActive(false);
			if (GameManager.instance.bulletNum < 6)
				GameManager.instance.bulletNum += 2;
		}
	}
}
