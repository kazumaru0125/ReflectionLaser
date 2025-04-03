Shader "Custom/Mirror"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _ReflectTex("Reflection Texture", 2D) = "black" { }
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            #pragma surface surf Standard fullforwardshadows

            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            sampler2D _MainTex;
            sampler2D _ReflectTex;

            struct Input
            {
                float2 uv_MainTex;
                float2 uv_ReflectTex;
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _Color;

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                // Albedo comes from a texture tinted by color
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Alpha = c.a;
                // Metallic and smoothness come from slider variables
                o.Metallic = _Metallic;
                o.Smoothness = _Glossiness;

                // 反射テクスチャを適用（Planar Reflection）
                // 鏡面反射の部分を反射テクスチャでサンプリング
                fixed4 reflectColor = tex2D(_ReflectTex, IN.uv_ReflectTex);
                o.Albedo = lerp(o.Albedo, reflectColor.rgb, 0.8); // 反射をブレンド（強度調整）
            }
            ENDCG
        }
            FallBack "Diffuse"
}
