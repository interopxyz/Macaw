using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Edges
{
    public class Kirsch : Filter
    {

        #region members



        #endregion

        #region constructors

        public Kirsch() : base()
        {
            SetFilter();
        }

        public Kirsch(Kirsch filter) : base(filter)
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
            Af.KirschEdgeDetector newFilter = new Af.KirschEdgeDetector();

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Edges Kirsch";
        }

        #endregion

    }
}