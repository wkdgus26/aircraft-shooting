using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour {

	public GameObject map;
	public int speed = 10;
	int index = 0;
	Vector3 rePosition;
	// Use this for initialization
	void Awake () {
		rePosition = gameObject.transform.GetChild(2).position;
	}
	
	// Update is called once per frame
	void Update () {
		MapScrolling();
	}
	void MapScrolling()
	{
		map.transform.position += Vector3.down * Time.deltaTime * speed;
		if (gameObject.transform.GetChild(index).position.y <= -125)
		{
			gameObject.transform.GetChild(index).position = rePosition;
			index++;
			if (index > 2)
				index = 0;
		}
	}
}
