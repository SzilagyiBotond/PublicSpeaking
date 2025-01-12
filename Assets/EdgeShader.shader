Shader "Custom/EdgeShader"
{
    Properties
    {
        _EdgeColor ("Edge Color", Color) = (1,1,1,1)
        _EdgeWidth ("Edge Width", Range(0, 1)) = 0.1
        [Toggle] _Debug ("Show Debug", Float) = 0
    }
    SubShader
    {
        Tags { 
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

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
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 localPos : TEXCOORD1;
                float3 normal : NORMAL;
            };

            float4 _EdgeColor;
            float _EdgeWidth;
            float _Debug;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                // Scale the local position to ensure it's in 0-1 range
                o.localPos = v.vertex.xyz + 0.5;
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Ensure local position is in 0-1 range
                float3 normalizedPos = frac(i.localPos);
                
                // Check if we're near any edge
                float edgeX = min(normalizedPos.x, 1 - normalizedPos.x) < _EdgeWidth;
                float edgeY = min(normalizedPos.y, 1 - normalizedPos.y) < _EdgeWidth;
                float edgeZ = min(normalizedPos.z, 1 - normalizedPos.z) < _EdgeWidth;
                
                // Combine edges
                float edge = max(max(edgeX, edgeY), edgeZ);
                
                // Debug visualization
                if (_Debug)
                {
                    return float4(normalizedPos, 1);
                }
                
                // Return edge color with proper alpha
                float4 color = _EdgeColor;
                color.a *= edge;
                return color;
            }
            ENDCG
        }
    }
}