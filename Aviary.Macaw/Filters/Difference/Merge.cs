using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Difference
{
    public class Merge : Filter
    {

        #region members

        protected Bitmap overlay = new Bitmap(100, 100);

        #endregion

        #region constructors

        public Merge() : base()
        {
            SetFilter();
        }

        public Merge(Bitmap overlay) : base()
        {
            this.Overlay = overlay;

            SetFilter();
        }

        public Merge(Merge filter) : base(filter)
        {
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

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.Merge newFilter = new Af.Merge();
            newFilter.OverlayImage = Overlay;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Difference Merge";
        }

        #endregion

    }
}