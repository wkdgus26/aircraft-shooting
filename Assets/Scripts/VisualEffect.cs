using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisualEffect : MonoBehaviour {

    public float destructionTime;

    private void OnEnable()
    {
        gameObject.transform.parent = null;
        StartCoroutine(Destruction()); 
    }

    IEnumerator Destruction() 
    {
        yield return new WaitForSeconds(destructionTime); 
        Destroy(gameObject);
    }
}
