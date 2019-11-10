using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class Kuwahara : Filter
    {

        #region members

        protected double size = 0;

        #endregion

        #region constructors

        public Kuwahara() : base()
        {
            SetFilter();
        }

        public Kuwahara(double size) : base()
        {
            this.size = size;
            SetFilter();
        }

        public Kuwahara(Kuwahara filter) : base(filter)
        {
            this.size = filter.size;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Size
        {
            get { return size; }
            set
            {
                size = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.GrayscaleBT709;
            Af.Kuwahara newFilter = new Af.Kuwahara();
            newFilter.Size = makeOdd();
            imageFilter = newFilter;
        }

        public int makeOdd()
        {
            int val = (int)(5 + ((size%1.0) * 95));
            return val + ((val + 1) % 2); ;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Kuwahara";
        }

        #endregion

    }
}