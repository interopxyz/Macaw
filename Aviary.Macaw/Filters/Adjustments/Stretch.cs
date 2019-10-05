﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class Stretch : Filter
    {

        #region members



        #endregion

        #region constructors

        public Stretch() : base()
        {
            SetFilter();
        }

        public Stretch(Stretch filter) : base(filter)
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
            ContrastStretch newFilter = new ContrastStretch();
            imageFilter = newFilter;
        }

        #endregion

    }
}