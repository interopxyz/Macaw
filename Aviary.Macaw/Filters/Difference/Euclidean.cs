using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Difference
{
    public class Euclidean : Filter
    {

        #region members

        protected Bitmap overlay = new Bitmap(100,100);
        protected int threshold = 1;

        #endregion

        #region constructors

        public Euclidean() : base()
        {
            SetFilter();
        }

        public Euclidean(Bitmap overlay, int threshold) : base()
        {
            this.overlay = overlay;
            this.threshold = threshold;
            SetFilter();
        }

        public Euclidean(Euclidean filter) : base(filter)
        {
            this.overlay = filter.overlay;
            this.threshold = filter.threshold;
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

        public virtual int Threshold
        {
            get { return threshold; }
            set
            {
                threshold = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.ThresholdedEuclideanDifference newFilter = new Af.ThresholdedEuclideanDifference();
            newFilter.OverlayImage = overlay;
            newFilter.Threshold = threshold;

            imageFilter = newFilter;
        }

        #endregion

    }
}