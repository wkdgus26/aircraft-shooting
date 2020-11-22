using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int bulletNum = 2; // 총알갯수
	public int hp = 3;
	float makeTime = 0f;
	public GameObject item;
	public static GameManager instance;
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy(this);
		
	}
	
	// Update is called once per frame
	void Update () {
		makeTime += Time.deltaTime;
		MakeItem();
	}
	void MakeItem() {
		if (makeTime > 3f)
		{
			makeTime = 0f;
			GameObject a = Instantiate(item);
			a.SetActive(true);
		}
	}

}
