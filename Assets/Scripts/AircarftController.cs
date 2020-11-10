using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class AircarftController : MonoBehaviour {

	public int speed =1;
	public GameObject bulletP;
	GameObject[] bullet;
	// Use this for initialization
	void Start () {
		bullet = new GameObject[30];
		for (int i = 0; i < bullet.Length; i++){
			bullet[i] = Instantiate(bulletP);
			bullet[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Shoot();
	}
	void Move() { // 움직임
		if (Input.GetKey(KeyCode.LeftArrow))
			transform.position += Vector3.left * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.RightArrow))
			transform.position += Vector3.right * speed *Time.deltaTime;
		if (Input.GetKey(KeyCode.UpArrow))
			transform.position += Vector3.up * speed *Time.deltaTime;
		if (Input.GetKey(KeyCode.DownArrow))
			transform.position += Vector3.down * speed * Time.deltaTime;
	}
	void Shoot() { // 공격
		if (Input.GetKey(KeyCode.A)) {
			MakeObjPool("pShoot");
		}
	}

	public GameObject MakeObjPool(string type) {
		switch (type)
		{
			case "pShoot":
				for (int i = 0; i < bullet.Length; i++) {
					if (!bullet[i].activeSelf) {
						bullet[i].SetActive(true);
						return bullet[i];
					}
				}
				break;
		}
		return null;
	}
}
