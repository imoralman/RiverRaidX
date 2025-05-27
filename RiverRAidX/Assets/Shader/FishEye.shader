{
    Shader "Hidden/FishEye"
    Properties
    {
        _Strength("Distortion Strength", Float) = 0.5
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }
        Pass
        {
            Name "FishEyePass"
            ZTest Always Cull Off ZWrite Off

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _Strength;

            Varyings Vert(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformVertex(input.positionOS);
                output.uv = input.uv;
                return output;
            }

            float4 Frag(Varyings i) : SV_Target
            {
                float2 uv = i.uv * 2.0 - 1.0; // [-1, 1]
                float r = length(uv);
                float k = _Strength;

                // Distortion formula
                float theta = atan2(uv.y, uv.x);
                float radius = pow(r, 1.0 - k);
                uv = float2(cos(theta), sin(theta)) * radius;

                uv = (uv + 1.0) * 0.5; // back to [0, 1]

                if (uv.x < 0 || uv.y < 0 || uv.x > 1 || uv.y > 1)
                    return float4(0, 0, 0, 1);

                return tex2D(_MainTex, uv);
            }
            ENDHLSL
        }
    }
}