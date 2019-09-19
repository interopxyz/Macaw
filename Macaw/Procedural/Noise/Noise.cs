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
        public enum NoiseModes { Value, Perlin, Simplex, WhiteNoise, Cubic };
        protected NoiseModes noiseMode = NoiseModes.Value;

        public enum InterpolationModes { Linear, Hermite, Quintic, None };
        protected InterpolationModes interpolationMode = InterpolationModes.None;

        public enum FractalModes { FBM, Billow, Rigid, None };
        protected FractalModes fractalMode = FractalModes.None;

        protected int seed = 1;
        
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
            this.seed = seed;

            fastNoise = new FastNoiseBase(Seed);
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.SimplexFractal);
        }

        public Noise(int width, int height, int depth, int seed)
        {
            Width = width;
            Height = height;
            Depth = depth;

            this.seed = seed;

            fastNoise = new FastNoiseBase(Seed);
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.SimplexFractal);
            BuildBitmap();
        }

        #endregion

        #region properties

        public virtual int Seed
        {
            get { return seed; }
        }
        
        public void BuildBitmap()
        {
            Values.Clear();
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            bmp = new mConvert(new mConvert(bmp).BitmapToSource()).SourceToBitmap();

            if (FractalMode == FractalModes.None)
            {
                switch (NoiseMode)
                {
                    case NoiseModes.Cubic:
                        fastNoise.SetNoiseType(FastNoise.NoiseType.Cubic);
                        OutputBitmap = GetCubic(bmp);
                        break;
                    case NoiseModes.Perlin:
                        fastNoise.SetNoiseType(FastNoise.NoiseType.Perlin);
                        OutputBitmap = GetPerlin(bmp);
                        break;
                    case NoiseModes.Simplex:
                        fastNoise.SetNoiseType(FastNoise.NoiseType.Simplex);
                        OutputBitmap = GetSimplex(bmp);
                        break;
                    case NoiseModes.Value:

                        fastNoise.SetNoiseType(FastNoise.NoiseType.Value);
                        OutputBitmap = GetValue(bmp);
                        break;
                    case NoiseModes.WhiteNoise:

                        fastNoise.SetNoiseType(FastNoise.NoiseType.WhiteNoise);
                        OutputBitmap = GetWhiteNoise(bmp);
                        break;
                }
            }
            else
            {
                switch (NoiseMode)
                {
                    case NoiseModes.Cubic:

                        fastNoise.SetNoiseType(FastNoise.NoiseType.CubicFractal);
                        OutputBitmap = GetCubicFractal(bmp);
                        break;
                    case NoiseModes.Perlin:

                        fastNoise.SetNoiseType(FastNoise.NoiseType.PerlinFractal);
                        OutputBitmap = GetPerlinFractal(bmp);
                        break;
                    case NoiseModes.Simplex:

                        fastNoise.SetNoiseType(FastNoise.NoiseType.SimplexFractal);
                        OutputBitmap = GetSimplexFractal(bmp);
                        break;
                    case NoiseModes.Value:

                        fastNoise.SetNoiseType(FastNoise.NoiseType.ValueFractal);
                        OutputBitmap = GetValueFractal(bmp);
                        break;
                    case NoiseModes.WhiteNoise:

                        fastNoise.SetNoiseType(FastNoise.NoiseType.WhiteNoise);
                        OutputBitmap = GetWhiteNoise(bmp);
                        break;
                }
            }
        }
        
        private Bitmap GetCubic(bool applyFractals = false)
        {
            Bitmap bitmap = GetBitmap();
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

        private Bitmap GetPerlin(bool applyFractals = false)
        {
            Bitmap bitmap = GetBitmap();
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

        private Bitmap GetSimplex(bool applyFractals = false)
        {
            Bitmap bitmap = GetBitmap();
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

        private Bitmap GetWhiteNoise(bool applyFractals = false)
        {
            Bitmap bitmap = GetBitmap();
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

        private Bitmap GetValue(bool applyFractals = false)
        {
            Bitmap bitmap = GetBitmap();
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
        
        private Bitmap GetCubicFractal(bool applyFractals = false)
        {
            Bitmap bitmap = GetBitmap();
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

        private Bitmap GetPerlinFractal(bool applyFractals = false)
        {
            Bitmap bitmap = GetBitmap();
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

        private Bitmap GetValueFractal(Bitmap bmp, bool applyFractals = false)
        {
            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Value);
                    double Value = fastNoise.GetNoise(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);

                    bmp.SetPixel(j, i, Color.FromArgb(IntValue, IntValue, IntValue));
                    k += 1;
                }
            }

            return bmp;
        }

        #endregion

        public void SetSize(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public void SetNoiseParameters(NoiseModes mode, double frequency, InterpolationModes interpolation)
        {
            NoiseMode = mode;
            Frequency = frequency;
            InterpolationMode = interpolation;

            fastNoise.SetFrequency(Frequency);
            fastNoise.SetInterp((FastNoise.Interp)(int)InterpolationMode);

        }

        public void SetFractal(FractalModes mode, int octaves, double lacunarity, double gain)
        {
            FractalMode = mode;

            Octaves = octaves;
            Lacunarity = lacunarity;
            Gain = gain;

            fastNoise.SetFractalType((FastNoise.FractalType)(int)FractalMode);

            fastNoise.SetFractalOctaves(Octaves);
            fastNoise.SetFractalLacunarity(Lacunarity);
            fastNoise.SetFractalGain(Gain);
        }

        public void SetPerturbance(double amplitude, double frequency)
        {
            PerturbanceAmplitude = amplitude;
            PerturbanceFrequency = frequency;

            fastNoise.GradientPerturb(ref frequency, ref frequency, ref amplitude);
            fastNoise.SetGradientPerturbAmp(PerturbanceAmplitude);
        }

        public void SetFractalPerturbance(double amplitude, double frequency)
        {
            PerturbanceAmplitude = amplitude;
            PerturbanceFrequency = frequency;

            //Noise.SetGradientPerturbAmp(PerturbanceFrequency);
        }

        private Bitmap GetBitmap()
        {
            return new Bitmap(Width, Height);
        }

    }
}
