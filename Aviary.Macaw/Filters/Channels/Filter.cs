using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw
{
    public class Filter
    {

        #region members

        protected Af.IFilter imageFilter = new Af.Invert();

        #endregion

        #region constructors

        public Filter()
        {

        }

        public Filter(Filter filter)
        {
            this.imageFilter = filter.imageFilter;
        }
        
        #endregion

        #region properties
        
        public virtual Af.IFilter FilterObject
        {
            get { return imageFilter; }
        }

        #endregion

        #region methods



        #endregion

    }
}
