using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviary.Macaw
{
    public static class GetBitmap
    {
        #region members


        #endregion

        #region constructors

        public static Bitmap GetBitmapFromFile(string FilePath)
        {
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(FilePath);

            PropertyItem[] attribute = bitmap.PropertyItems;

            attribute[0].Id = 0;
            attribute[0].Value = Encoding.ASCII.GetBytes(FilePath);

            bitmap.SetPropertyItem(attribute[0]);

            return (Bitmap)bitmap.Clone();
        }
        #endregion
    }
}