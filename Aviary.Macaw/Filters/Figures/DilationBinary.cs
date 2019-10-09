using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class DilationBinary : Filter
    {

        #region members



        #endregion

        #region constructors

        public DilationBinary() : base()
        {
            SetFilter();
        }

        public DilationBinary(DilationBinary filter) : base(filter)
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
            Af.BinaryDilation3x3 newFilter = new Af.BinaryDilation3x3();
            imageFilter = newFilter;
        }

        #endregion

    }
}