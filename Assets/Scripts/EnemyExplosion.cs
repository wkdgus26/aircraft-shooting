using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour {
	void OnEnable () {
		StartCoroutine(ExplosionCoroutine());
	}
	IEnumerator ExplosionCoroutine() {
		yield return new WaitForSeconds(2f);
		transform.parent.transform.GetChild(0).gameObject.SetActive(true);
		transform.parent.gameObject.SetActive(false);
	}
}
