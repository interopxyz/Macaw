using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af=Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Smoothing
{
    public class Median : Filter
    {

        #region members



        #endregion

        #region constructors

        public Median() : base()
        {
            SetFilter();
        }

        public Median(Median filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties



        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.Median newFilter = new Af.Median();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Median Smoothing";
        }

        #endregion

    }
}
