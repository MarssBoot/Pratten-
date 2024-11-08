using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
abstract class VisualCurve : ICurve, IDrawable
    {
        protected ICurve curve;
        protected IPoint[] points = null;
        protected int n = 100;
        public int N { get => n; set => n = value; }

        public VisualCurve(ICurve curve)
        {
            this.curve = curve;
        }

        public abstract void Draw(IConcreteContext concreteContext);

        public virtual void GetPoint(double t, out IPoint p)
        {
            curve.GetPoint(t, out p);
        }

        // Новый метод для получения всех точек кривой
        protected void GeneratePoints()
        {
            points = new IPoint[n];
            for (int i = 0; i < n; i++)
            {
                double t = (double)i / (n - 1);
                curve.GetPoint(t, out points[i]);
            }
        }
    }
}
