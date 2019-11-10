using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class Histogram : Filter
    {

        #region members
        


        #endregion

        #region constructors

        public Histogram() : base()
        {
            SetFilter();
        }

        public Histogram(Histogram filter) : base(filter)
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
            Af.HistogramEqualization newFilter = new Af.HistogramEqualization();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Histogram";
        }

        #endregion

    }
}
