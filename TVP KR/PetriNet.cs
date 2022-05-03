using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_KR
{
  internal class PetriNet
  {
    AdjustableArrowCap _arrowCap = new AdjustableArrowCap(1, 1, false);


    public List<Vertex> _vertices;
    public List<Transition> _transitions;

    public PetriNet(List<Vertex> vertices, List<Transition> transitions)
    {
      _arrowCap.BaseCap = LineCap.Round;
      _arrowCap.BaseInset = 5;
      _arrowCap.StrokeJoin = LineJoin.Bevel;

      this._vertices = vertices;
      this._transitions = transitions;
    }

    public void addVertex(Vertex newVertex)
    {
      _vertices.Add(newVertex);
    }

    public void removeVertex(Vertex vertexToRemove)
    {
      _vertices.Remove(vertexToRemove);
    }

    public void addTransition(Transition newTransition)
    {
      _transitions.Add(newTransition);
    }

    public void removeTransition(Transition transitionToRemove)
    {
      _transitions.Remove(transitionToRemove);
    }

    public void drawPetriNet(Graphics img)
    {
      foreach (Vertex vertex in _vertices)
      {
        vertex.drawVertex(img);
      }
      foreach (Transition transition in _transitions)
      {
        transition.drawTransition(img);
      }
    }
  }
}
