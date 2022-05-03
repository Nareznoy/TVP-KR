using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_KR
{
  [Serializable]
  internal class Vertex
  {
    private int _vertexRadius = 20;
    private int _positionRadius = 5;
    
    
    private String _namePrefix = "P";

    private String _name;

    public Point vertexCenter { get; } = new Point();
    public int positionsCount { get; set; } = 0;

    public Vertex(Point vertexCenter, int index)
    {
      this.vertexCenter = vertexCenter;
      this._name = _namePrefix + index.ToString();
    }

    public void addPosition()
    {
      positionsCount++;
    }

    public void drawVertex(Graphics img, bool isActive = false)
    {
      Pen _vertexPen = new Pen(Color.Black, 2);
      Pen _activeVertexPen = new Pen(Color.Red, 3);
      Brush _vertexBrush = Brushes.Black;
      

      Pen currentPen = isActive ? _activeVertexPen : _vertexPen;

      GraphicsExtensions.DrawCircle(img, currentPen, vertexCenter.X, vertexCenter.Y, _vertexRadius);
      img.DrawString(_name, new Font("Arial", 15), _vertexBrush, vertexCenter.X - _vertexRadius - 30, vertexCenter.Y - _vertexRadius - 10);

      drawPositions(img);
    }

    public void drawPositions(Graphics img)
    {
      Brush _positionBrush = Brushes.Red;

      if (positionsCount != 0)
      {
        for (int i = 0; i < positionsCount; ++i)
        {
          int x = Convert.ToInt32(Math.Cos(i * Math.PI * (360 / this.positionsCount) / 180) * 10 + vertexCenter.X);
          int y = Convert.ToInt32(Math.Sin(i * Math.PI * (360 / this.positionsCount) / 180) * 10 + vertexCenter.Y);

          GraphicsExtensions.FillCircle(img, _positionBrush, x, y, _positionRadius);
        }
      }
    }

    public bool isPointInside(Point p)
    {
      if (Math.Pow(vertexCenter.X - p.X, 2) + Math.Pow(vertexCenter.Y - p.Y, 2) <= _vertexRadius * _vertexRadius)
      {
        return true;
      }
      return false;
    }
  }
}
