using UnityEngine;
using System.Collections;

public class MeshParticles : MonoBehaviour {

	public GameObject TargetPrimitive;
    public Camera cam;
	//private Color col = new Color(0, 0.3f, 0.8f);
	
	[Range(0.0f, 1.0f)]
	public float ParticleSpeed;
	private float z_depth;
    
	private Vector3[] meshVertices;

	private ParticleSystem.Particle[] particles;
	private Vector3 vertex_pos;

    private float horizon_center = -0.5f;
    private float depth_center = 0.8f;

	void Start ()
    {
		meshVertices = TargetPrimitive.GetComponent<MeshFilter>().sharedMesh.vertices;
		particles = new ParticleSystem.Particle[meshVertices.Length];
	}
	


	void Update () {

        
        //if (Input.GetMouseButtonDown(0)) 
        //{
            // ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
            // Vector3でマウスがクリックした位置座標を取得する
            Vector3 clickPosition = Input.mousePosition;
            // Z軸修正
            clickPosition.z = 5f;
            // オブジェクト生成 : オブジェクト(GameObject), 位置(Vector3), 角度(Quaternion)
            // ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する
            //Instantiate(Prefab, Camera.main.ScreenToWorldPoint(clickPosition), Prefab.transform.rotation);
            Vector3 clicked_world_point = cam.ScreenToWorldPoint(clickPosition);
            horizon_center = clicked_world_point.x / 10 ;
        //}
        


		meshVertices = TargetPrimitive.GetComponent<MeshFilter>().sharedMesh.vertices;

		//dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//Vector3 vec = thisMatrix.MultiplyPoint3x4(vertex);
		Matrix4x4 thisMatrix = transform.localToWorldMatrix;
		
		for(int i = 0; i < meshVertices.Length; i++) {
			// ワールド座標系に変換してTargetPrimitiveの移動に追従させる
			meshVertices[i] = TargetPrimitive.transform.TransformPoint(meshVertices[i]);
			//Vector3 vec = thisMatrix.MultiplyPoint3x4(meshVertices[i]);

			
			// ちょっと遅延させてパーティクルを移動させる
			//particles[i].position = particles[i].position * (1f - ParticleSpeed) + meshVertices[i] * ParticleSpeed;

            bool in_flg = false;

			vertex_pos = meshVertices[i];
			z_depth = Mathf.Abs(1 - vertex_pos.z);

			if (particles[i].position.y < 0) {
				z_depth = 0.0f;
			}

			float shift_y = (0.2f - Mathf.Abs(0.1f - vertex_pos.z)* 2);
			particles[i].position = new Vector3(vertex_pos.x, vertex_pos.y, vertex_pos.z);
            //particles[i].color = new Color(1f - meshVertices[i].x % 1f, 0.2f + meshVertices[i].y % 0.8f, 0.5f + meshVertices[i].z % 0.5f);

            float min_horizon = horizon_center - 0.25f;
            float max_horizon = horizon_center + 0.25f;
            float min_depth = depth_center - 0.2f;
            float max_depth = depth_center + 0.2f;

            if (particles[i].position.y > min_depth && particles[i].position.y < max_depth)
            {
                in_flg = true;
            }


			if (particles[i].position.x > min_horizon && particles[i].position.x < max_horizon && in_flg)
            {
                float target_min = horizon_center - min_horizon;
                float target_max = max_horizon - horizon_center;
                float target_center = (target_min + target_max) / 2;    
                float distance = Mathf.Abs(horizon_center - particles[i].position.x);

				particles[i].color = new Color(1.0f - (distance / target_center), 0.5f - (distance / target_center)/4, 1.0f, 1.0f);

			}
            else
            {
				particles[i].color = new Color(0, 0.3f, 1.0f, 1.0f);
			}
            
			particles[i].size = 0.025f;

			// Require Set Lifetime
			particles[i].lifetime = 0.1f;
			particles[i].startLifetime = 0.1f;
		}
		//Debug.Log (particles[101].position);
		
		GetComponent<ParticleSystem> ().SetParticles (particles, particles.Length);
	}



}	