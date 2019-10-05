using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
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
            HistogramEqualization newFilter = new HistogramEqualization();
            imageFilter = newFilter;
        }

        #endregion

    }
}
