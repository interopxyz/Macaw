using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class FillHoles : Filter
    {

        #region members

        protected bool filtered = false;
        protected int height = 10;
        protected int width = 10;

        #endregion

        #region constructors

        public FillHoles() : base()
        {
            SetFilter();
        }

        public FillHoles(int height, int width, bool filtered) : base()
        {
            this.height = height;
            this.width = width;
            this.filtered = filtered;

            SetFilter();
        }
        
        public FillHoles(FillHoles filter) : base(filter)
        {
            this.height = filter.height;
            this.width = filter.width;
            this.filtered = filter.filtered;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Height
        {
            get { return height; }
            set
            {
                height = value;
                SetFilter();
            }
        }

        public virtual int Width
        {
            get { return width; }
            set
            {
                width = value;
                SetFilter();
            }
        }

        public virtual bool Filtered
        {
            get { return filtered; }
            set
            {
                filtered = value;
                SetFilter();
            }
        }



        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.FillHoles newFilter = new Af.FillHoles();
            newFilter.MaxHoleWidth = width;
            newFilter.MaxHoleHeight = height;
            newFilter.CoupledSizeFiltering = filtered;

            imageFilter = newFilter;
        }

        #endregion

    }
}