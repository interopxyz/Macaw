using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rg = Rhino.Geometry;
using Ac = Accord;

namespace Aviary.Macaw
{
    public static class RhinoExtensions
    {

        public static Rg.Rectangle3d ToRhinoRectangle(this System.Drawing.Rectangle input, int transposition = 0)
        {
            return new Rg.Rectangle3d(Rg.Plane.WorldXY,new Rg.Interval(input.Left,input.Right),new Rg.Interval(transposition-input.Bottom, transposition - input.Top));
        }

        public static System.Drawing.Rectangle ToDrawingRect(this Rg.Rectangle3d input, int transposition = 0)
        {
            if (transposition > 0) return new System.Drawing.Rectangle((int)input.Corner(0).X, (int)(transposition - input.Corner(3).Y), (int)input.Width, (int)input.Height);
            return new System.Drawing.Rectangle((int)input.Corner(0).X, (int)input.Corner(0).Y, (int)input.Width, (int)input.Height);
        }

        public static Rg.Point3d ToRhPoint(this System.Drawing.Point input, int transposition=0)
        {
            return new Rg.Point3d(input.X, input.Y, 0);
        }

        public static System.Drawing.Point ToDrawingPoint(this Rg.Point3d input, int transposition = 0)
        {
            if (transposition > 0) return new System.Drawing.Point((int)input.X, (int)(transposition-input.Y));
            return new System.Drawing.Point((int)input.X, (int)input.Y);
        }

        public static List<Rg.Point3d> ToRhinoPoints(this List<Ac.IntPoint> input, int transposition = 0)
        {
            List<Rg.Point3d> points = new List<Rg.Point3d>();

            foreach(Ac.IntPoint point in input)
            {
                points.Add(point.ToRhPoint(transposition));
            }
            return points;
        }

        public static Rg.Polyline ToPolyline(this List<Rg.Point3d> input, bool isClosed = false)
        {
            Rg.Polyline polyline = new Rg.Polyline(input);
            if(isClosed)polyline.Add(input[0]);

            return polyline;
        }

        public static Rg.Point3d ToRhPoint(this Ac.IntPoint input, int transposition = 0)
        {
            return new Rg.Point3d(input.X, transposition - input.Y,0);
        }

        public static Rg.Point3d ToRhPoint(this Ac.Point input, int transposition = 0)
        {
            return new Rg.Point3d(input.X, transposition - input.Y, 0);
        }

    }
}
