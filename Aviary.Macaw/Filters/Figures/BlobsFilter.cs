using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aviary.Wind.Mathematics;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class BlobsFilter : Filter
    {

        #region members

        protected Domain height = new Domain(1, 100);
        protected Domain width = new Domain(1, 100);

        protected bool coupled = false;

        #endregion

        #region constructors

        public BlobsFilter() : base()
        {
            SetFilter();
        }

        public BlobsFilter(Domain width, Domain height, bool coupled) : base()
        {
            this.width = width;
            this.height= height;
            
            this.coupled = coupled;

            SetFilter();
        }


        public BlobsFilter(BlobsFilter filter) : base(filter)
        {
            this.width = filter.width;
            this.height = filter.height;

            this.coupled = filter.coupled;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Domain Width
        {
            get { return width; }
            set
            {
                width = value;
                SetFilter();
            }
        }

        public virtual Domain Height
        {
            get { return height; }
            set
            {
                height = value;
                SetFilter();
            }
        }

        public virtual bool Coupled
        {
            get { return coupled; }
            set
            {
                coupled = value;
                SetFilter();
            }
        }


        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.BlobsFiltering newFilter = new Af.BlobsFiltering();
            newFilter.MinWidth = (int)width.T0;
            newFilter.MaxWidth = (int)width.T1;
            newFilter.MinHeight = (int)height.T0;
            newFilter.MaxHeight = (int)height.T1;

            newFilter.CoupledSizeFiltering = coupled;

            imageFilter = newFilter;
        }

        #endregion

    }
}