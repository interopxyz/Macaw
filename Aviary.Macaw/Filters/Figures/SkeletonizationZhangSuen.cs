using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class SkeletonizationZhangSuen : Filter
    {

        #region members


        #endregion

        #region constructors

        public SkeletonizationZhangSuen() : base()
        {
            SetFilter();
        }


        public SkeletonizationZhangSuen(SkeletonizationZhangSuen filter) : base(filter)
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
            Af.ZhangSuenSkeletonization newFilter = new Af.ZhangSuenSkeletonization();
            
            imageFilter = newFilter;
        }

        #endregion

    }
}