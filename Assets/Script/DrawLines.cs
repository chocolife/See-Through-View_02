using UnityEngine;
using System.Collections;

// このスクリプトはCameraにアタッチされる
public class DrawLines : MonoBehaviour {

    // publicのメンバはGUIから操作できる
    public Material lineMat;
    public float NoiseSeed;
    public float radius;

    // フレーム毎のデータ更新
    void Update() {

        // z方向にCameraが移動
        transform.Translate (0, 0, 0.01f);
        // 回転させる
        transform.Rotate (new Vector3 (0, 0, 0.3f));
    
    }

    void DrawTile() {

        // 裏表を反転する。
        // UnityではデフォルトCullingがOnなので裏側にカメラがあると何も描画されない
        GL.invertCulling = true;

        // ワイヤフレーム表示にする
        GL.wireframe = true;

        // Materialは必要
        lineMat.SetPass (0);

        // あとは良い感じに何か書く
        // ここではGrid状に頂点を持ったMeshを歪めてトンネルにする
        for (int i = 0; i < 64; i++) {

            GL.Begin (GL.TRIANGLE_STRIP);

            for (int j = 0; j < 5; j++) {

                float t = Time.time;

                float y1 = Mathf.PerlinNoise (t + j * NoiseSeed, t + i * NoiseSeed) * 1.0f + 0.5f;
                float y2 = Mathf.PerlinNoise (t + j * NoiseSeed, t + (i+1) * NoiseSeed) * 1.0f + 0.5f;

                float x = radius * Mathf.Sin (Mathf.PI / 2 * j + i * 0.5f);
                float y = radius * Mathf.Cos (Mathf.PI / 2 * j + i * 0.5f);

                GL.Vertex3 (x, y * y1, i * 0.5f);
                GL.Vertex3 (x, y * y2, (i+1) * 0.5f);

            }

            GL.End ();
        
        }

        // 他の描画に影響を与えないようwireframe表示をOff
        GL.wireframe = false;

    }

    // 直接描画できるタイミングにひかれる
    void OnPostRender() {

        DrawTile ();

    }

    // Unityツール内のSceneビュー上に描画する
    void OnDrawGizmos() {

        DrawTile ();

    }
}