using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Dither
{
    public class JarvisJudiceNinke : Filter
    {

        #region members

        protected int threshold = 4;

        #endregion

        #region constructors

        public JarvisJudiceNinke() : base()
        {
            SetFilter();
        }

        public JarvisJudiceNinke(int threshold) : base()
        {
            this.threshold = threshold;
            SetFilter();
        }

        public JarvisJudiceNinke(JarvisJudiceNinke filter) : base(filter)
        {
            this.threshold = filter.threshold;
            SetFilter();
        }

        #endregion

        #region properties

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
            ImageType = ImageTypes.GrayscaleBT709;
            Af.JarvisJudiceNinkeDithering newFilter = new Af.JarvisJudiceNinkeDithering();
            newFilter.ThresholdValue = (byte)threshold;
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Dither Jarvis Judice Ninke";
        }

        #endregion

    }
}