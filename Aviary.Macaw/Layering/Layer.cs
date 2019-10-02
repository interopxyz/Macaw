using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviary.Macaw.Layering
{
    public class Layer
    {

        #region members

        public enum BlendModes { Normal = 0, Dissolve = 1, Multiply = 2, Screen = 3, Overlay = 4, Darken = 5, Lighten = 6, ColorDodge = 7, ColorBurn = 8, LinearDodge = 9, LinearBurn = 10, LighterColor = 11, DarkerColor = 12, HardLight = 13, SoftLight = 14, LinearLight = 16, PinLight = 17, Difference = 19, Exclusion = 20, Color = 23, Luminosity = 24 }
        public BlendModes BlendMode = BlendModes.Normal;

        private Bitmap image = new Bitmap(100, 100);
        private Bitmap mask = new Bitmap(100, 100);
        protected bool isMasked = false;
        public double Opacity = 100.0;

        public List<Modifier> Modifiers = new List<Modifier>();

        #endregion

        #region constructors

        public Layer()
        {

        }

        public Layer(Bitmap image)
        {
            this.image = (Bitmap)image.Clone();
        }

        public Layer(Bitmap image, Bitmap mask)
        {
            this.image = (Bitmap)image.Clone();
        }

        public Layer(Layer layer)
        {
            this.BlendMode = layer.BlendMode;
            this.image = layer.Image;
            this.mask = layer.Mask;
            this.isMasked = layer.isMasked;
            this.Opacity = layer.Opacity;
            foreach(Modifier modifier in layer.Modifiers)
            {
                this.Modifiers.Add(new Modifier(modifier));
            }
        }

        #endregion

        #region properties

        public virtual Bitmap Image
        {
            get { return (Bitmap)image.Clone(); }
            set { image = (Bitmap)value.Clone(); }
        }

        public virtual Bitmap Mask
        {
            get { return (Bitmap)mask.Clone(); }
            set {
                isMasked = true;
                mask = (Bitmap)value.Clone();
            }
        }

        public virtual bool IsMasked
        {
            get { return isMasked; }
        }

        #endregion

        #region methods



        #endregion

    }
}
