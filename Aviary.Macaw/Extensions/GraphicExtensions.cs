using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sd = SoundInTheory.DynamicImage;
using Wg = Aviary.Wind.Graphics;

namespace Aviary.Macaw
{
    public static class GraphicExtensions
    {

        public static Sd.Color ToDynamicColor(this Wg.Color input)
        {
            Sd.Color color = new Sd.Color();
            color.A = (byte)input.A;
            color.R = (byte)input.R;
            color.G = (byte)input.G;
            color.B = (byte)input.B;

            return color;
        }

        public static Sd.Fill ToFill(this Wg.Color input)
        {
            Sd.Fill fill = new Sd.Fill();
            fill.BackgroundColor = input.ToDynamicColor();

            return fill;
        }

    }
}
