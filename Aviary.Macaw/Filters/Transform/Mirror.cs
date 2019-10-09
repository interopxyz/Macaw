using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Transform
{
    public class Mirror : Filter
    {

        #region members
        
        protected bool aboutX = false;
        protected bool aboutY = false;

        #endregion

        #region constructors

        public Mirror() : base()
        {
            SetFilter();
        }

        public Mirror(bool aboutX, bool aboutY) : base()
        {
            this.aboutX = aboutX;
            this.aboutY = aboutY;

            SetFilter();
        }

        public Mirror(Mirror filter) : base(filter)
        {
            this.aboutX = filter.aboutX;
            this.aboutY = filter.aboutY;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual bool AboutX
        {
            get { return aboutX; }
            set
            {
                aboutX = value;
                SetFilter();
            }
        }

        public virtual bool AboutY
        {
            get { return aboutY; }
            set
            {
                aboutY = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;

            Af.Mirror newFilter = new Af.Mirror(aboutX,aboutY);
            imageFilter = newFilter;
        }

        #endregion

    }
}