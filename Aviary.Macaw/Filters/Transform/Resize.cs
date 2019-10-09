using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Transform
{
    public class Resize : Filter
    {

        #region members

        public enum Modes { Bicubic, Bilinear, Nearest }

        protected Modes mode = Modes.Bilinear;
        protected int width = 100;
        protected int height = 100;

        #endregion

        #region constructors

        public Resize() : base()
        {
            SetFilter();
        }

        public Resize(int width, int height, Modes mode) : base()
        {
            this.width = width;
            this.height = height;
            this.mode = mode;

            SetFilter();
        }

        public Resize(Resize filter) : base(filter)
        {
            this.width = filter.width;
            this.height = filter.height;
            this.mode = filter.mode;

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

        public virtual Modes Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;

            switch (mode)
            {
                case Modes.Bicubic:
                    Af.ResizeBicubic newFilterA = new Af.ResizeBicubic(width,height);
                    imageFilter = newFilterA;
                    break;
                case Modes.Bilinear:
                    Af.ResizeBilinear newFilterB = new Af.ResizeBilinear(width, height);
                    imageFilter = newFilterB;
                    break;
                case Modes.Nearest:
                    Af.ResizeNearestNeighbor newFilterC = new Af.ResizeNearestNeighbor(width, height);
                    imageFilter = newFilterC;
                    break;
            }
        }

        #endregion

    }
}