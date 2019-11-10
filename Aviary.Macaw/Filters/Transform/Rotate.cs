using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Transform
{
    public class Rotate : Filter
    {

        #region members

        public enum Modes { Bicubic, Bilinear, Nearest }

        protected Modes mode = Modes.Bilinear;
        protected double angle = 0;
        protected bool keepSize = true;
        protected Color color = Color.Transparent;

        #endregion

        #region constructors

        public Rotate() : base()
        {
            SetFilter();
        }

        public Rotate(double angle, bool keepSize, Color color, Modes mode) : base()
        {
            this.angle = angle;
            this.keepSize = keepSize;
            this.color = color;
            this.mode = mode;

            SetFilter();
        }

        public Rotate(Rotate filter) : base(filter)
        {
            this.angle = filter.angle;
            this.keepSize = filter.keepSize;
            this.color = filter.color;
            this.mode = filter.mode;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                SetFilter();
            }
        }

        public virtual Color BackgroundColor
        {
            get { return color; }
            set
            {
                color = value;
                SetFilter();
            }
        }

        public virtual bool KeepSize
        {
            get { return keepSize; }
            set
            {
                keepSize = value;
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
                    Af.RotateBicubic newFilterA = new Af.RotateBicubic(angle);
                    newFilterA.FillColor = color;
                    newFilterA.KeepSize = keepSize;
                    imageFilter = newFilterA;
                    break;
                case Modes.Bilinear:
                    Af.RotateBilinear newFilterB = new Af.RotateBilinear(angle);
                    newFilterB.FillColor = color;
                    newFilterB.KeepSize = keepSize;
                    imageFilter = newFilterB;
                    break;
                case Modes.Nearest:
                    Af.RotateNearestNeighbor newFilterC = new Af.RotateNearestNeighbor(angle);
                    newFilterC.FillColor = color;
                    newFilterC.KeepSize = keepSize;
                    imageFilter = newFilterC;
                    break;
            }
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Xform Rotate";
        }

        #endregion

    }
}