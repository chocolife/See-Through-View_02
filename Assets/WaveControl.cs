using UnityEngine;
using System.Collections;

public class WaveControl : MonoBehaviour {

    RenderTexture[] _waveBuf = new RenderTexture[3];
    public Material myMaterial;
    int _currentTargetIdx = 0;
    public Renderer targetRenderer;
    public Texture inputTex;


    // Use this for initialization
    void Start () {
        myMaterial = new Material(myMaterial);
        for (int i = 0; i < 3; ++i)
        {
            _waveBuf[i] = new RenderTexture(1024, 1024, 24);
            _waveBuf[i].wrapMode = TextureWrapMode.Clamp;
            _waveBuf[i].Create();
        }
        myMaterial.SetTexture("_draw", inputTex);
    }

    // Update is called once per frame
    void Update () 
    {
        int prevIdx1 = (_currentTargetIdx - 1 + 3) % 3;
        int prevIdx2 = (_currentTargetIdx - 2 + 3) % 3;
        myMaterial.SetTexture("_prev_1", _waveBuf[prevIdx1]);
        myMaterial.SetTexture("_prev_2", _waveBuf[prevIdx2]);

        Graphics.Blit(_waveBuf[prevIdx1], _waveBuf[_currentTargetIdx], myMaterial);

         targetRenderer.material.mainTexture = _waveBuf[_currentTargetIdx];

        _currentTargetIdx = (_currentTargetIdx + 1) % 3;
    }
}