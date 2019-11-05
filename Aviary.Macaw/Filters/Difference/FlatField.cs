using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Difference
{
    public class FlatField : Filter
    {

        #region members

        protected Bitmap overlay = new Bitmap(100, 100);

        #endregion

        #region constructors

        public FlatField() : base()
        {
            SetFilter();
        }

        public FlatField(Bitmap overlay) : base()
        {
            this.Overlay = overlay;

            SetFilter();
        }

        public FlatField(FlatField filter) : base(filter)
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
            Af.FlatFieldCorrection newFilter = new Af.FlatFieldCorrection();
            newFilter.BackgoundImage = Overlay;

            imageFilter = newFilter;
        }

        #endregion

    }
}