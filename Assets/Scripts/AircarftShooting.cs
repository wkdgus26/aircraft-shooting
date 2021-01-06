using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class AircarftShooting : MonoBehaviour {

	GameObject[] pBullet; // 플레이어 불릿
	public GameObject[] bulletPosition; // 플레이어 불릿 위치
	public MakeObjectPool objectPool;
	public float fireRate = 0.13f;
	float fireRateTime = 0f; // 재발사 시간
	void Start () {
		pBullet = new GameObject[8];
	}
	
	// Update is called once per frame
	void Update () {
		fireRateTime += Time.deltaTime;
		Shoot();
	}
	
	void Shoot() { // 공격
		if (Input.GetKey(KeyCode.A)&& fireRateTime > fireRate) {
			fireRateTime = 0;
			for (int i=0; i<GameManager.instance.bulletCount; i++)
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
