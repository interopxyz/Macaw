using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Channels
{
    public class Extract : Filter
    {

        #region members

        public enum Modes { Alpha=3, Red=2, Green=1, Blue = 0, Cb=5, Cr=6, Y=4};
        protected Modes mode = Modes.Alpha;
        

        #endregion

        #region constructors

        public Extract() : base()
        {
            SetFilter();
        }

        public Extract(Modes mode) : base()
        {
            this.mode = mode;
            SetFilter();
        }

        public Extract(Extract filter) : base(filter)
        {
            this.mode = filter.mode;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual Modes ChannelMode
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
            ImageType = ImageTypes.Rgb32bpp;
            if( (int)mode > 3)
            {
                Af.YCbCrExtractChannel newFilter = new Af.YCbCrExtractChannel();
                newFilter.Channel = (short)(mode-4);
                    imageFilter = newFilter;
            }
            else
            {
                Af.ExtractChannel newFilter = new Af.ExtractChannel();
                newFilter.Channel = (short)mode;
                imageFilter = newFilter;
            }
            
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Extract Channel";
        }

        #endregion

    }
}
