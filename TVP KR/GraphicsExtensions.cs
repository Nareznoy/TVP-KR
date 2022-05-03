using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_KR
{
  public static class GraphicsExtensions
  {
    private static Pen _vertexPen = new Pen(Color.Black, 2);
    private static Pen _activeVertexPen = new Pen(Color.Red, 3);
    private static Brush _vertexBrush = Brushes.Black;
    private static Brush _positionBrush = Brushes.Red;

    public static void DrawCircle(this Graphics g, Pen pen,
                                  float centerX, float centerY, float radius)
    {
      g.DrawEllipse(pen, centerX - radius, centerY - radius,
                    radius + radius, radius + radius);
    }

    public static void FillCircle(this Graphics g, Brush brush,
                                  float centerX, float centerY, float radius)
    {
      g.FillEllipse(brush, centerX - radius, centerY - radius,
                    radius + radius, radius + radius);
    }
  }
}
