using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_KR
{
  internal class Vertex
  {
    private int _vertexRadius = 20;
    private int _positionRadius = 15;
    
    private Pen _vertexPen = new Pen(Color.Black, 2);
    private Pen _activeVertexPen = new Pen(Color.Green, 2);
    private Brush _vertexBrush = Brushes.Black;
    private Brush _positionBrush = Brushes.Red;
    private String _namePrefix = "P";

    private int _index = 1;
    private String _name;

    public Point vertexCenter { get; } = new Point();
    public int positionsCount { get; set; } = 0;

    public Vertex(Point vertexCenter, int index)
    {
      this.vertexCenter = vertexCenter;
      this._name = _namePrefix + index.ToString();
    }

    //public Vertex(Point vertexCenter, int positionsCount)
    //{
    //  this.vertexCenter = vertexCenter;
    //  this.positionsCount = positionsCount;
    //}

    public void drawVertex(Graphics img, bool isActive = false)
    {
      Pen currentPen = isActive ? _vertexPen : _activeVertexPen;

      GraphicsExtensions.DrawCircle(img, _vertexPen, vertexCenter.X, vertexCenter.Y, _vertexRadius);
      img.DrawString(_name, new Font("Arial", 15), _vertexBrush, vertexCenter.X - _vertexRadius - 30, vertexCenter.Y - _vertexRadius - 10);
    }

    public void drawPositions(Graphics img)
    {
      if (positionsCount != 0)
      {
        for (int i = 0; i < positionsCount; ++i)
        {
          int x = Convert.ToInt32(Math.Cos(i * Math.PI * (360 / this.positionsCount) / 180) * 20 + vertexCenter.X + 5);
          int y = Convert.ToInt32(Math.Sin(i * Math.PI * (360 / this.positionsCount) / 180) * 20 + vertexCenter.Y + 5);

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
