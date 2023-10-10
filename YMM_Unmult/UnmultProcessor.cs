using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Player.Video.Effects;

namespace YMM_Unmult
{
    class UnmultProcessor : IVideoEffectProcessor
    {
        public ID2D1Image Output => OutputInternal ?? Input ?? throw new NullReferenceException();

        ID2D1Image? Input { get; set; }

        ID2D1Image? OutputInternal { get; set; }

        UnmultCustomEffect Effect { get; }

        public UnmultProcessor(IGraphicsDevicesAndContext devices)
        {
            Effect = new UnmultCustomEffect(devices);
            if (Effect.IsEnabled)
            {
                OutputInternal = Effect.Output;
            }
        }

        public void ClearInput()
        {
            if (Effect.IsEnabled)
            {
                Effect.SetInput(0, null, true);
            }
        }

        public void SetInput(ID2D1Image input)
        {
            Input = input;
            if (Effect.IsEnabled)
            {
                Effect.SetInput(0, input, true);
            }
        }

        public DrawDescription Update(EffectDescription effectDescription)
        {
            return effectDescription.DrawDescription;
        }

        public void Dispose()
        {
            Output?.Dispose();
            if (Effect.IsEnabled)
            {
                Effect.SetInput(0, null, true);
            }
            Effect.Dispose();
        }
    }
}
