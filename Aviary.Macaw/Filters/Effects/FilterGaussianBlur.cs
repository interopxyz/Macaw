using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterGaussianBlur : Filter
    {

        #region members

        protected double sigma = 0;
        protected int size = 1;

        #endregion

        #region constructors

        public FilterGaussianBlur() : base()
        {
            SetFilter();
        }

        public FilterGaussianBlur(double sigma, int size) : base()
        {
            this.sigma = sigma;
            this.size = size;
            SetFilter();
        }

        public FilterGaussianBlur(FilterGaussianBlur filter) : base(filter)
        {
            this.sigma = filter.sigma;
            this.size = filter.size;

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

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            GaussianBlur newFilter = new GaussianBlur();
            newFilter.Sigma = sigma;
            newFilter.Size = size;
            imageFilter = newFilter;
        }

        #endregion

    }
}