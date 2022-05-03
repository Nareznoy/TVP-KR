using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_KR
{
  [Serializable]
  internal class PetriNet
  {
    public List<Vertex> vertices { get; set; }
    public List<Transition> transitions { get; set; }

    private int _currentActiveTransitionIndex = 1;

    public PetriNet()
    {
      this.vertices = new List<Vertex>();
      this.transitions = new List<Transition>();
    }

    public PetriNet(List<Vertex> vertices, List<Transition> transitions)
    {
      this.vertices = vertices;
      this.transitions = transitions;
    }

    #region Add || Remove
    public void addVertex(Vertex newVertex)
    {
      vertices.Add(newVertex);
    }

    public void removeVertex(Vertex vertexToRemove)
    {
      if (vertices.Contains(vertexToRemove))
      {
        vertices.Remove(vertexToRemove);
      }
    }

    public void addTransition(Transition newTransition)
    {
      transitions.Add(newTransition);
    }

    public void removeTransition(Transition transitionToRemove)
    {
      if (transitions.Contains(transitionToRemove))
      {
        transitions.Remove(transitionToRemove);
      }
    }

    #endregion

    public Vertex getVertexByPoint(Point p)
    {
      foreach (Vertex vertex in vertices)
      {
        if (vertex.isPointInside(p))
        {
          return vertex;
        }
      }
      return null;
    }

    public Transition getTransitionByPoint(Point p)
    {
      foreach (Transition transition in transitions)
      {
        if (transition.isPointInside(p))
        {
          return transition;
        }
      }
      return null;
    }

    public void drawPetriNet(Graphics img)
    {
      foreach (Vertex vertex in vertices)
      {
        vertex.drawVertex(img);
      }
      foreach (Transition transition in transitions)
      {
        transition.drawTransition(img);
      }
    }

    public int doStep()
    {
      transitions[_currentActiveTransitionIndex].tryDoTransition();
      int doTransitionIndex = _currentActiveTransitionIndex;
      
      if (_currentActiveTransitionIndex < transitions.Count - 1)
      {
        _currentActiveTransitionIndex++;
      }
      else
      {
        _currentActiveTransitionIndex = 0;
      }

      return doTransitionIndex;
    }
  }
}
