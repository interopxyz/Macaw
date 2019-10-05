using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class Daube : Filter
    {

        #region members

        protected int size = 4;

        #endregion

        #region constructors

        public Daube() : base()
        {
            SetFilter();
        }

        public Daube(int size) : base()
        {
            this.size = size;
            SetFilter();
        }

        public Daube(Daube filter) : base(filter)
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
            OilPainting newFilter = new OilPainting();
            newFilter.BrushSize = size;
            imageFilter = newFilter;
        }

        #endregion

    }
}