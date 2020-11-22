using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class AircarftShooting : MonoBehaviour {

	GameObject[] pBullet;
	public GameObject[] bulletPosition;
	public float fireRate=0; // 재발사 시간
	public MakeObjectPool objectPool;
	// Use this for initialization
	void Start ()
	{
		pBullet = new GameObject[6];
		//bulletPosition = new GameObject[6];
	}
	
	// Update is called once per frame
	void Update () {
		fireRate += Time.deltaTime;
		Shoot();
	}
	
	void Shoot() { // 공격
		if (Input.GetKey(KeyCode.A)&& fireRate > 0.3f) {
			fireRate = 0;
			if (GameManager.instance.bulletNum > 1) // 기본 2발
			{
				setBulletPosition(0);
				setBulletPosition(1);
			}
			if (GameManager.instance.bulletNum > 3) // 4발
			{
				setBulletPosition(2);
				setBulletPosition(3);
			}
			if (GameManager.instance.bulletNum > 5) // 6발
			{
				setBulletPosition(4);
				setBulletPosition(5);
			}
		}
	}
	void setBulletPosition(int index) { // 총알 위치 설정 
		pBullet[index] = objectPool.MakePool("playerBullet");
		pBullet[index].transform.position = bulletPosition[index].transform.position;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item")
		{
			other.gameObject.SetActive(false);
			GameManager.instance.bulletNum += 2;
		}
	}
	
}
