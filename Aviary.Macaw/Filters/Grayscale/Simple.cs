using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Grayscale
{
    public class Simple : Filter
    {

        #region members

        protected double red = 0;
        protected double green = 0;
        protected double blue = 0;

        #endregion

        #region constructors

        public Simple() : base()
        {
            SetFilter();
        }

        public Simple(double red, double green, double blue) : base()
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            SetFilter();
        }

        public Simple(Simple filter) : base(filter)
        {
            this.red = filter.red;
            this.green = filter.green;
            this.blue = filter.blue;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Red
        {
            get { return red; }
            set
            {
                red = value;
                SetFilter();
            }
        }

        public virtual double Green
        {
            get { return green; }
            set
            {
                green = value;
                SetFilter();
            }
        }

        public virtual double Blue
        {
            get { return blue; }
            set
            {
                blue = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.Grayscale newFilter = new Af.Grayscale(red, green, blue);
            imageFilter = newFilter;
        }

        #endregion

    }
}