using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Transform
{
    public class Shrink : Filter
    {

        #region members

        protected Color color = Color.Transparent;

        #endregion

        #region constructors

        public Shrink() : base()
        {
            SetFilter();
        }

        public Shrink(Color color) : base()
        {
            this.color = color;

            SetFilter();
        }

        public Shrink(Shrink filter) : base(filter)
        {
            this.color = filter.color;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Color BackgroundColor
        {
            get { return color; }
            set
            {
                color = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;

            Af.Shrink newFilter = new Af.Shrink();
            newFilter.ColorToRemove = color;
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Xform Shrink";
        }

        #endregion

    }
}