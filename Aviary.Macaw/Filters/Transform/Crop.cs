using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Transform
{
    public class Crop : Filter
    {

        #region members

        protected bool originalSize = false;
        protected Color color = Color.Transparent;
        protected Rectangle region = new Rectangle(0, 0, 100, 100);

        #endregion

        #region constructors

        public Crop() : base()
        {
            SetFilter();
        }

        public Crop(bool originalSize, Color color, Rectangle region) : base()
        {
            this.originalSize = originalSize;
            this.color = color;
            this.region = region;

            SetFilter();
        }

        public Crop(Crop filter) : base(filter)
        {
            this.originalSize = filter.originalSize;
            this.color = filter.color;
            this.region = filter.region;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual bool OriginalSize
        {
            get { return originalSize; }
            set
            {
                originalSize = value;
                SetFilter();
            }
        }

        public virtual Color BackgroundColor
        {
            get { return color; }
            set
            {
                color = value;
                SetFilter();
            }
        }

        public virtual Rectangle Region
        {
            get { return region; }
            set
            {
                region = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.ARgb32bpp;

            if (originalSize)
            {
                Af.CanvasCrop newFilter = new Af.CanvasCrop(region);
                newFilter.FillColorRGB = color;

                imageFilter = newFilter;
            }
            else
            {
                Af.Crop newFilter = new Af.Crop(region);
                imageFilter = newFilter;
            }

        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Xform Crop";
        }

        #endregion

    }
}