using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftHp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyBullet")// 적총알에 맞았을때
		{
			GameManager.instance.hp -= 1;
			other.gameObject.SetActive(false);
		}
		else if (other.tag == "Enemy") // 적이랑 부딛힐때
		{
			GameManager.instance.hp -= 1;
			other.gameObject.SetActive(false);
		}
	}
}
