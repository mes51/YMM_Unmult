Texture2D InputTexture : register(t0);
SamplerState InputSampler : register(s0);

cbuffer constants : register(b0)
{
    int backgroundColorType : packoffset(c0);
}

float4 main(float4 pos : SV_POSITION, float4 posScene : SCENE_POSITION, float4 uv0 : TEXCOORD0) : SV_Target
{
	float4 color = InputTexture.Sample(InputSampler, uv0.xy);
    if (backgroundColorType == 1)
    {
        color = float4(1.0 - color.xyz, color.w);
    }
    float3 p = color.rgb * color.a;
    
    float irate = max(max(p.r, p.g), p.b);
    if (irate <= 0.0)
    {
        return float4(0.0, 0.0, 0.0, 0.0);
    }

    float3 t = p / irate;
    float ta = 0.0;
    if (t.b > 0.0)
    {
        ta = p.b / t.b;
    }
    else if (t.g > 0.0)
    {
        ta = p.g / t.g;
    }
    else if (t.r > 0.0)
    {
        ta = p.r / t.r;
    }
    
    if (ta > 0.0)
    {
        if (backgroundColorType == 1)
        {
            return float4((1.0 - t) * ta, ta);
        }
        else
        {
            return float4(t * ta, ta);
        }
    }
    else
    {
        return float4(0.0, 0.0, 0.0, 0.0);
    }
}