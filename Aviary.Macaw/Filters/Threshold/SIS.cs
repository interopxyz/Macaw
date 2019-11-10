using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Threshold
{
    public class SIS : Filter
    {

        #region members
        

        #endregion

        #region constructors

        public SIS() : base()
        {
            SetFilter();
        }

        public SIS(SIS filter) : base(filter)
        {

            SetFilter();
        }

        #endregion

        #region properties
        


        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.GrayscaleBT709;
            Af.SISThreshold newFilter = new Af.SISThreshold();

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: SIS Threshold";
        }

        #endregion

    }
}