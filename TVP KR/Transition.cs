using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_KR
{
  internal class Transition
  {
    private int _transitionWidth = 50;
    private int _curveHeight = 10;
    private Pen _edgePen = new Pen(Color.Black, 2);
    private Pen _transtitionPen = new Pen(Color.Black, 2);
    private Pen _activeTranstitionPen = new Pen(Color.Green, 2);
    AdjustableArrowCap _arrowCap = new AdjustableArrowCap(10, 10, true);

    //private List<Vertex> _startVertices = new List<Vertex>();
    //private List<Vertex> _endVertices = new List<Vertex>();

    private List<Edge> _edgeList = new List<Edge>();

    private Point _transitionCenter = new Point();
    public bool isVertical { get; set; } = false;

    public Transition(Point transitionCenter)
    {
      this._transitionCenter = transitionCenter;

      _arrowCap.BaseCap = LineCap.Round;
      _arrowCap.BaseInset = 5;
      _arrowCap.StrokeJoin = LineJoin.Bevel;

      _edgePen.CustomEndCap = _arrowCap;
    }

    //public Transition(Point transitionCenter, IEnumerable<Vertex> startVertices, IEnumerable<Vertex> endVertices)
    //{
    //  foreach (Vertex startVertex in startVertices)
    //  {
    //    this._startVertices.Add(startVertex);
    //  }

    //  foreach (Vertex endVertex in endVertices)
    //  {
    //    if (endVertex != null)
    //    {
    //      this._endVertices.Add(endVertex);
    //    }
    //  }

    //  this._transitionCenter = transitionCenter;
    //}

    public void addEdge(Vertex startVertex, Vertex endVertex)
    {
      _edgeList.Add(new Edge(startVertex, endVertex));
      //_startVertices.Add(startVertex);
      //_endVertices.Add(endVertex);
    }

    public bool doTransition()
    {
      //if (isTransitionPossible())
      //{
      //  foreach (Vertex startVertex in this._startVertices)
      //  {
      //    startVertex.positionsCount--;
      //  }
      //  foreach (Vertex endVertex in this._endVertices)
      //  {
      //    endVertex.positionsCount++;
      //  }
      //}

      return false;
    }

    public void drawTransition(Graphics img, bool isActive = false)
    {
      Pen curentPen = isActive ? _activeTranstitionPen : _transtitionPen;

      int widthDiff = this._transitionWidth / 2;
      if (!this.isVertical)
      {
        img.DrawLine(curentPen
          , _transitionCenter.X - widthDiff
          , _transitionCenter.Y
          , _transitionCenter.X + widthDiff
          , _transitionCenter.Y);
      }
      else
      {
        img.DrawLine(curentPen
          , _transitionCenter.X
          , _transitionCenter.Y - widthDiff
          , _transitionCenter.X
          , _transitionCenter.Y + widthDiff);
      }

      if (_edgeList.Any())
      {
        int edgeDiff = _transitionWidth / _edgeList.Count;
        foreach (Edge edge in _edgeList)
        {
          if (!this.isVertical)
          {
            // Draw Start Vertex
            if (isStartVertexBelowTransition(edge.startVertex))
            {
              if (!isVertical)
              {
                Point start = new Point(edge.startVertex.vertexCenter.X, edge.startVertex.vertexCenter.Y);

                int diff = (_transitionCenter.X - edge.startVertex.vertexCenter.X) / 2;
                Point checkpoint1 = new Point(edge.startVertex.vertexCenter.X + diff, _transitionCenter.Y + diff);
                Point checkpoint2 = new Point(_transitionCenter.X - widthDiff + edgeDiff, _transitionCenter.Y - _curveHeight);

                Point end = new Point(_transitionCenter.X - widthDiff + edgeDiff, _transitionCenter.Y);

                img.DrawBezier(_edgePen
                  , start
                  , checkpoint1
                  , checkpoint2
                  , end);
              }
              //else
              //{

              //}
            }
            else
            {
              if (!this.isVertical)
              {
                img.DrawLine(_edgePen
                  , edge.startVertex.vertexCenter.X
                  , edge.startVertex.vertexCenter.Y
                  , _transitionCenter.X - widthDiff + edgeDiff
                  , _transitionCenter.Y);
              }
              else
              {
                img.DrawLine(_edgePen
                  , edge.startVertex.vertexCenter.X
                  , edge.startVertex.vertexCenter.Y
                  , _transitionCenter.X
                  , _transitionCenter.Y - widthDiff + edgeDiff);
              }
            }

            // Draw End Vertex
            if (isEndVertexUpperTransition(edge.startVertex))
            {
              if (!isVertical)
              {
                Point start = new Point(_transitionCenter.X - widthDiff + edgeDiff, _transitionCenter.Y);

                int diff = (_transitionCenter.Y - edge.endVertex.vertexCenter.Y) / 2;
                Point checkpoint1 = new Point(_transitionCenter.X - widthDiff + edgeDiff, _transitionCenter.Y + _curveHeight);
                Point checkpoint2;
                if (_transitionCenter.X - widthDiff + edgeDiff < _transitionCenter.X)
                {
                  checkpoint2 = new Point(_transitionCenter.X - diff, _transitionCenter.Y - diff);
                }
                else
                {
                  checkpoint2 = new Point(_transitionCenter.X + diff, _transitionCenter.Y - diff);
                }

                Point end = new Point(_transitionCenter.X - widthDiff + edgeDiff, _transitionCenter.Y);

                img.DrawBezier(_edgePen
                  , start
                  , checkpoint1
                  , checkpoint2
                  , end);
              }
              //else
              //{

              //}
            }
            else
            {
              if (!this.isVertical)
              {
                img.DrawLine(_edgePen
                   , _transitionCenter.X - widthDiff + edgeDiff
                   , _transitionCenter.Y
                   , edge.endVertex.vertexCenter.X
                   , edge.endVertex.vertexCenter.Y);
              }
              else
              {
                img.DrawLine(_edgePen
                   , _transitionCenter.X
                   , _transitionCenter.Y - widthDiff + edgeDiff
                   , edge.endVertex.vertexCenter.X
                   , edge.endVertex.vertexCenter.Y);
              }
            }
          }
        }
      }

      if (_edgeList.Any())
      {
        int edgeDiff = _transitionWidth / _edgeList.Count;
        foreach (Edge edge in _edgeList)
        {
          if (!this.isVertical)
          {
            img.DrawLine(_edgePen
              , edge.startVertex.vertexCenter.X
              , edge.startVertex.vertexCenter.Y
              , _transitionCenter.X - widthDiff + edgeDiff
              , _transitionCenter.Y);
          }
          else
          {
            img.DrawLine(_edgePen
              , edge.startVertex.vertexCenter.X
              , edge.startVertex.vertexCenter.Y
              , _transitionCenter.X
              , _transitionCenter.Y - widthDiff + edgeDiff);
          }

          if (!this.isVertical)
          {
            img.DrawLine(_edgePen
               , _transitionCenter.X - widthDiff + edgeDiff
               , _transitionCenter.Y
               , edge.endVertex.vertexCenter.X
               , edge.endVertex.vertexCenter.Y);
          }
          else
          {
            img.DrawLine(_edgePen
               , _transitionCenter.X
               , _transitionCenter.Y - widthDiff + edgeDiff
               , edge.endVertex.vertexCenter.X
               , edge.endVertex.vertexCenter.Y);
          }
          edgeDiff += edgeDiff;
        }
      }

      //if (_startVertices.Any())
      //{
      //  int edgeDiff = _transitionWidth / _startVertices.Count;
      //  foreach (Vertex startVertex in _startVertices)
      //  {
      //    if (!this.isVertical)
      //    {
      //      img.DrawLine(_edgePen
      //        , startVertex.vertexCenter.X
      //        , startVertex.vertexCenter.Y
      //        , _transitionCenter.X - widthDiff + edgeDiff
      //        , _transitionCenter.Y);
      //    }
      //    else
      //    {
      //      img.DrawLine(_edgePen
      //        , startVertex.vertexCenter.X
      //        , startVertex.vertexCenter.Y
      //        , _transitionCenter.X
      //        , _transitionCenter.Y - widthDiff + edgeDiff);
      //    }

      //    edgeDiff += edgeDiff;
      //  }
      //}

      //if (_endVertices.Any())
      //{
      //  int edgeDiff = _transitionWidth / _startVertices.Count;
      //  foreach (Vertex endVertex in _endVertices)
      //  {
      //    if (!this.isVertical)
      //    {
      //      img.DrawLine(_edgePen
      //         , _transitionCenter.X - widthDiff + edgeDiff
      //         , _transitionCenter.Y
      //         , endVertex.vertexCenter.X
      //         , endVertex.vertexCenter.Y);
      //    }
      //    else
      //    {
      //      img.DrawLine(_edgePen
      //         , _transitionCenter.X
      //         , _transitionCenter.Y - widthDiff + edgeDiff
      //         , endVertex.vertexCenter.X
      //         , endVertex.vertexCenter.Y);
      //    }
      //    edgeDiff += edgeDiff;
      //  }
      //}
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

  //private bool isTransitionPossible()
  //  {
  //    foreach (Vertex startVertex in this._startVertices)
  //    {
  //      if (startVertex.positionsCount == 0)
  //      {
  //        return false;
  //      }
  //    }
  //    return true;
  //  }
  }
}
