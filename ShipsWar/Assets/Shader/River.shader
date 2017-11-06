Shader "Custom/River2" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_MarginTex ("Margin (RGB)", 2D) = "white" {}
		_MaskTex ("Mask (RGB)", 2D) = "white" {}
		_Normal ("Normal (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Ajust ("Ajust", Range(-2,2)) = 0.0

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MarginTex;
		sampler2D _MaskTex;
		sampler2D _Normal;
		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		half _Ajust;
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed2 uv =fixed2(IN.uv_MainTex.x,IN.uv_MainTex.y+_Time.y*_Ajust);

			fixed4 c = tex2D (_MainTex, uv) * _Color;

			fixed2 uv2 =fixed2(IN.uv_MainTex.x,IN.uv_MainTex.y+_Time.x*_Ajust);

			fixed4 c2 = tex2D (_MarginTex, uv2) * _Color;

			fixed4 cmask = tex2D (_MaskTex, uv2) * _Color;

			fixed4 c3 =cmask*c2 ;

			o.Albedo = (c3+c)/2 ;
			fixed3 n =UnpackNormal(tex2D(_Normal, uv)) ;
			fixed3 n2 =UnpackNormal(tex2D(_Normal, uv2)) ;
			o.Normal =n+n2;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
