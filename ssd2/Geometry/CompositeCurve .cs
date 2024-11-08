using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2.Geometry
{
    internal class CompositeCurve : ICurve, ICompositeCurve
    {
        private List<ICurve> curves = new List<ICurve>();

        public void Add(ICurve curve)
        {
            curves.Add(curve);
        }

        public void Remove(ICurve curve)
        {
            curves.Remove(curve);
        }

        public ICurve GetChild(int index)
        {
            return curves[index];
        }

        public void GetPoint(double t, out IPoint p)
        {
            // Реализация зависит от вашей логики компоновки кривых.
            // Например, можно обойти все кривые и собрать точки.
        }
    }
