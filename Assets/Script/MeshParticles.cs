using UnityEngine;
using System.Collections;

public class MeshParticles : MonoBehaviour {
	// パーティクルのカタチをなす元とするモデル
	public GameObject TargetPrimitive;
	//private Color col = new Color(0, 0.3f, 0.8f);
	
	[Range(0.0f, 1.0f)]
	public float ParticleSpeed;
	private float z_depth;
	
	// 各パーティクルの目標座標
	private Vector3[] meshVertices;
	// 各パーティクル情報
	private ParticleSystem.Particle[] particles;
	private Vector3 vertex_pos;
	

	void Start () {

		meshVertices = TargetPrimitive.GetComponent<MeshFilter>().sharedMesh.vertices;
		particles = new ParticleSystem.Particle[meshVertices.Length];
	}
	
	void Update () {
		// ターゲット座標の更新
		meshVertices = TargetPrimitive.GetComponent<MeshFilter>().sharedMesh.vertices;

		//dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//Vector3 vec = thisMatrix.MultiplyPoint3x4(vertex);
		Matrix4x4 thisMatrix = transform.localToWorldMatrix;
		
		for(int i=0; i<meshVertices.Length; i++) {
			// ワールド座標系に変換してTargetPrimitiveの移動に追従させる
			meshVertices[i] = TargetPrimitive.transform.TransformPoint(meshVertices[i]);
			Vector3 vec = thisMatrix.MultiplyPoint3x4(meshVertices[i]);

			
			// ちょっと遅延させてパーティクルを移動させる
			//particles[i].position = particles[i].position * (1f - ParticleSpeed) + meshVertices[i] * ParticleSpeed;

			//particles[i].position = meshVertices[i];
			vertex_pos = meshVertices[i];

			// 座標に応じてパーティクルをカラフルに
			//particles[i].color = new Color(1f - meshVertices[i].x % 1f, 0.2f + meshVertices[i].y % 0.8f, 0.5f + meshVertices[i].z % 0.5f);

			z_depth = Mathf.Abs(1 - vertex_pos.z);

			if (particles[i].position.y < 0) {
				z_depth = 0.0f;
			}


			float shift_y = (0.2f - Mathf.Abs(0.1f - vertex_pos.z)* 2);
			particles[i].position = new Vector3(vertex_pos.x, vertex_pos.y + shift_y, vertex_pos.z);


			if (particles[i].position.z > 0.1f) {
				particles[i].color = new Color(0, 0.4f, 0.85f, z_depth);
			} else {
				particles[i].color = new Color(1f, 0, 0, z_depth);
			}

			particles[i].size = 0.025f;
			
			// ライフタイムを指定しないと表示されない（すぐ死んで消えてる？）
			particles[i].lifetime = 1f;
			particles[i].startLifetime = 1f;
		}
		
		//Debug.Log (particles[101].position);
		
		// パーティクル情報の更新
		GetComponent<ParticleSystem> ().SetParticles (particles, particles.Length);
	}
}	