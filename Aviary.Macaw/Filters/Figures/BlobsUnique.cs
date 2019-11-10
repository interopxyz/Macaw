using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aviary.Wind.Mathematics;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class BlobsUnique : Filter
    {

        #region members

        protected Domain height = new Domain(1,100);
        protected Domain width = new Domain(1, 100);
 
        protected bool blobs = false;
        protected bool coupled = false;

        #endregion

        #region constructors

        public BlobsUnique() : base()
        {
            SetFilter();
        }

        public BlobsUnique(Domain width, Domain height, bool blobs, bool coupled) : base()
        {
            this.width = width;
            this.height = height;

            this.blobs = blobs;
            this.coupled = coupled;

            SetFilter();
        }


        public BlobsUnique(BlobsUnique filter) : base(filter)
        {
            this.height = filter.height;
            this.width = filter.width;

            this.blobs = filter.blobs;
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

        public virtual bool Blobs
        {
            get { return blobs; }
            set
            {
                blobs = value;
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
            ImageType = ImageTypes.Rgb24bpp;
            Af.ConnectedComponentsLabeling newFilter = new Af.ConnectedComponentsLabeling();
            newFilter.MinWidth = (int)width.T0;
            newFilter.MaxWidth = (int)width.T1;
            newFilter.MinHeight = (int)height.T0;
            newFilter.MaxHeight = (int)height.T1;

            newFilter.CoupledSizeFiltering = coupled;
            newFilter.FilterBlobs = blobs;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Unique Blobs";
        }

        #endregion

    }
}