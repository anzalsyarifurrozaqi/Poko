void ToonShading_float(
    in float3 normal, 
    in float toonRampSmoothness, 
    in float3 clipSpacePos, 
    in float3 worldSpace,
    in float4 toonRampTinting,
    in float toonRampOffset,
    out float3 toonRampOutput, 
    out float3 direction)
{
    // set the shader graph node previews
    #ifdef SHADERGRAPH_PREVIEW
        toonRampOutput = float3(0.5, 0.5, 0);
        direction = float3(0.5, 0.5, 0);
    #else
        // grab the shadow coordinates
        #if SHADOW_SCREEN
            half4 shadowCoord = ComputerScreenPos(clipSpacePos);
        #else
            half4 shadowCoord = TransformWorldToShadowCoord(worldSpace);
        #endif
        
        // grap the main ligth
        #if _MAIN_LIGHT_SHADOW_CASCADE || _MAIN_LIGHT_SHADOWS
            Light light = GetMainLight(shadowCoord);
        #else
            Light light = GetMainLight();
        #endif
    
        // dot product for toonramp
        half d = dot(normal, light.direction) * 0.5 + 0.5;
    
        // toonramp in a smoothstep
        half toonRamp = smoothstep(toonRampOffset, toonRampOffset + toonRampSmoothness, d);
        
        // multiply with shadow
        toonRamp *= light.shadowAttenuation;
        
        // add in lights and extra tinting
        toonRampOutput = light.color * (toonRamp + toonRampTinting);
    
        // output direction for rimlight
        direction = light.direction;
    #endif
}