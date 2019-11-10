using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af=Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Smoothing
{
    public class Conservative : Filter
    {

        #region members



        #endregion

        #region constructors

        public Conservative() : base()
        {
            SetFilter();
        }

        public Conservative(Conservative filter) : base(filter)
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
            Af.ConservativeSmoothing newFilter = new Af.ConservativeSmoothing();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Conservative Smoothing";
        }

        #endregion

    }
}
