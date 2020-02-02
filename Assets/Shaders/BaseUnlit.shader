Shader "Unlit/BaseUnlit"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)
		_ShadowColor("ShadowColor", Color) = (0, 0, 0, 0.5)
    }
    SubShader
    {
        Tags { 
		    "LightMode"="ForwardBase"
		    "RenderType"="Opaque"
		}
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma multi_compile_fog

            #include "Lighting.cginc"
            #include "UnityCG.cginc"
			#pragma multi_compile_fwdbase 
            #include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				LIGHTING_COORDS(2, 3)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _Color;
			float4 _ShadowColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o, o.vertex);
				TRANSFER_VERTEX_TO_FRAGMENT(o);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				UNITY_APPLY_FOG(i.fogCoord, col);
                float atten = LIGHT_ATTENUATION(i);
				atten = step(0.8, atten);
				col = col * _Color;
				float3 shadow = lerp(1 - atten, (1 - atten) * _ShadowColor, _ShadowColor.a);
				if (atten == 0) {
					col = col * float4(shadow, 1);
				}
                return col;
            }
            ENDCG
        }
    }
		Fallback "VertexLit", 2
}
