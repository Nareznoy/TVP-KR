using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TVP_KR
{
  internal class Transition
  {
    private int _transitionWidth = 50;
    private Pen _edgePen = new Pen(Color.Black, 2);
    private Pen _blackTranstitionPen = new Pen(Color.Black, 2);
    private Pen _redTranstitionPen = new Pen(Color.Red, 3);
    AdjustableArrowCap _arrowCap = new AdjustableArrowCap(10, 10, true);

    private List<Vertex> _startVertices = new List<Vertex>();
    private List<Vertex> _endVertices = new List<Vertex>();

    private Point _transitionCenter = new Point();
    public bool isVertical { get; set; } = false;
    public bool isActive { get; set; } = false;

    public Transition(Point transitionCenter)
    {
      this._transitionCenter = transitionCenter;

      _arrowCap.BaseCap = LineCap.Round;
      _arrowCap.BaseInset = 5;
      _arrowCap.StrokeJoin = LineJoin.Bevel;

      _edgePen.CustomEndCap = _arrowCap;
    }

    public void addEdge(Vertex startVertex, Vertex endVertex)
    {
      if (!_startVertices.Contains(startVertex))
      {
        _startVertices.Add(startVertex);
      }
      if (!_endVertices.Contains(endVertex))
      {
        _endVertices.Add(endVertex);
      }
    }

    public bool tryDoTransition()
    {
      if (isTransitionPossible())
      {
        foreach (Vertex startVertex in this._startVertices)
        {
          startVertex.positionsCount--;
        }
        foreach (Vertex endVertex in this._endVertices)
        {
          endVertex.positionsCount++;
        }
      }

      return false;
    }

    public void drawTransition(Graphics img, bool isSelected = false)
    {
      Pen curentPen = isSelected || isActive ? _redTranstitionPen : _blackTranstitionPen;

      int halfWidth = this._transitionWidth / 2;
      if (!this.isVertical)
      {
        img.DrawLine(curentPen
          , _transitionCenter.X - halfWidth
          , _transitionCenter.Y
          , _transitionCenter.X + halfWidth
          , _transitionCenter.Y);
      }
      else
      {
        img.DrawLine(curentPen
          , _transitionCenter.X
          , _transitionCenter.Y - halfWidth
          , _transitionCenter.X
          , _transitionCenter.Y + halfWidth);
      }

      
      if (_startVertices.Any())
      { // Draw Start Vertex
        int edgeStep = _transitionWidth / _startVertices.Count;
        for (int i = 0; i < _startVertices.Count; i++)
        {
          if (!this.isVertical)
          {
            Vector2 norm = Vector2.Normalize(new Vector2((_transitionCenter.X - halfWidth + i * edgeStep) - (_startVertices[i].vertexCenter.X)
              , (_transitionCenter.Y) - (_startVertices[i].vertexCenter.Y)));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(20, norm);

            img.DrawLine(_edgePen
              , _startVertices[i].vertexCenter.X + v2.X
              , _startVertices[i].vertexCenter.Y + v2.Y
              , _transitionCenter.X - halfWidth + i * edgeStep
              , _transitionCenter.Y);
          }
          else
          {
            Vector2 norm = Vector2.Normalize(new Vector2((_transitionCenter.X) - (_startVertices[i].vertexCenter.X)
              , (_transitionCenter.Y - halfWidth + i * edgeStep) - (_startVertices[i].vertexCenter.Y)));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(20, norm);

            img.DrawLine(_edgePen
              , _startVertices[i].vertexCenter.X + v2.X
              , _startVertices[i].vertexCenter.Y + v2.Y
              , _transitionCenter.X
              , _transitionCenter.Y - halfWidth + i * edgeStep);
          }
        }
      }

      
      if (_endVertices.Any())
      { // Draw End Vertex
        int edgeDiff = _transitionWidth / _startVertices.Count;
        
        foreach (Vertex endVertex in _endVertices)
        {
          if (!this.isVertical)
          {
            Vector2 norm = Vector2.Normalize(new Vector2(endVertex.vertexCenter.X - _transitionCenter.X - halfWidth + edgeDiff
              , endVertex.vertexCenter.Y - _transitionCenter.Y));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(-20, norm);

            img.DrawLine(_edgePen
               , _transitionCenter.X - halfWidth + edgeDiff
               , _transitionCenter.Y
               , endVertex.vertexCenter.X + v2.X
               , endVertex.vertexCenter.Y + v2.Y);
          }
          else
          {
            Vector2 norm = Vector2.Normalize(new Vector2(endVertex.vertexCenter.X - _transitionCenter.X
              , endVertex.vertexCenter.Y - _transitionCenter.Y - halfWidth + edgeDiff));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(-20, norm);

            img.DrawLine(_edgePen
               , _transitionCenter.X
               , _transitionCenter.Y - halfWidth + edgeDiff
               , endVertex.vertexCenter.X + v2.X
               , endVertex.vertexCenter.Y + v2.Y);

          }
          edgeDiff += edgeDiff;
        }
      }
    }

    public bool isPointInside(Point p)
    {
      float widthDiff = this._transitionWidth / 2;

      if ( (p.X < _transitionCenter.X + widthDiff) 
        && (p.X > _transitionCenter.X - widthDiff) 
        && (p.Y < _transitionCenter.Y + widthDiff / 2) 
        && (p.Y > _transitionCenter.Y - widthDiff / 2) )
      {
        return true;
      }
      return false;
    }

    private bool isStartVertexBelowTransition(Vertex vertex)
    {
      if (!isVertical)
      {
        if (vertex.vertexCenter.Y > _transitionCenter.Y)
        {
          return true;
        }
        return false;
      }
      else
      {
        if (vertex.vertexCenter.X > _transitionCenter.X)
        {
          return true;
        }
        return false;
      }
      
    }

    private bool isEndVertexUpperTransition(Vertex vertex)
    {
      if (!isVertical)
      {
        if (vertex.vertexCenter.Y < _transitionCenter.Y)
        {
          return true;
        }
        return false;
      }
      else
      {
        if (vertex.vertexCenter.X < _transitionCenter.X)
        {
          return true;
        }
        return false;
      }
      
    }

    private bool isTransitionPossible()
    {
      foreach (Vertex startVertex in this._startVertices)
      {
        if (startVertex.positionsCount == 0)
        {
          return false;
        }
      }
      return true;
    }
  }
}
