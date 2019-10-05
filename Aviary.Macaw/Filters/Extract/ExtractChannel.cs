using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class ExtractChannel : Filter
    {

        #region members

        public enum ChannelModes { Alpha=3, Red=2, Green=1, Blue = 0, Cb=5, Cr=6, Y=4};
        protected ChannelModes channelMode = ChannelModes.Alpha;
        

        #endregion

        #region constructors

        public ExtractChannel() : base()
        {
            SetFilter();
        }

        public ExtractChannel(ChannelModes channelMode) : base()
        {
            this.channelMode = channelMode;
            SetFilter();
        }

        public ExtractChannel(ExtractChannel filter) : base(filter)
        {
            this.channelMode = filter.channelMode;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual ChannelModes ChannelMode
        {
            get { return channelMode; }
            set
            {
                channelMode = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            if( (int)channelMode > 3)
            {
                Af.YCbCrExtractChannel newFilter = new Af.YCbCrExtractChannel();
                newFilter.Channel = (short)(channelMode-4);
                    imageFilter = newFilter;
            }
            else
            {
                Af.ExtractChannel newFilter = new Af.ExtractChannel();
                newFilter.Channel = (short)channelMode;
                imageFilter = newFilter;
            }
            
        }

        #endregion

    }
}
