using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sd = System.Drawing;

using Wm = Aviary.Wind.Mathematics;

using Ag = Accord.Math.Geometry;
using Ai = Accord.Imaging;
using Rg = Rhino.Geometry;
using Wg = Aviary.Wind.Graphics;

namespace Aviary.Macaw
{
    public static class AccordExtensions
    {

        public static Wm.Domain ToInterval(this Accord.IntRange input)
        {
            return new Wm.Domain(input.Min, input.Max);
        }

        public static Accord.IntRange ToIntRange(this Wm.Domain input)
        {
            return new Accord.IntRange((int)input.T0, (int)input.T1);
        }

        public static Rg.Rectangle3d GetRhRect(this Ai.Blob input, int transposition = 0)
        {
            return input.Rectangle.ToRhinoRectangle(transposition);
        }
        
        public static Sd.Bitmap GetBitmap(this Ai.Blob input)
        {
            return (Sd.Bitmap)input.Image.ToManagedImage().Clone();
        }

    }
}
