using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCurve : MonoBehaviour {
    public Transform[] curvePoint;
    public float speed = 0.5f;
    float t = 0;
    public int vertexCount = 12;
    void OnEnable()
    {
        t = 0;
        transform.position = curvePoint[0].position;
    }
    void Update()
    {

        if (transform.position == curvePoint[2].position)
        {
            gameObject.SetActive(false);
        }
        t += Time.deltaTime * speed;
        transform.position = BezierCurve(curvePoint[0].position, curvePoint[1].position, curvePoint[2].position, t);
    }
    Vector3 BezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 bezier = Vector3.Lerp(a, b, t);
        return bezier;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (float ratio = 0; ratio < 1; ratio += 1f / vertexCount)
        {
            Gizmos.DrawLine(Vector3.Lerp(curvePoint[0].position, curvePoint[1].position, ratio), Vector3.Lerp(curvePoint[1].position, curvePoint[2].position, ratio));
        }
        Gizmos.color = Color.white;
        for (int i = 0; i < curvePoint.Length; i++)
            Gizmos.DrawSphere(curvePoint[i].position, 0.5f);
        
    }
}
