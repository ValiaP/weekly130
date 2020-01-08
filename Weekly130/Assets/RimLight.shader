Shader "Reflective/Specular_Color/alpha_rim" {
Properties {
_Color ("Main Color", Color) = (1,1,1,1)
_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
_Cube ("Reflection Cubemap", Cube) = "_Skybox" { TexGen CubeReflect }
_RimColor ("Rim Color", Color) = (1,1,1,0.5)
_RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
}
SubShader {
Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
LOD 200

CGPROGRAM
#pragma surface surf BlinnPhong alpha
struct Input {
float3 worldRefl;
float3 viewDir;
};
fixed4 _Color;
samplerCUBE _Cube;
fixed4 _RimColor;
fixed4 _ReflectColor;
half _RimPower;
half _Shininess;

void surf (Input IN, inout SurfaceOutput o) {
fixed4 reflcol = texCUBE(_Cube, IN.worldRefl);
fixed4 c = _Color * reflcol ;
half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
o.Albedo = c.rgb * _RimColor.rgb * pow (rim, _RimPower);
o.Alpha = c.a + _RimColor.rgb * pow (rim, _RimPower);
o.Gloss = c.a;
o.Specular = _Shininess;

o.Emission = _ReflectColor * reflcol.rgb * _RimColor.rgb * pow (rim, _RimPower);
}
ENDCG
}

Fallback "Transparent/VertexLit"
}