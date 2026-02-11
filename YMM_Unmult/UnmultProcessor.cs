using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Player.Video.Effects;

namespace mes51.YMM_Unmult
{
    class UnmultProcessor : IVideoEffectProcessor
    {
        public ID2D1Image Output => OutputInternal ?? Input ?? throw new NullReferenceException();

        ID2D1Image? Input { get; set; }

        ID2D1Image? OutputInternal { get; set; }

        UnmultCustomEffect Effect { get; }

        Unmult Item { get; }

        public UnmultProcessor(IGraphicsDevicesAndContext devices, Unmult item)
        {
            Effect = new UnmultCustomEffect(devices);
            Item = item;
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

        public void SetInput(ID2D1Image? input)
        {
            Input = input;
            if (Effect.IsEnabled)
            {
                Effect.SetInput(0, input, true);
            }
        }

        public DrawDescription Update(EffectDescription effectDescription)
        {
            Effect.BackgroundColorType = (int)Item.BackgroundColorType;
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
