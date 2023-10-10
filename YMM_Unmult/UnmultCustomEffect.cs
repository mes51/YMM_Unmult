using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace YMM_Unmult
{
    class UnmultCustomEffect : D2D1CustomShaderEffectBase
    {
        public UnmultCustomEffect(IGraphicsDevicesAndContext devices) : base(Create<EffectImpl>(devices)) { }
    }

    [CustomEffect(1)]
    file class EffectImpl : D2D1CustomShaderEffectImplBase<EffectImpl>
    {
        public EffectImpl() : base(GetShader()) { }

        protected override void UpdateConstants() { }

        static byte[] GetShader()
        {
            var assembly = typeof(EffectImpl).Assembly;
            using var stream = assembly.GetManifestResourceStream("Unmult_Shader.cso");
            if (stream != null)
            {
                var result = new byte[stream.Length];
                stream.Read(result, 0, result.Length);
                return result;
            }
            else
            {
                return Array.Empty<byte>();
            }
        }
    }
}
