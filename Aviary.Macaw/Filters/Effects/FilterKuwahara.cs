using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterKuwahara : Filter
    {

        #region members

        protected int size = 0;

        #endregion

        #region constructors

        public FilterKuwahara() : base()
        {
            SetFilter();
        }

        public FilterKuwahara(int size) : base()
        {
            this.size = size;
            SetFilter();
        }

        public FilterKuwahara(FilterKuwahara filter) : base(filter)
        {
            this.size = filter.size;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Size
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
            ImageType = ImageTypes.Rgb32bpp;
            Kuwahara newFilter = new Kuwahara();
            newFilter.Size = size;
            imageFilter = newFilter;
        }

        #endregion

    }
}