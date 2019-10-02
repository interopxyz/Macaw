using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sd = System.Drawing;

using Aviary.Wind;

using Ag = Accord.Math.Geometry;
using Ai = Accord.Imaging;
using Rg = Rhino.Geometry;
using Wg = Aviary.Wind.Graphics;

namespace Aviary.Macaw
{
    public static class AccordExtensions
    {

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
