using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoundInTheory.DynamicImage.Filters;
using SoundInTheory.DynamicImage;
using Sf = SoundInTheory.DynamicImage.Filters;

using Wg = Aviary.Wind.Graphics;

using Aviary.Wind;

namespace Aviary.Macaw.Layering
{
    public class Modifier
    {

        #region members

        public enum ModifierModes { Invert = 0, Solarize= 1, Grayscale= 2, Sepia= 3, Vignette= 4, Emboss= 5, Brightness= 6, Contrast= 7, Gaussian= 8, Border= 9, ColorTint= 10, ColorKey = 11 }
        public ModifierModes ModifierMode = ModifierModes.Invert;

        public double Value = 0;
        public Wg.Color Color = Wg.Colors.Transparent;

        #endregion

        #region constructors

        public Modifier()
        {

        }

        public Modifier(ModifierModes modifierMode)
        {
            this.ModifierMode = modifierMode;
        }

        public Modifier(Modifier modifier)
        {
            this.ModifierMode = modifier.ModifierMode;
            this.Value = modifier.Value;
            this.Color = new Wg.Color(modifier.Color);
        }

        #endregion

        #region properties

        public Sf.Filter GetFilter()
        {
            switch(this.ModifierMode)
            {
                default:
                    return GetInversionFilter();
                case ModifierModes.Border:
                    return GetBorderFilter();
                case ModifierModes.Brightness:
                    return GetBrightnessFilter();
                case ModifierModes.Contrast:
                    return GetContrastFilter();
                case ModifierModes.Emboss:
                    return GetEmbossFilter();
                case ModifierModes.Gaussian:
                    return GetGaussianFilter();
                case ModifierModes.Grayscale:
                    return GetGrayscaleFilter();
                case ModifierModes.Sepia:
                    return GetSepiaFilter();
                case ModifierModes.Solarize:
                    return GetSolarizeFilter();
                case ModifierModes.ColorTint:
                    return GetColorTintFilter();
                case ModifierModes.ColorKey:
                    return GetColorKeyFilter();
                case ModifierModes.Vignette:
                    return GetVignetteFilter();
            }
        }

        #endregion

        #region methods

        private Sf.Filter GetBorderFilter()
        {
            BorderFilter filter = new BorderFilter();

            filter.Fill = Color.ToFill();
            filter.Width = (int)Value;

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetBrightnessFilter()
        {
            BrightnessAdjustmentFilter filter = new BrightnessAdjustmentFilter();
            filter.Level = (int)Value;

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetVignetteFilter()
        {
            VignetteFilter filter = new VignetteFilter();

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetSolarizeFilter()
        {
            SolarizeFilter filter = new SolarizeFilter();

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetSepiaFilter()
        {
            SepiaFilter filter = new SepiaFilter();

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetInversionFilter()
        {
            InversionFilter filter = new InversionFilter();

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetGrayscaleFilter()
        {
            GrayscaleFilter filter = new GrayscaleFilter();

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetGaussianFilter()
        {
            GaussianBlurFilter filter = new GaussianBlurFilter();
            filter.Radius = (float)(Value%20);

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetEmbossFilter()
        {
            EmbossFilter filter = new EmbossFilter();
            filter.Amount = (float)Value;

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetContrastFilter()
        {
            ContrastAdjustmentFilter filter = new ContrastAdjustmentFilter();
            filter.Level = (int)Value;

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetColorTintFilter()
        {
            ColorTintFilter filter = new ColorTintFilter();
            filter.Amount = (int)Value;
            filter.Color = Color.ToDynamicColor();

            filter.Enabled = true;
            return filter;
        }

        private Sf.Filter GetColorKeyFilter()
        {
            ColorKeyFilter filter = new ColorKeyFilter();
            filter.ColorTolerance = (byte)Value;
            filter.Color = Color.ToDynamicColor();

            filter.Enabled = true;
            return filter;
        }

        #endregion

    }
}
