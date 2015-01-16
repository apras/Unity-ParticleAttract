Shader "Custom/ParticleColorAdd"
{
	Properties
	{
 		_MainTex ("Particle Texture", 2D) = "white" {}
	}
	
	SubShader
	{ 
 		Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 		
 		Pass
 		{
  			Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  			
  			BindChannels
  			{
   				Bind "vertex", Vertex
   				Bind "color", Color
   				Bind "texcoord", TexCoord
  			}
  
  			ZWrite Off
  			Cull Off
  			Fog { Color (0,0,0,0) }
  			
  			//Blend SrcAlpha One
  			Blend SrcAlpha OneMinusSrcAlpha
  			SetTexture [_MainTex] { combine /*texture * */primary, texture  }
		} 		
 		
 		
 		Pass
 		{
  			Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  			
  			BindChannels
  			{
   				Bind "vertex", Vertex
   				Bind "color", Color
   				Bind "texcoord", TexCoord
  			}
  
  			ZWrite Off
  			Cull Off
  			Fog { Color (0,0,0,0) }
  			
  			//Blend SrcAlpha One
  			Blend SrcAlpha One
  			//Blend OneMinusDstColor One
  			SetTexture [_MainTex] { combine texture/* + primary, texture*/ }
		}
		
	}
}