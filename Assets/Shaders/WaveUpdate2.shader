Shader "Custom/WaveUpdate2" {
Properties {
 _prev_1 ("", 2D) = "white" {}
 _prev_2 ("", 2D) = "white" {}
 _draw ("", 2D) = "black" {}
 _width ("", Float) = 1024
 _height ("", Float) = 1024
 _speed("", Float) = 10
}

SubShader {

ZTest Always
Cull Off
ZWrite Off
Fog { Mode Off } //Rendering settings

 Pass{
  CGPROGRAM
  #pragma vertex vert
  #pragma fragment frag
  #include "UnityCG.cginc" 
  //we include "UnityCG.cginc" to use the appdata_img struct

  struct v2f {
   float4 pos : POSITION;
   half2 uv : TEXCOORD0;
  };

  //Our Vertex Shader 
  v2f vert (appdata_img v){
   v2f o;
   o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
   o.uv = MultiplyUV (UNITY_MATRIX_TEXTURE0, v.texcoord.xy);
   return o; 
  }

  sampler2D _prev_1; //Reference in Pass is necessary to let us use this variable in shaders
  sampler2D _prev_2;
  sampler2D _draw;

  fixed _width;
  fixed _height;
  fixed _speed;

  //Our Fragment Shader
  fixed4 frag (v2f i) : COLOR{

   fixed strideX = _speed/_width;
   fixed strideY = _speed/_height;

   fixed4 retval = tex2D(_prev_1, i.uv)*2 - tex2D(_prev_2, i.uv)
    + (
      tex2D(_prev_1, half2(i.uv.x+strideX, i.uv.y))
      +tex2D(_prev_1, half2(i.uv.x-strideX, i.uv.y))
      +tex2D(_prev_1, half2(i.uv.x, i.uv.y+strideY))
      +tex2D(_prev_1, half2(i.uv.x, i.uv.y-strideY))
      -tex2D(_prev_1, i.uv)*4
    ) * 0.5;

    fixed4 halfvec = fixed4(0.5,0.5,0.5,0);
    retval = halfvec + (retval - halfvec)*0.985;
    retval += tex2D(_draw, i.uv);

   fixed4 col = retval;// fixed4(avg, avg, avg, 1);

   return col;
  }
  ENDCG
 }
} 
 FallBack "Diffuse"
}