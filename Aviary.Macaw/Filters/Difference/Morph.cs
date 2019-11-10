using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Difference
{
    public class Morph : Filter
    {

        #region members

        protected Bitmap overlay = new Bitmap(100, 100);
        protected double percent = 1.0;

        #endregion

        #region constructors

        public Morph() : base()
        {
            SetFilter();
        }

        public Morph(Bitmap overlay, double percent) : base()
        {
            this.Overlay = overlay;
            this.percent = percent;

            SetFilter();
        }

        public Morph(Morph filter) : base(filter)
        {
            this.Overlay = filter.overlay;
            this.percent = filter.percent;

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

        public virtual double Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.Morph newFilter = new Af.Morph();
            newFilter.OverlayImage = Overlay;
            newFilter.SourcePercent = percent;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Difference Morph";
        }

        #endregion

    }
}