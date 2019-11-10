using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class ErosionWatershed : Filter
    {

        #region members

        public enum DistanceModes { Chessboard, Euclidean, Manhattan, SquaredEuclidean }

        protected DistanceModes distanceMode = DistanceModes.Euclidean;
        protected double tolerance = 1.0;

        #endregion

        #region constructors

        public ErosionWatershed() : base()
        {
            SetFilter();
        }

        public ErosionWatershed(DistanceModes distanceMode, double tolerance) : base()
        {
            this.distanceMode = distanceMode;
            this.tolerance = tolerance;

            SetFilter();
        }

        public ErosionWatershed(ErosionWatershed filter) : base(filter)
        {
            this.distanceMode = filter.distanceMode;
            this.tolerance = filter.tolerance;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual DistanceModes DistanceMode
        {
            get { return distanceMode; }
            set
            {
                distanceMode = value;
                SetFilter();
            }
        }

        public virtual double Tolerance
        {
            get { return tolerance; }
            set
            {
                tolerance = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.BinaryWatershed newFilter = new Af.BinaryWatershed();
            newFilter.Distance = (Af.DistanceTransformMethod)distanceMode;
            newFilter.Tolerance = (float)tolerance;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Watershed Erosion";
        }

        #endregion

    }
}