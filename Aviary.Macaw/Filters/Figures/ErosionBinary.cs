using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class ErosionBinary: Filter
    {

        #region members



        #endregion

        #region constructors

        public ErosionBinary() : base()
        {
            SetFilter();
        }

        public ErosionBinary(ErosionBinary filter) : base(filter)
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
            Af.BinaryErosion3x3 newFilter = new Af.BinaryErosion3x3();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Binary Erosion";
        }

        #endregion

    }
}