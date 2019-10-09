using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Transform
{
    public class Move : Filter
    {

        #region members
        
        protected Color color = Color.Transparent;
        protected Point translation = new Point(100, 100);

        #endregion

        #region constructors

        public Move() : base()
        {
            SetFilter();
        }

        public Move(Color color, Point translation) : base()
        {
            this.color = color;
            this.translation = translation;

            SetFilter();
        }

        public Move(Move filter) : base(filter)
        {
            this.color = filter.color;
            this.translation = filter.translation;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Color BackgroundColor
        {
            get { return color; }
            set
            {
                color = value;
                SetFilter();
            }
        }

        public virtual Point Translation
        {
            get { return translation; }
            set
            {
                translation = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb48bpp;
            
                Af.CanvasMove newFilter = new Af.CanvasMove(new Accord.IntPoint(translation.X,translation.Y));
                newFilter.FillColorRGB = color;
                imageFilter = newFilter;
        }

        #endregion

    }
}