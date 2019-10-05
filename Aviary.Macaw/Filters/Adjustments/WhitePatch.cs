using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class WhitePatch : Filter
    {

        #region members



        #endregion

        #region constructors

        public WhitePatch() : base()
        {
            SetFilter();
        }

        public WhitePatch(WhitePatch filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties
        


        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.None;
            Accord.Imaging.Filters.WhitePatch newFilter = new Accord.Imaging.Filters.WhitePatch();
            imageFilter = newFilter;
        }

        #endregion

    }
}
