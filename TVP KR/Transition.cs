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
  [Serializable]
  internal class Transition
  {
    private int _transitionWidth = 50;

    private List<Vertex> _startVertices = new List<Vertex>();
    private List<Vertex> _endVertices = new List<Vertex>();

    public Point transitionCenter { get; set; } = new Point();
    public bool isVertical { get; set; } = false;
    public bool isActive { get; set; } = false;

    public Transition(Point transitionCenter)
    {
      this.transitionCenter = transitionCenter;
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
      Pen _edgePen = new Pen(Color.Black, 2);
      Pen _blackTranstitionPen = new Pen(Color.Black, 2);
      Pen _redTranstitionPen = new Pen(Color.Red, 3);

      AdjustableArrowCap _arrowCap = new AdjustableArrowCap(10, 10, true);
      _arrowCap.BaseCap = LineCap.Round;
      _arrowCap.BaseInset = 5;
      _arrowCap.StrokeJoin = LineJoin.Bevel;
      _edgePen.CustomEndCap = _arrowCap;

      Pen curentPen = isSelected || isActive ? _redTranstitionPen : _blackTranstitionPen;

      int halfWidth = this._transitionWidth / 2;
      if (!this.isVertical)
      {
        img.DrawLine(curentPen
          , transitionCenter.X - halfWidth
          , transitionCenter.Y
          , transitionCenter.X + halfWidth
          , transitionCenter.Y);
      }
      else
      {
        img.DrawLine(curentPen
          , transitionCenter.X
          , transitionCenter.Y - halfWidth
          , transitionCenter.X
          , transitionCenter.Y + halfWidth);
      }

      
      if (_startVertices.Any())
      { // Draw Start Vertex
        int edgeStep = _transitionWidth / _startVertices.Count;
        for (int i = 0; i < _startVertices.Count; i++)
        {
          if (!this.isVertical)
          {
            Vector2 norm = Vector2.Normalize(new Vector2((transitionCenter.X - halfWidth + i * edgeStep) - (_startVertices[i].vertexCenter.X)
              , (transitionCenter.Y) - (_startVertices[i].vertexCenter.Y)));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(20, norm);

            img.DrawLine(_edgePen
              , _startVertices[i].vertexCenter.X + v2.X
              , _startVertices[i].vertexCenter.Y + v2.Y
              , transitionCenter.X - halfWidth + ((_startVertices.Count == 1) ? halfWidth : i * edgeStep)
              , transitionCenter.Y);
          }
          else
          {
            Vector2 norm = Vector2.Normalize(new Vector2((transitionCenter.X) - (_startVertices[i].vertexCenter.X)
              , (transitionCenter.Y - halfWidth + i * edgeStep) - (_startVertices[i].vertexCenter.Y)));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(20, norm);

            img.DrawLine(_edgePen
              , _startVertices[i].vertexCenter.X + v2.X
              , _startVertices[i].vertexCenter.Y + v2.Y
              , transitionCenter.X
              , transitionCenter.Y - halfWidth + ((_startVertices.Count == 1) ? halfWidth : i * edgeStep));
          }
        }
      }

      
      if (_endVertices.Any())
      { // Draw End Vertex
        //int edgeDiff = _transitionWidth / _startVertices.Count;

        int edgeStep = _transitionWidth / _startVertices.Count;
        for (int i = 0; i < _endVertices.Count; i++)
        {
          if (!this.isVertical)
          {
            Vector2 norm = Vector2.Normalize(new Vector2(_endVertices[i].vertexCenter.X - transitionCenter.X - halfWidth + i * edgeStep
              , _endVertices[i].vertexCenter.Y - transitionCenter.Y));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(-20, norm);

            img.DrawLine(_edgePen
               , transitionCenter.X - halfWidth + ((_endVertices.Count == 1) ? halfWidth : i * edgeStep)
               , transitionCenter.Y
               , _endVertices[i].vertexCenter.X + v2.X
               , _endVertices[i].vertexCenter.Y + v2.Y);
          }
          else
          {
            Vector2 norm = Vector2.Normalize(new Vector2(_endVertices[i].vertexCenter.X - transitionCenter.X
              , _endVertices[i].vertexCenter.Y - transitionCenter.Y - halfWidth + i * edgeStep));
            // для конца линии умножаем на отрицательный скаляр - получаем вектор в обратном направлении
            Vector2 v2 = Vector2.Multiply(-20, norm);

            img.DrawLine(_edgePen
               , transitionCenter.X
               , transitionCenter.Y - halfWidth + ((_endVertices.Count == 1) ? halfWidth : i * edgeStep)
               , _endVertices[i].vertexCenter.X + v2.X
               , _endVertices[i].vertexCenter.Y + v2.Y);
          }
        }
      }
    }

    public bool isPointInside(Point p)
    {
      float widthDiff = this._transitionWidth / 2;

      if ( (p.X < transitionCenter.X + widthDiff) 
        && (p.X > transitionCenter.X - widthDiff) 
        && (p.Y < transitionCenter.Y + widthDiff / 2) 
        && (p.Y > transitionCenter.Y - widthDiff / 2) )
      {
        return true;
      }
      return false;
    }

    private bool isStartVertexBelowTransition(Vertex vertex)
    {
      if (!isVertical)
      {
        if (vertex.vertexCenter.Y > transitionCenter.Y)
        {
          return true;
        }
        return false;
      }
      else
      {
        if (vertex.vertexCenter.X > transitionCenter.X)
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
        if (vertex.vertexCenter.Y < transitionCenter.Y)
        {
          return true;
        }
        return false;
      }
      else
      {
        if (vertex.vertexCenter.X < transitionCenter.X)
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
