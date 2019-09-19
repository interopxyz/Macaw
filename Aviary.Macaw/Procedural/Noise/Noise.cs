using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

using Aviary.Wind;


//Uses https://github.com/Auburns/FastNoise/wiki
namespace Aviary.Macaw.Procedural
{
    public class Noise
    {

        #region members

        public enum InterpolationModes { Linear, Hermite, Quintic, None };
        public InterpolationModes InterpolationMode = InterpolationModes.None;

        public enum FractalModes { FBM, Billow, Rigid, None };
        public FractalModes FractalMode = FractalModes.None;

        public int Seed = 1;

        public int Width = 100;
        public int Height = 100;
        public int Depth = 0;

        public double Frequency = 0.02;

        public int Octaves = 5;
        public double Lacunarity = 2.0;
        public double Gain = 0.5;

        public double PerturbanceAmplitude = 30;
        public double PerturbanceFrequency = 0.01;

        public List<double> Values = new List<double>();

        protected FastNoiseBase fastNoise = new FastNoiseBase(1);
        
        #endregion

        #region constructors

        public Noise()
        {

        }

        public Noise(int seed)
        {
            Seed = seed;
        }

        public Noise(int width, int height, int depth, int seed)
        {
            Width = width;
            Height = height;
            Depth = depth;

            Seed = seed;
        }

        #endregion

        #region properties
        
        #region public 

        public Bitmap GetCubic(bool applyFractals = false)
        {
            if (applyFractals)
            {
                return GetCubicFractal();
            }
            else
            {
                return GetCubicNormal();
            }
        }

        public Bitmap GetPerlin(bool applyFractals = false)
        {
            if (applyFractals)
            {
                return GetPerlinFractal();
            }
            else
            {
                return GetPerlinNormal();
            }
        }

        public Bitmap GetSimplex(bool applyFractals = false)
        {
            if (applyFractals)
            {
                return GetSimplexFractal();
            }
            else
            {
                return GetSimplexNormal();
            }
        }

        public Bitmap GetWhiteNoise()
        {
                return GetWhiteNoiseNormal();
        }

        public Bitmap GetValue(bool applyFractals = false)
        {
            if (applyFractals)
            {
                return GetValueFractal();
            }
            else
            {
                return GetValueNormal();
            }
        }

        #endregion

        #endregion

        #region methods

        #region normal

        private Bitmap GetCubicNormal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Cubic);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetCubic(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        private Bitmap GetPerlinNormal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Perlin);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetPerlin(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        private Bitmap GetSimplexNormal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Simplex);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetSimplex(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        private Bitmap GetWhiteNoiseNormal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.WhiteNoise);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetWhiteNoise(j, i, Depth, Frequency);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        private Bitmap GetValueNormal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Value);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Value);
                    double Value = fastNoise.GetNoise(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        #endregion

        #region fractal

        private Bitmap GetCubicFractal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.CubicFractal);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetCubicFractal(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        private Bitmap GetPerlinFractal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.PerlinFractal);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetPerlinFractal(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        private Bitmap GetSimplexFractal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.SimplexFractal);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetSimplexFractal(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        private Bitmap GetValueFractal()
        {
            Bitmap bitmap = GetBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.ValueFractal);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Value);
                    double Value = fastNoise.GetNoise(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bitmap.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bitmap;
        }

        #endregion

        public void SetSize(int width, int height, int depth = 0)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public void SetNoiseParameters(double frequency, InterpolationModes interpolation)
        {
            Frequency = frequency;
            InterpolationMode = interpolation;
            
        }

        public void SetFractal(FractalModes mode, int octaves, double lacunarity, double gain)
        {
            FractalMode = mode;

            Octaves = octaves;
            Lacunarity = lacunarity;
            Gain = gain;
        }

        public void SetPerturbance(double amplitude, double frequency)
        {
            PerturbanceAmplitude = amplitude;
            PerturbanceFrequency = frequency;
        }

        public void SetFractalPerturbance(double amplitude, double frequency)
        {
            PerturbanceAmplitude = amplitude;
            PerturbanceFrequency = frequency;
        }

        private Bitmap GetBitmap()
        {
            fastNoise = new FastNoiseBase(Seed);

            fastNoise.SetFrequency(Frequency);
            fastNoise.SetInterp((FastNoiseBase.Interp)(int)InterpolationMode);

            fastNoise.GradientPerturb(ref PerturbanceFrequency, ref PerturbanceFrequency, ref PerturbanceAmplitude);
            fastNoise.SetGradientPerturbAmp(PerturbanceAmplitude);

            fastNoise.SetFractalType((FastNoiseBase.FractalType)(int)FractalMode);
            fastNoise.SetFractalOctaves(Octaves);
            fastNoise.SetFractalLacunarity(Lacunarity);
            fastNoise.SetFractalGain(Gain);

            return new Bitmap(Width, Height);
        }

        #endregion

    }
}
