using System;
using System.Collections.Generic;
using System.Linq;
using YMM_Unmult;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace mes51.YMM_Unmult
{
    [VideoEffect("Unmult", new string[] { "‰ÁH" }, new string[] { })]
    public class Unmult : VideoEffectBase
    {
        public override string Label => "Unmult";

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return Enumerable.Empty<string>();
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new UnmultProcessor(devices);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables()
        {
            return Enumerable.Empty<IAnimatable>();
        }
    }
}
