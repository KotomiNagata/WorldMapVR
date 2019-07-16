Shader "Custom/LightWave"
{
    Properties
    {
        _Color ("_Color", Color) = (1, 1, 1, 1)
        _Flat ("_Flat", Range(0, 1)) = 1
        _NoiseScale ("_NoiseScale", Range(0, 5)) = 1
        _NoiseAmount ("_NoiseAmount", Range(0, 10)) = 3
        _NoiseTime ("_NoiseTime", Range(0, 5)) = 1
    }
    SubShader
    {
        Tags { "LightMode"="ForwardBase" "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #pragma target 5.0

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"
            #include "ProceduralNoise/SimplexNoise4D.cginc"

            fixed4 _Color;
            float _Flat;
            float _NoiseScale;
            float _NoiseAmount;
            float _NoiseTime;

            struct appdata
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };

            struct v2g
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
                float3 normal : TEXCOORD1;
            };

            struct g2f
            {
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD0;
                fixed4 diff : COLOR0;
            };

            v2g vert (appdata v)
            {
                v2g o;
                v.pos.xyz += v.normal * (simplexNoise(float4(v.pos.xyz * _NoiseScale, _Time.x * _NoiseTime)) * 0.5 + 0.5) * _NoiseAmount;
                o.pos = UnityObjectToClipPos(v.pos);
                o.worldPos = mul(unity_ObjectToWorld, v.pos).xyz;
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            [maxvertexcount(3)]
            void geom (triangle v2g input[3], inout TriangleStream<g2f> outStream)
            {
                float3 wp0 = input[0].worldPos;
                float3 wp1 = input[1].worldPos;
                float3 wp2 = input[2].worldPos;
                float3 normal = normalize(cross(wp1 - wp0, wp2 - wp1));

                g2f output0;
                output0.pos = input[0].pos;
                output0.normal = lerp(input[0].normal, normal, _Flat);
                output0.diff = max(0, dot(output0.normal, _WorldSpaceLightPos0.xyz)) * _LightColor0;

                g2f output1;
                output1.pos = input[1].pos;
                output1.normal = lerp(input[1].normal, normal, _Flat); 
                output1.diff = max(0, dot(output0.normal, _WorldSpaceLightPos0.xyz)) * _LightColor0;

                g2f output2;
                output2.pos = input[2].pos;
                output2.normal = lerp(input[2].normal, normal, _Flat); 
                output2.diff = max(0, dot(output0.normal, _WorldSpaceLightPos0.xyz)) * _LightColor0;

                outStream.Append(output0);
                outStream.Append(output1);
                outStream.Append(output2);
            }

            fixed4 frag (g2f i) : SV_Target
            {
                return _Color * i.diff;
            }
            ENDCG
        }
    }
}
