using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class BlobsUnique : Filter
    {

        #region members

        protected int minHeight = 1;
        protected int maxHeight = 100;
        protected int minWidth = 1;
        protected int maxWidth = 100;

        protected bool blobs = false;
        protected bool coupled = false;

        #endregion

        #region constructors

        public BlobsUnique() : base()
        {
            SetFilter();
        }

        public BlobsUnique(int minWidth, int maxWidth, int minHeight, int maxHeight, bool blobs, bool coupled) : base()
        {
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
            this.minWidth = minWidth;
            this.maxWidth = maxWidth;

            this.blobs = blobs;
            this.coupled = coupled;

            SetFilter();
        }


        public BlobsUnique(BlobsUnique filter) : base(filter)
        {
            this.minHeight = filter.minHeight;
            this.maxHeight = filter.maxHeight;
            this.minWidth = filter.minWidth;
            this.maxWidth = filter.maxWidth;

            this.blobs = filter.blobs;
            this.coupled = filter.coupled;

            SetFilter();
        }

        #endregion

        #region properties
        
        public virtual int MinWidth
        {
            get { return minWidth; }
            set
            {
                minWidth = value;
                SetFilter();
            }
        }

        public virtual int MaxWidth
        {
            get { return maxWidth; }
            set
            {
                maxWidth = value;
                SetFilter();
            }
        }

        public virtual int MinHeight
        {
            get { return minHeight; }
            set
            {
                minHeight = value;
                SetFilter();
            }
        }

        public virtual int MaxHeight
        {
            get { return maxHeight; }
            set
            {
                maxHeight = value;
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
            ImageType = ImageTypes.Rgb32bpp;
            Af.ConnectedComponentsLabeling newFilter = new Af.ConnectedComponentsLabeling();
            newFilter.MinWidth = minWidth;
            newFilter.MaxWidth = maxWidth;
            newFilter.MinHeight = minHeight;
            newFilter.MaxHeight = maxHeight;

            newFilter.CoupledSizeFiltering = coupled;
            newFilter.FilterBlobs = blobs;

            imageFilter = newFilter;
        }

        #endregion

    }
}