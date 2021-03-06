﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw
{
    public class Filter
    {

        #region members

        public enum ImageTypes { GrayscaleBT709, GrayscaleRMY, GrayscaleY, GrayScale16bpp, Rgb16bpp, Rgb24bpp, Rgb32bpp, ARgb32bpp, Rgb48bpp, Rgb64bpp, None};
        public ImageTypes ImageType = ImageTypes.None;

        protected Af.IFilter imageFilter = new Af.Invert();

        #endregion

        #region constructors

        public Filter()
        {

        }

        public Filter(Filter filter)
        {
            this.ImageType = filter.ImageType;
            this.imageFilter = filter.imageFilter;
        }
        
        #endregion

        #region properties
        
        public virtual Af.IFilter FilterObject
        {
            get { return imageFilter; }
        }

        #endregion

        #region methods

        protected double Remap(double t, double min, double max)
        {
            return (min + (max - min) * t);
        }

        public Filter GetDefault()
        {
            Filter filter = new Filter();
            filter.ImageType = ImageTypes.Rgb24bpp;
            filter.imageFilter = new Af.Mirror(false, false);

            return filter;
        }

        #endregion

    }
}
