Shader "VertexColor/Unlit" {
Properties {
}

SubShader {

    Tags {Queue=Transparent}
    Blend SrcAlpha OneMinusSrcAlpha 
    ColorMask RGB
    Pass {
        Lighting Off
    	}
	}
}