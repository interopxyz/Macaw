using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class Jitter : Filter
    {

        #region members

        protected int radius = 0;

        #endregion

        #region constructors

        public Jitter() : base()
        {
            SetFilter();
        }

        public Jitter(int radius) : base()
        {
            this.radius = radius;
            SetFilter();
        }

        public Jitter(Jitter filter) : base(filter)
        {
            this.radius = filter.radius;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.Jitter newFilter = new Af.Jitter();
            newFilter.Radius = radius;
            imageFilter = newFilter;
        }

        #endregion

    }
}