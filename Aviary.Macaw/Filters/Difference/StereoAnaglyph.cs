using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Difference
{
    public class StereoAnaglyph : Filter
    {

        #region members

        public enum Modes { Color ,Gray, HalfColor,Optimized, True};

        protected Modes mode = Modes.Color;
        protected Bitmap overlay = new Bitmap(100, 100);

        #endregion

        #region constructors

        public StereoAnaglyph() : base()
        {
            SetFilter();
        }

        public StereoAnaglyph(Bitmap overlay, Modes mode) : base()
        {
            this.mode = mode;
            this.Overlay = overlay;

            SetFilter();
        }

        public StereoAnaglyph(StereoAnaglyph filter) : base(filter)
        {
            this.mode = filter.mode;
            this.Overlay = filter.overlay;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Bitmap Overlay
        {
            get { return (Bitmap)overlay.Clone(); }
            set
            {
                overlay = value.ToAccordBitmap(ImageTypes.Rgb24bpp);
                SetFilter();
            }
        }

        public virtual Modes Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.StereoAnaglyph newFilter = new Af.StereoAnaglyph();
            newFilter.OverlayImage = Overlay;
            newFilter.AnaglyphAlgorithm = (Af.StereoAnaglyph.Algorithm)mode;

            imageFilter = newFilter;
        }

        #endregion

    }
}