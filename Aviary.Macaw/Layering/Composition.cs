using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Di = SoundInTheory.DynamicImage;

namespace Aviary.Macaw.Layering
{
    public class Composition
    {

        #region members

        public List<Layer> Layers = new List<Layer>();


        #endregion

        #region constructors

        public Composition()
        {

        }

        public Composition(Composition composition)
        {
            this.Layers = composition.Layers;
        }

        #endregion

        #region properties
        


        #endregion

        #region methods

        public Bitmap GetBitmap()
        {
            Di.Composition composition = new Di.Composition();
            foreach(Layer layer in Layers)
            {
                Di.Layers.ImageLayer imgLayer = new Di.Layers.ImageLayer();
                imgLayer.BlendMode = (Di.BlendMode)layer.BlendMode;
                imgLayer.Source = layer.Image.ToImageImageSource();
                if(layer.IsMasked)
                {
                    Di.Filters.ClippingMaskFilter mask = new Di.Filters.ClippingMaskFilter();
                    mask.MaskImage = layer.Mask.ToImageImageSource();
                    mask.Enabled = true;
                    imgLayer.Filters.Add(mask);
                }
                if(layer.Opacity<100.0)
                {
                    Di.Filters.OpacityAdjustmentFilter opacity = new Di.Filters.OpacityAdjustmentFilter();
                    opacity.Opacity = (byte)layer.Opacity;
                    opacity.Enabled = true;
                    imgLayer.Filters.Add(opacity);
                }

                foreach(Modifier modifier in layer.Modifiers)
                {
                    imgLayer.Filters.Add(modifier.GetFilter());
                }

                composition.Layers.Add(imgLayer);
            }

            return composition.GenerateImage().Image.ToBitmap();
        }

        #endregion

    }
}
