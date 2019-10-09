using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af=Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Smoothing
{
    public class Adaptive : Filter
    {

        #region members



        #endregion

        #region constructors

        public Adaptive() : base()
        {
            SetFilter();
        }
        

        public Adaptive(Adaptive filter) : base(filter)
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
            Af.AdaptiveSmoothing newFilter = new Af.AdaptiveSmoothing();
            imageFilter = newFilter;
        }

        #endregion

    }
}
