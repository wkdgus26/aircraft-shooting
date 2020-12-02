using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	public Vector3 originPos;
	public Transform targetPos;
	public float speed;
	public float dot; 
	public float offset;
	public Transform oPos;
	public Transform goalPos;
	float z =0;
	// Use this for initialization
	void Start () {
		originPos = transform.position;
		//goalPos = transform.GetChild(1).transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		//z += Time.deltaTime;
		//Debug.Log(Time.deltaTime * 10);
        //Vector3 difference = targetPos.position - originPos;
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + offset);

		//transform.position += Vector3.up * rotationZ; 
		//transform.GetChild(0).gameObject.SetActive(true);
		//GameObject eBullet = transform.GetChild(0).gameObject;
		//gameObject.transform.position = Vector3.Lerp(oPos.position, goalPos.position, z * speed);
	}
}
