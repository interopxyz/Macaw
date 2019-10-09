using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class Closing : Filter
    {

        #region members


        #endregion

        #region constructors

        public Closing() : base()
        {
            SetFilter();
        }


        public Closing(Closing filter) : base(filter)
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
            Af.Closing newFilter = new Af.Closing();
            imageFilter = newFilter;
        }

        #endregion

    }
}