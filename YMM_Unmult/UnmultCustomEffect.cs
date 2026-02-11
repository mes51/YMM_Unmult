using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using Vortice.Direct2D1.Effects;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace mes51.YMM_Unmult
{
    class UnmultCustomEffect : D2D1CustomShaderEffectBase
    {
        public UnmultCustomEffect(IGraphicsDevicesAndContext devices) : base(Create<EffectImpl>(devices)) { }

        public int BackgroundColorType
        {
            get => GetIntValue((int)EffectProperty.BackgroundColorType);
            set => SetValue((int)EffectProperty.BackgroundColorType, value);
        }
    }

    [CustomEffect(1)]
    file class EffectImpl : D2D1CustomShaderEffectImplBase<EffectImpl>
    {
        public EffectImpl() : base(GetShader()) { }

        [CustomEffectProperty(PropertyType.Int32, (int)EffectProperty.BackgroundColorType)]
        public int BackgroundColorType
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    UpdateConstants();
                }
            }
        }

        protected override void UpdateConstants()
        {
            drawInformation?.SetPixelShaderConstantBuffer(new EffectParameter(BackgroundColorType));
        }

        static byte[] GetShader()
        {
            var assembly = typeof(EffectImpl).Assembly;
            using var stream = assembly.GetManifestResourceStream("Unmult_Shader.cso");
            if (stream != null)
            {
                var result = new byte[stream.Length];
                stream.ReadExactly(result);
                return result;
            }
            else
            {
                return [];
            }
        }
    }

    file enum EffectProperty : int
    {
        BackgroundColorType = 0
    }

    [StructLayout(LayoutKind.Explicit)]
    file readonly record struct EffectParameter(int BackgroundColorType)
    {
        [FieldOffset(0)]
        public readonly int BackgroundColorType = BackgroundColorType;
    }
}
