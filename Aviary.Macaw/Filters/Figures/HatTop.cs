using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class HatTop : Filter
    {

        #region members


        #endregion

        #region constructors

        public HatTop() : base()
        {
            SetFilter();
        }


        public HatTop(HatTop filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties



        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.TopHat newFilter = new Af.TopHat();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Hat Top";
        }

        #endregion

    }
}