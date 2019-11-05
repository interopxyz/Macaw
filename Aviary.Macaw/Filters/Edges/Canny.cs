using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Edges
{
    public class Canny : Filter
    {

        #region members

        protected double sigma = 1.0;
        protected int size = 1;
        protected int lowThreshold = 1;
        protected int highThreshold = 1;

        #endregion

        #region constructors

        public Canny() : base()
        {
            SetFilter();
        }

        public Canny(double sigma, int size, int lowThreshold, int highThreshold) : base()
        {
            this.sigma = sigma;
            this.size = size;
            this.lowThreshold = lowThreshold;
            this.highThreshold = highThreshold;
            SetFilter();
        }

        public Canny(Canny filter) : base(filter)
        {
            this.sigma = filter.sigma;
            this.size = filter.size;
            this.lowThreshold = filter.lowThreshold;
            this.highThreshold = filter.highThreshold;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Sigma
        {
            get { return sigma; }
            set
            {
                sigma = value;
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
        public virtual int LowThreshold
        {
            get { return lowThreshold; }
            set
            {
                lowThreshold = value;
                SetFilter();
            }
        }
        public virtual int HighThreshold
        {
            get { return highThreshold; }
            set
            {
                highThreshold = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.GrayscaleBT709;
            Af.CannyEdgeDetector newFilter = new Af.CannyEdgeDetector();
            newFilter.GaussianSigma = sigma;
            newFilter.GaussianSize = size;
            newFilter.LowThreshold = (byte)lowThreshold;
            newFilter.HighThreshold = (byte)highThreshold;

            imageFilter = newFilter;
        }

        #endregion

    }
}