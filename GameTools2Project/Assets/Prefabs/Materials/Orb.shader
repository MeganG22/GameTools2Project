Shader "Costumized/Orb"
{
	Properties{
	_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)   //Color of Orb (can be choosen in Unity)
	}
		SubShader{
		//Making whatever color the Orb will have to be Transparent
		  Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		  Blend SrcAlpha OneMinusSrcAlpha
		  Cull Off
		  LOD 200

		  CGPROGRAM
		  #pragma surface surf Lambert

		  fixed4 _Color;  //Setting the color

	struct Input {
	  float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {   //How color is choosen in Unity
	  o.Albedo = _Color.rgb;
	  o.Emission = _Color.rgb;
	  o.Alpha = _Color.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}