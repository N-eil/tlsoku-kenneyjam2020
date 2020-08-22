using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runes
{
    public class VisionRune : Rune
    {
        public override string Description { get => $"Increases vision by {Constants.VISION_RUNE_INCREASE}."; }
    }
}
