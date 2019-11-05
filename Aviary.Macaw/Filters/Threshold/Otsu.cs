using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Threshold
{
    public class Otsu : Filter
    {

        #region members


        #endregion

        #region constructors

        public Otsu() : base()
        {
            SetFilter();
        }

        public Otsu(Otsu filter) : base(filter)
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
            Af.OtsuThreshold newFilter = new Af.OtsuThreshold();

            imageFilter = newFilter;
        }

        #endregion

    }
}