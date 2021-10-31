﻿/*
	Screen-Spaced Texture Based Outline Shader written by The Developer
	
	*this shader is affected by:
		- shadows
		- skybox
		- reflections
		- everything you see on the screen

	▁▂▅▆▇ Social Media and Contacts ▇▆▅▂▁
	• WEBSITE - https://thedevelopers.tech
	• YOUTUBE - https://www.youtube.com/channel/UCwO0k5dccZrTW6-GmJsiFrg
	• FACEBOOK - https://www.facebook.com/VicTor-372230180173180
	• INSTAGRAM - https://www.instagram.com/thedeveloper10/
	• TWITTER - https://twitter.com/the_developer10
	• LINKEDIN - https://www.linkedin.com/company/65346254
*/

Shader "The Developer/SS Texture Based Outline"
{
    Properties
    {
    	_OutlineColor("Outline Color", Color) = (100,1,1,1)
    	_OutlineThreshold("Outline Threshold", Float) = 5
    	_OutlineWidth("Outline Width", Float) = 2
    	_EdgeStrengthen ("Edge Strengthen", Float) = 2
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        // Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };    

            struct v2f
            {
                float4 position : POSITION;
                float4 screenPos : TEXCOORD0;
            };

            fixed4 _OutlineColor;
            half _OutlineThreshold;
            half _OutlineWidth;
            half _EdgeStrengthen;
            sampler2D _CameraDepthTexture;
            sampler2D _MainTex;

            v2f vert(appdata input)
            {
                v2f output;

                output.position = UnityObjectToClipPos(input.vertex);
                output.screenPos = output.position;

                return output;
            }

            #define PSL01UVC(tex, uv1, uv2) pow(\
                (tex2D(tex, uv1) - tex2D(tex, uv2)) * _EdgeStrengthen, \
                2)

            float4 outline;
            half4 pixel;
            half2 uv;
            half onePixelW, onePixelH;
            fixed i;
            void OutlinePixel(sampler2D tex){
            	outline = 0;
            	for(i = 1 ; i <= _OutlineWidth ; ++i)
	            	outline += 
	                        PSL01UVC(tex, half2(uv.x - i * onePixelW, uv.y), 
                                          half2(uv.x + i * onePixelW, uv.y)) + 

                            PSL01UVC(tex, half2(uv.x, uv.y + i * onePixelH), 
                                          half2(uv.x, uv.y - i * onePixelH)) + 

                            PSL01UVC(tex, half2(uv.x - i * onePixelW, uv.y - i * onePixelH), 
                                          half2(uv.x + i * onePixelW, uv.y + i * onePixelH)) + 

                            PSL01UVC(tex, half2(uv.x - i * onePixelW, uv.y + i * onePixelH), 
                                          half2(uv.x + i * onePixelW, uv.y - i * onePixelH));
            }

            half4 frag(v2f input) : SV_Target
            {    
                uv = input.screenPos.xy / input.screenPos.w;
                uv.x = (uv.x + 1) * .5;
                uv.y = (uv.y + 1) * .5;

                pixel = tex2D(_MainTex, uv);

                onePixelW = 1.0 / _ScreenParams.x;
                onePixelH = 1.0 / _ScreenParams.y;

                OutlinePixel(_MainTex);

                return lerp(pixel, _OutlineColor, (outline.r + outline.g + outline.b) >= _OutlineThreshold ? 1 : 0);
            }    
            ENDCG
        }
    }
}
