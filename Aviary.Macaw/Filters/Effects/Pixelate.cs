using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class Pixelate : Filter
    {

        #region members

        protected int width = 1;
        protected int height = 1;

        #endregion

        #region constructors

        public Pixelate() : base()
        {
            SetFilter();
        }

        public Pixelate(int width, int height) : base()
        {
            this.width = width;
            this.height = height;
            SetFilter();
        }

        public Pixelate(Pixelate filter) : base(filter)
        {
            this.width = filter.width;
            this.height = filter.height;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Width
        {
            get { return width; }
            set
            {
                width = value;
                SetFilter();
            }
        }

        public virtual int Height
        {
            get { return height; }
            set
            {
                height = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Pixellate newFilter = new Pixellate();
            newFilter.PixelWidth = width;
            newFilter.PixelHeight = height;
            imageFilter = newFilter;
        }

        #endregion

    }
}