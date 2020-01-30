Shader "Unlit/New"
{
    Properties 
    {
        _MainTex ("Aqui va el nombre de fuera, el de compilacion", 2D) = "white" {}
		_Color1("Color1", Color) = (1,1,1,1)
		_Color2("Color2", Color) = (1,1,1,1)

	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" "RenderQueue" = "2000" }
			

        Pass
        {
            CGPROGRAM
            #pragma vertex vert 
            #pragma fragment frag 

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float4 vColor : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float4 vColor : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST; 
			float4 _Color1;
			float4 _Color2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.vColor = v.vColor;
                return o;
            }

			fixed4 frag(v2f i) : SV_Target
			{
			fixed4 col = tex2D(_MainTex, i.uv); 
			clip(col.r - (1 - i.vColor.a) - 0.01);
			return i.vColor + lerp(_Color1, _Color2, _SinTime.y*2);
			}
            ENDCG
        }
    }
}
