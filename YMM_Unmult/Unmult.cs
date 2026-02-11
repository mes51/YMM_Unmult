using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace mes51.YMM_Unmult
{
    [VideoEffect("Unmult", ["‰ÁH"], [])]
    public class Unmult : VideoEffectBase
    {
        [Display(Name = "”wŒiF", Description = "”wŒi‚Éd‚Ë‚ç‚ê‚½F‚ðŽw’è‚µ‚Ü‚·")]
        [EnumComboBox]
        public BackgroundColorType BackgroundColorType
        {
            get;
            set => Set(ref field, value);
        }

        public override string Label => "Unmult";

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return [];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new UnmultProcessor(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables()
        {
            return [];
        }
    }
}
