namespace ssd2.Geometry
{
    internal interface ICompositeCurve
    {
        void Add(ICurve curve);
        ICurve GetChild(int index);
        void GetPoint(double t, out IPoint p);
        void Remove(ICurve curve);
    }
}