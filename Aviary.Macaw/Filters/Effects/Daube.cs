using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class Daube : Filter
    {

        #region members

        protected double size = 1.0;

        #endregion

        #region constructors

        public Daube() : base()
        {
            SetFilter();
        }

        public Daube(double size) : base()
        {
            this.size = size;
            SetFilter();
        }

        public Daube(Daube filter) : base(filter)
        {
            this.size = filter.size;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Size
        {
            get { return size; }
            set
            {
                size = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.OilPainting newFilter = new Af.OilPainting();
            newFilter.BrushSize = (int)Remap(size,1,21);
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Daube";
        }

        #endregion

    }
}