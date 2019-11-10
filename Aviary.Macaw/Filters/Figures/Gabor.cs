using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class Gabor : Filter
    {

        #region members

        protected double angle = 0;
        protected int size = 3;
        protected double gamma = 1.0;
        protected double lambda = 1.0;
        protected double psi = 1.0;
        protected double sigma = 1.0;

        #endregion

        #region constructors

        public Gabor() : base()
        {
            SetFilter();
        }

        public Gabor(double angle, int size, double gamma, double lambda, double psi, double sigma) : base()
        {
            this.angle = angle;
            this.size = size;
            this.gamma = gamma;
            this.lambda = lambda;
            this.psi = psi;
            this.sigma = sigma;

            SetFilter();
        }

        public Gabor(Gabor filter) : base(filter)
        {
            this.angle = filter.angle;
            this.size = filter.size;
            this.gamma = filter.gamma;
            this.lambda = filter.lambda;
            this.psi = filter.psi;
            this.sigma = filter.sigma;

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

        public virtual int Size
        {
            get { return size; }
            set
            {
                size = value;
                SetFilter();
            }
        }

        public virtual double Gamma
        {
            get { return gamma; }
            set
            {
                gamma = value;
                SetFilter();
            }
        }

        public virtual double Lambda
        {
            get { return lambda; }
            set
            {
                lambda = value;
                SetFilter();
            }
        }

        public virtual double PSI
        {
            get { return psi; }
            set
            {
                psi = value;
                SetFilter();
            }
        }

        public virtual double Sigma
        {
            get { return sigma; }
            set
            {
                sigma = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.GaborFilter newFilter = new Af.GaborFilter();
            newFilter.Theta = angle;
            newFilter.Size = size;
            newFilter.Gamma = gamma;
            newFilter.Lambda = lambda;
            newFilter.Psi = psi;
            newFilter.Sigma = sigma;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Gabor";
        }

        #endregion

    }
}