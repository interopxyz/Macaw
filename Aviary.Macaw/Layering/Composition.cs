using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Aviary.Macaw.Layering.Layer;
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

                int w = layer.Image.Width;
                if (layer.Width > 0) w = layer.Width;
                int h = layer.Image.Height;
                if (layer.Height > 0) h = layer.Height;
                imgLayer.Filters.Add(GetScaleFilter(w,h,layer.FittingMode));
                
                imgLayer.Filters.Add(GetRotationFilter(layer.Angle));

                imgLayer.X = layer.X;
                imgLayer.Y = layer.Y;

                composition.Layers.Add(imgLayer);
            }

            return composition.GenerateImage().Image.ToBitmap();
        }

        private Di.Filters.Filter GetRotationFilter(int angle)
        {
            Di.Filters.RotationFilter rotation = new Di.Filters.RotationFilter
            {
                Angle = angle
            };
            return rotation;
        }

        private Di.Filters.Filter GetScaleFilter(int width,int height, FittingModes mode) {
            Di.Filters.ResizeFilter resize = new Di.Filters.ResizeFilter
            {
                Mode = (Di.Filters.ResizeMode)mode,

                Width = Di.Unit.Pixel(width),
                Height = Di.Unit.Pixel(height)
            };

            return resize;
        }

        private Di.Filters.Filter GetTranslationFilter(Layer layer)
        {
            Di.Filters.ResizeFilter resize = new Di.Filters.ResizeFilter();

            return resize;
        }

        #endregion

    }
}
