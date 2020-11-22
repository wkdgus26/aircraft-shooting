using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMove : MonoBehaviour {
	public float speed = 0.1f;
	public float test1 = 0f;
	public float test2 = 1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Clamp();
	}
	void Move()
	{ // 움직임
		if (Input.GetKey(KeyCode.LeftArrow))
			transform.position += Vector3.left * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.RightArrow))
			transform.position += Vector3.right * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.UpArrow))
			transform.position += Vector3.up * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.DownArrow))
			transform.position += Vector3.down * speed * Time.deltaTime;

	}
	void Clamp() // 화면제한
	{
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		if (pos.x < 0.13f) pos.x = 0.13f;
		if (pos.x > 0.87f) pos.x = 0.87f;
		if (pos.y < 0.065f) pos.y = 0.065f;
		if (pos.y > 0.935f) pos.y = 0.935f;
		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}
}
