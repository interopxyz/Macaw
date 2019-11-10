using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Edges
{
    public class Sobel : Filter
    {

        #region members

        protected bool intensity = false;

        #endregion

        #region constructors

        public Sobel() : base()
        {
            SetFilter();
        }

        public Sobel(bool intensity) : base()
        {
            this.intensity = intensity;
            SetFilter();
        }

        public Sobel(Sobel filter) : base(filter)
        {
            this.intensity = filter.intensity;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual bool Intensity
        {
            get { return intensity; }
            set
            {
                intensity = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.GrayscaleBT709;
            Af.SobelEdgeDetector newFilter = new Af.SobelEdgeDetector();
            newFilter.ScaleIntensity = intensity;
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Edges Sobel";
        }

        #endregion

    }
}