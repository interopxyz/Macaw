using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class Additive : Filter
    {

        #region members
        

        #endregion

        #region constructors

        public Additive() : base()
        {
            SetFilter();
        }
        

        public Additive(Additive filter) : base(filter)
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
            Af.AdditiveNoise newFilter = new Af.AdditiveNoise();
            imageFilter = newFilter;
        }

        #endregion

    }
}