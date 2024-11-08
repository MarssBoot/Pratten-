using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2.Geometry
{
    internal class CompositeCurve : ICurve
    {
        private List<ICurve> _curves = new List<ICurve>();

        public void Add(ICurve curve)
        {
            _curves.Add(curve);
        }

        public void Remove(ICurve curve)
        {
            _curves.Remove(curve);
        }

        public ICurve GetChild(int index)
        {
            return _curves[index];
        }

        public void GetPoint(double t, out IPoint p)
        {
            p = new Point();
            if (_curves.Count == 0)
            {
                p = null;
                return;
            }

            double segmentLength = 1.0 / _curves.Count;
            int index = (int)(t / segmentLength);
            if (index >= _curves.Count)
                index = _curves.Count - 1;

            double localT = (t - index * segmentLength) / segmentLength;
            _curves[index].GetPoint(localT, out p);
        }

        public List<ICurve> GetCurves()
        {
            return _curves;
        }
    }
}
