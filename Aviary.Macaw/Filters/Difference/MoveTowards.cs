using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Difference
{
    public class MoveTowards : Filter
    {

        #region members

        protected Bitmap overlay = new Bitmap(100, 100);
        protected int size = 1;

        #endregion

        #region constructors

        public MoveTowards() : base()
        {
            SetFilter();
        }

        public MoveTowards(Bitmap overlay, int size) : base()
        {
            this.Overlay = overlay;
            this.size = size;
            SetFilter();
        }

        public MoveTowards(MoveTowards filter) : base(filter)
        {
            this.Overlay = filter.overlay;
            this.size = filter.size;
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

        public virtual int Size
        {
            get { return size; }
            set
            {
                size = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.MoveTowards newFilter = new Af.MoveTowards();
            newFilter.OverlayImage = Overlay;
            newFilter.StepSize = size;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Difference Move Towards";
        }

        #endregion

    }
}