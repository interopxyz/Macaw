using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Transform
{
    public class Polar : Filter
    {

        #region members

        protected bool toPolar = false;
        protected double depth = 1.0;
        protected double angle = 0.0;
        protected bool direction = false;
        protected bool vertical = false;

        #endregion

        #region constructors

        public Polar() : base()
        {
            SetFilter();
        }

        public Polar(bool toPolar, double depth, double angle, bool direction, bool vertical) : base()
        {
            this.toPolar = toPolar;
            this.depth = depth;
            this.angle = angle;
            this.direction = direction;
            this.vertical = vertical;

            SetFilter();
        }

        public Polar(Polar filter) : base(filter)
        {
            this.toPolar = filter.toPolar;
            this.depth = filter.depth;
            this.angle = filter.angle;
            this.direction = filter.direction;
            this.vertical = filter.vertical;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual bool ToPolar
        {
            get { return toPolar; }
            set
            {
                toPolar = value;
                SetFilter();
            }
        }

        public virtual bool Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                SetFilter();
            }
        }

        public virtual bool Vertical
        {
            get { return vertical; }
            set
            {
                vertical = value;
                SetFilter();
            }
        }

        public virtual double Depth
        {
            get { return depth; }
            set
            {
                depth = value;
                SetFilter();
            }
        }

        public virtual double Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;

            if(toPolar)
            {
                Af.TransformToPolar newFilter = new Af.TransformToPolar();
                newFilter.CirlceDepth = depth;
                newFilter.OffsetAngle = angle;
                newFilter.MapFromTop = vertical;
                newFilter.MapBackwards = direction;
                imageFilter = newFilter;
            }
            else
            {
                Af.TransformFromPolar newFilter = new Af.TransformFromPolar();
                newFilter.CirlceDepth = depth;
                newFilter.OffsetAngle = angle;
                newFilter.MapFromTop = vertical;
                newFilter.MapBackwards = direction;
                imageFilter = newFilter;
            }
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Xform Polar";
        }

        #endregion

    }
}