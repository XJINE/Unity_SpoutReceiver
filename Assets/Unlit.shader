Shader "Unlit/TextureBlack"
{
    Properties
    {
        [HideInInspector]
        _MainTex("Texture",  2D) = "gray" {}
    }
        SubShader
    {
        Pass
        {
            CGPROGRAM

            #include "UnityCG.cginc"
            #pragma vertex vert_img
            #pragma fragment frag

            sampler2D _MainTex;

            fixed4 frag(v2f_img input) : SV_Target
            {
                float4 color = tex2D(_MainTex, input.uv);
                return color;
            }

            ENDCG
        }
    }
}