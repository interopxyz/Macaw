using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sw = System.Windows;
using Sm = System.Windows.Media;
using Ws = System.Windows.Shapes;
using Pt = CsPotrace;
using Rg = Rhino.Geometry;

namespace Aviary.Macaw
{
    public static class TraceBitmap
    {
        public enum TurnModes {Black, White, Majority, Minority, Right };

        #region Tracing

        public static List<Rg.Polyline> TraceToRhino(this Bitmap input,bool optimize, TurnModes mode, int size, double tolerance, double threshold, double alpha)
        {
            List<List<Pt.Curve>> crvs = new List<List<Pt.Curve>>();
            List<Rg.Polyline> polylines = new List<Rg.Polyline>();

            int height = input.Height;

            Pt.Potrace.Clear();

            Pt.Potrace.curveoptimizing = optimize;

            Pt.Potrace.turnpolicy = (Pt.TurnPolicy)mode;

            Pt.Potrace.opttolerance = tolerance;
            Pt.Potrace.Treshold = threshold;
            Pt.Potrace.alphamax = alpha;

            Pt.Potrace.turdsize = size;

            Pt.Potrace.Potrace_Trace(input, crvs);

            foreach (var crvList in crvs)
            {
                Rg.Polyline polyline = new Rg.Polyline();
                polyline.Add(crvList[0].A.ToRhPoint());
                foreach (Pt.Curve curve in crvList)
                {
                    polyline.Add(curve.B.ToRhPoint());
                }
                polylines.Add(polyline);
            }

            return polylines;
        }

        public static Sw.Point ToPoint(this Pt.dPoint input)
        {
            return new Sw.Point(input.x, input.y);
        }

        public static Rg.Point3d ToRhPoint(this Pt.dPoint input)
        {
            return new Rg.Point3d(input.x, input.y,0);
        }

        #endregion

    }
}
