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

    public PetriNet(PetriNet petriNet)
    {
      this.vertices = new List<Vertex>();
      this.transitions = new List<Transition>();

      foreach (Vertex vertex in petriNet.vertices)
      {
        this.vertices.Add(new Vertex(vertex));
      }
      foreach (Transition transition in petriNet.transitions)
      {
        this.transitions.Add(new Transition(transition));
      }

      this._currentActiveTransitionIndex = petriNet._currentActiveTransitionIndex;
    }

    public PetriNet()
    {
      this.vertices = new List<Vertex>();
      this.transitions = new List<Transition>();
    }

    public PetriNet(string netState)
    {
      String[] strArray = netState.Split(',');
      int[] intArray = new int[strArray.Length];
      for (int i = 0; i < strArray.Length; i++)
      {
        intArray[i] = Int32.Parse(strArray[i]);
      }
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

    public bool doTransitionByIndex(int transitionIndex)
    {
      return transitions[transitionIndex].tryDoTransition();
    }

    public int doStep()
    {
      transitions[_currentActiveTransitionIndex].tryDoTransition();
      int doTransitionIndex = _currentActiveTransitionIndex;
      
      if (_currentActiveTransitionIndex < transitions.Count - 1)
      {
        Random rnd = new Random();
        //_currentActiveTransitionIndex = rnd.Next(0, transitions.Count - 1);
        _currentActiveTransitionIndex++;
      }
      else
      {
        _currentActiveTransitionIndex = 0;
      }

      return doTransitionIndex;
    }

    public override string ToString()
    {
      List<String> vertexStates = new List<String>();
      foreach (Vertex vertex in vertices)
      {
        vertexStates.Add(vertex.positionsCount.ToString());
      }

      return String.Join(",", vertexStates);
    }
  }
}
