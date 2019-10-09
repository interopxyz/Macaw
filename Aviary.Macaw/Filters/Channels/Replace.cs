using Accord.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Channels
{
    public class Replace : Filter
    {

        #region members
        public enum Modes { Alpha = 3, Red = 2, Green = 1, Blue = 0, Cb = 5, Cr = 6, Y = 4 };

        public Modes mode = Modes.Alpha;
        protected Bitmap channelImage = new Bitmap(100,100);

        #endregion

        #region constructors

        public Replace() : base()
        {
            SetFilter();
        }

        public Replace(Modes mode, Bitmap channelImage) : base()
        {
            this.mode = mode;
            this.channelImage = channelImage;

            SetFilter();
        }

        public Replace(Replace filter) : base(filter)
        {
            this.mode = filter.mode;
            this.channelImage = filter.channelImage;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Modes Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                SetFilter();
            }
        }

        public virtual Bitmap ChannelImage
        {
            get { return channelImage; }
            set
            {
                channelImage = value;
                SetFilter();
            }
        }


        #endregion

        #region methods

        private void SetFilter()
        {
            if ((int)mode > 3)
            {
                ImageType = ImageTypes.Rgb24bpp;
                Af.YCbCrReplaceChannel newFilter = new Af.YCbCrReplaceChannel((short)(mode-4),channelImage);
                imageFilter = newFilter;
            }
            else
            {
                ImageType = ImageTypes.Rgb24bpp;
                Af.ReplaceChannel newFilter = new Af.ReplaceChannel((short)mode, channelImage);
                imageFilter = newFilter;
            }
        }

        #endregion

    }
}