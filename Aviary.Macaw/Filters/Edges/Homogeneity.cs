using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Edges
{
    public class Homogeneity : Filter
    {

        #region members
        


        #endregion

        #region constructors

        public Homogeneity() : base()
        {
            SetFilter();
        }
        
        public Homogeneity(Homogeneity filter) : base(filter)
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
            Af.HomogenityEdgeDetector newFilter = new Af.HomogenityEdgeDetector();
            imageFilter = newFilter;
        }

        #endregion

    }
}