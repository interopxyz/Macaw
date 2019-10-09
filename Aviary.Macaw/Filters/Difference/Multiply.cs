using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Difference
{
    public class Multiply : Filter
    {

        #region members

        protected Bitmap overlay = new Bitmap(100, 100);

        #endregion

        #region constructors

        public Multiply() : base()
        {
            SetFilter();
        }

        public Multiply(Bitmap overlay) : base()
        {
            this.overlay = overlay;

            SetFilter();
        }

        public Multiply(Multiply filter) : base(filter)
        {
            this.overlay = filter.overlay;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Bitmap Overlay
        {
            get { return overlay; }
            set
            {
                overlay = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.Multiply newFilter = new Af.Multiply();
            newFilter.OverlayImage = overlay;

            imageFilter = newFilter;
        }

        #endregion

    }
}