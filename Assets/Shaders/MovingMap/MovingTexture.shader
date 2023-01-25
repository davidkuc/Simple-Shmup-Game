Shader "Unlit/MovingTexture"
{
    Properties 
    { 
        [NoScaleOffset] _MainTex("Main Texture", 2D) = "white" {}
        _Speed("Speed", Float) = 1
    }
    SubShader 
    {
        Tags 
        {
            "RenderType"="Opaque" 
        }

        Pass
        {       
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            sampler2D _MainTex;   
            float _Speed;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv: TEXCOORD0;
            };
            
            v2f vert ( appdata_base v )
            {
                v2f o;
                o.vertex = UnityObjectToClipPos( v.vertex );
                o.uv = v.texcoord;

                float xAxisTextureMovement = ( _Time.y * _Speed / 10 ) * -1;
                o.uv.x += xAxisTextureMovement;

                return o;
            }

            float4 frag ( v2f i ) : SV_TARGET
            {
                float4 color = tex2D( _MainTex, i.uv ) ;
                return color;
            }
            
            ENDCG
        }
    }
}
