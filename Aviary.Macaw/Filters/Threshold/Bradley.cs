using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Threshold
{
    public class Bradley : Filter
    {

        #region members

        protected double brightness = 1.0;
        protected int window = 1;

        #endregion

        #region constructors

        public Bradley() : base()
        {
            SetFilter();
        }

        public Bradley(double brightness, int window) : base()
        {
            this.brightness = brightness;
            this.window = window;

            SetFilter();
        }

        public Bradley(Bradley filter) : base(filter)
        {
            this.brightness = filter.brightness;
            this.window = filter.window;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Brightness
        {
            get { return brightness; }
            set
            {
                brightness = value;
                SetFilter();
            }
        }

        public virtual int Window
        {
            get { return window; }
            set
            {
                window = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.GrayscaleBT709;
            Af.BradleyLocalThresholding newFilter = new Af.BradleyLocalThresholding();
            newFilter.PixelBrightnessDifferenceLimit = (float)brightness;
            newFilter.WindowSize = window;

            imageFilter = newFilter;
        }

        #endregion

    }
}