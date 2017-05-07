using UnityEngine;
using System.Collections;

public class MeshController : MonoBehaviour {


	public GameObject obj;
	// Use this for initialization
	void Start () {
		//MeshFilter mf = GetComponent<MeshFilter>();
		//mf.mesh.SetIndices(mf.mesh.GetIndices(0),MeshTopology.LineStrip,0);
		
		//transform.RotateAround (transform.position, transform.right, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.forward, -0.02f);
	}
}
