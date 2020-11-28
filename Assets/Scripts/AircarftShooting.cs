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
		pBullet = new GameObject[8];
		//bulletPosition = new GameObject[6];
	}
	
	// Update is called once per frame
	void Update () {
		fireRate += Time.deltaTime;
		Shoot();
	}
	
	void Shoot() { // 공격
		if (Input.GetKey(KeyCode.A)&& fireRate > 0.2f) {
			fireRate = 0;
			for (int i=0; i<GameManager.instance.bulletNum; i++)
            {
				setBulletPosition(i);
			}
		}
	}


	void setBulletPosition(int index) { // 총알 위치 설정 
		pBullet[index] = objectPool.MakePool("playerBullet");
		pBullet[index].transform.position = bulletPosition[index].transform.position;
		bulletPosition[index].GetComponent<ParticleSystem>().Play(); // 파티클 실행
	}
}
