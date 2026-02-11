using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mes51.YMM_Unmult
{
    public enum BackgroundColorType : int
    {
        [Display(Name = "黒", Description = "黒背景に重ねられた画像として処理します")]
        Black = 0,
        [Display(Name = "白", Description = "白背景に重ねられた画像として処理します")]
        White
    }
}
