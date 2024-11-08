using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ssd2
{
    internal class VisualPNG : VisualCurve
    {
        public VisualPNG(ICurve curve) : base(curve)
        {
        }

        public override void Draw(IConcreteContext concreteContext)
        {
            GeneratePoints();

            // Рисуем линии между последовательными точками
            for (int i = 0; i < points.Length - 1; i++)
            {
                concreteContext.GetGraphics().DrawLine(
                    concreteContext.GetPen(),
                    new PointF((float)points[i].X, (float)points[i].Y),
                    new PointF((float)points[i + 1].X, (float)points[i + 1].Y)
                );
            }

            // Сохраняем изображение
            string fullPath = HomePath.HP + concreteContext.GetFileName();
            try
            {
                concreteContext.GetBitmap().Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении изображения: {ex.Message}");
            }
            finally
            {
                concreteContext.GetGraphics().Dispose();
                concreteContext.GetBitmap().Dispose();
            }
        }
    }
}
