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

        public enum OutputModes { None, Value, Perlin, Simplex, Cubic, White, Cellular };
        protected OutputModes OutputStatus = OutputModes.None;

        public enum InterpolationModes { Linear, Hermite, Quintic };
        public InterpolationModes InterpolationMode = InterpolationModes.Linear;

        public enum FractalModes { FBM, Billow, Rigid, None };
        public FractalModes FractalMode = FractalModes.None;

        public enum CellularModes { Euclidean, Manhattan, Natural };
        public CellularModes CellularMode = CellularModes.Euclidean;

        public enum CellularOutputs { Value, Lookup, Distance, Distance2, Distance2Add, Distance2Sub, Distance2Mul, Distance2Div }
        public CellularOutputs CellularOutput = CellularOutputs.Value;

        public int Seed = 1;

        public int Width = 100;
        public int Height = 100;
        public int Depth = 0;

        public double Frequency = 0.025;

        public int Octaves = 5;
        public double Lacunarity = 2.0;
        public double Gain = 0.5;

        public double PerturbanceAmplitude = 30;
        public double PerturbanceFrequency = 0.01;

        public double Jitter = 1.0;

        protected List<double> Values = new List<double>();

        protected FastNoiseBase fastNoise = new FastNoiseBase(1);

        #endregion

        #region constructors

        public Noise()
        {

        }

        public Noise(Noise noise)
        {
            Seed = noise.Seed;

            Width = noise.Width;
            Height = noise.Height;
            Depth = noise.Depth;

            Frequency = noise.Frequency;

            Octaves = noise.Octaves;
            Lacunarity = noise.Lacunarity;
            Gain = noise.Gain;

            PerturbanceAmplitude = noise.PerturbanceAmplitude;
            PerturbanceFrequency = noise.PerturbanceFrequency;

            OutputStatus = noise.OutputStatus;
            InterpolationMode = noise.InterpolationMode;
            FractalMode = noise.FractalMode;

            Jitter = noise.Jitter;
        }

        public Noise(int seed)
        {
            Seed = seed;
        }

        public Noise(int seed, int width, int height, int depth)
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
            OutputStatus = OutputModes.Cubic;
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
            OutputStatus = OutputModes.Perlin;

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
            OutputStatus = OutputModes.Simplex;

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
            OutputStatus = OutputModes.White;

            return GetWhiteNoiseNormal();
        }

        public Bitmap GetValue(bool applyFractals = false)
        {
            OutputStatus = OutputModes.Value;

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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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
            Bitmap bitmap = GetNoiseBitmap();
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

        #region cellular


        public Bitmap GetCellular()
        {
            OutputStatus = OutputModes.Cellular;

            Bitmap bitmap = GetCellularBitmap();
            fastNoise.SetNoiseType(FastNoiseBase.NoiseType.Cellular);

            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Value = fastNoise.GetNoise(j, i, Depth);
                    Values.Add(Value);
                    int IntValue = (int)(255.0 * (1.0 + Value) / 2);
                    if (IntValue > 255) IntValue = 255;
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

        private Bitmap GetNoiseBitmap()
        {
            fastNoise = new FastNoiseBase(Seed);

            fastNoise.SetFrequency(Frequency);
            fastNoise.SetInterp((FastNoiseBase.Interp)(int)InterpolationMode);

            //fastNoise.GradientPerturb(ref PerturbanceFrequency, ref PerturbanceFrequency, ref PerturbanceAmplitude);
            //fastNoise.SetGradientPerturbAmp(PerturbanceAmplitude);

            //fastNoise.SetFractalType((FastNoiseBase.FractalType)(int)FractalMode);
            //fastNoise.SetFractalOctaves(Octaves);
            //fastNoise.SetFractalLacunarity(Lacunarity);
            //fastNoise.SetFractalGain(Gain);

            return new Bitmap(Width, Height);
        }

        private Bitmap GetCellularBitmap()
        {
            fastNoise = new FastNoiseBase(Seed);

            fastNoise.SetFrequency(Frequency);
            fastNoise.SetInterp((FastNoiseBase.Interp)(int)InterpolationMode);

            fastNoise.SetCellularJitter((float)Jitter);

            fastNoise.SetCellularDistanceFunction((FastNoiseBase.CellularDistanceFunction)CellularMode);
            fastNoise.SetCellularReturnType((FastNoiseBase.CellularReturnType)CellularOutput);

            //fastNoise.GradientPerturb(ref PerturbanceFrequency, ref PerturbanceFrequency, ref PerturbanceAmplitude);
            //fastNoise.SetGradientPerturbAmp(PerturbanceAmplitude);

            //fastNoise.SetFractalType((FastNoiseBase.FractalType)(int)FractalMode);
            //fastNoise.SetFractalOctaves(Octaves);
            //fastNoise.SetFractalLacunarity(Lacunarity);
            //fastNoise.SetFractalGain(Gain);

            return new Bitmap(Width, Height);
        }

        

        #endregion

        #region overrides

        public override string ToString()
        {
            return OutputStatus.ToString() + " Noise";
        }

        #endregion

    }
}
