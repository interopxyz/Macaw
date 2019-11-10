using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class Skeletonization : Filter
    {

        #region members


        #endregion

        #region constructors

        public Skeletonization() : base()
        {
            SetFilter();
        }


        public Skeletonization(Skeletonization filter) : base(filter)
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
            Af.SimpleSkeletonization newFilter = new Af.SimpleSkeletonization();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Skeletonization";
        }

        #endregion

    }
}