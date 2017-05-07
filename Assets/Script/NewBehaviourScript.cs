using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject dot;
	Vector3[] vertices;

	// Use this for initialization
	void Start ()
	{
		Matrix4x4 thisMatrix = transform.localToWorldMatrix;
		
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;

		foreach (Vector3 vertex in vertices)
		{
			dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			Vector3 vec = thisMatrix.MultiplyPoint3x4(vertex);
			// ("mesh1 vertex at " + thisMatrix.MultiplyPoint3x4(vertex));

			Transform cubeTrans = dot.transform;
			cubeTrans.localPosition = vec;
			cubeTrans.localScale = Vector3.one * 0.01f;
        }
    }
	// Update is called once per frame
	void Update () {

	
	}
}
