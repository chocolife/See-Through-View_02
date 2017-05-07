using UnityEngine;
using System.Collections;

public class ViewMesh2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh.SetIndices(mf.mesh.GetIndices(0),MeshTopology.LineStrip,0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
