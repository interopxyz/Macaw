using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviary.Macaw
{
    public class Image
    {

        #region members

        protected Bitmap bitmap = new Bitmap(100, 100);

        #endregion

        #region constructors

        public Image()
        {

        }

        public Image(Image image)
        {
            this.Bitmap = image.bitmap;
        }

        public Image(Bitmap bitmap)
        {
            this.Bitmap = bitmap;
        }

        #endregion

        #region properties

        public virtual Bitmap Bitmap
        {
            get { return (Bitmap)bitmap.Clone(); }
            set { bitmap = (Bitmap)value.Clone(); }
        }

        #endregion

        #region members



        #endregion

        #region overrides

        public override string ToString()
        {
            return "Image ("+bitmap.Width+"x"+bitmap.Height+")";
        }

        #endregion

    }
}
