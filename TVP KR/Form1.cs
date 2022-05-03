using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_KR
{
  public enum DrawMode
  {
    AddVertex,
    RemoveVertex,
    AddTransition,
    AddPosition,
    RemovePosition,
    AddEdge,
    None
  }

  public partial class Form1 : Form
  {
    private DrawMode currentDrawMode = DrawMode.None;
    private bool _isVerticalTransition = false;

    Graphics img;
    private int _vertexCount = 0;

    private List<Vertex> _vertices = new List<Vertex>();
    private List<Transition> _transitions = new List<Transition>();

    private Vertex _firstSelectedVertex;
    private Vertex _secondSelectedVertex;
    private Transition _selectedTransition;

    public Form1()
    {
      InitializeComponent();
      img = pictureBoxPetriNet.CreateGraphics();
    }

    public void switchDrawMode(DrawMode newDrawMode)
    {
      switch (newDrawMode)
      {
        case DrawMode.AddVertex:
          btnAddVertex.Enabled = false;
          break;
        case DrawMode.RemoveVertex:
          btnRemoveVertex.Enabled = false;
          break;
        case DrawMode.AddTransition:
          btnAddTransition.Enabled = false;
          break;
        case DrawMode.AddPosition:
          btnAddPosition.Enabled = false;
          break;
        case DrawMode.RemovePosition:
          btnRemovePosition.Enabled = false;
          break;
        case DrawMode.AddEdge:
          btnAddEdge.Enabled = false;
          break;
      }

      if (currentDrawMode != DrawMode.None)
      {
        switch (currentDrawMode)
        {
          case DrawMode.AddVertex:
            btnAddVertex.Enabled = true;
            break;
          case DrawMode.RemoveVertex:
            btnRemoveVertex.Enabled = true;
            break;
          case DrawMode.AddTransition:
            btnAddTransition.Enabled = true;
            break;
          case DrawMode.AddPosition:
            btnAddPosition.Enabled = true;
            break;
          case DrawMode.RemovePosition:
            btnRemovePosition.Enabled = true;
            break;
          case DrawMode.AddEdge:
            btnAddEdge.Enabled = true;
            break;
          case DrawMode.None:
            btnAddPosition.Enabled = true;
            btnRemoveVertex.Enabled = true;
            btnAddVertex.Enabled = true;
            btnRemovePosition.Enabled = true;
            btnAddEdge.Enabled = true;
            break;
        }
      }
      currentDrawMode = newDrawMode;
    }

    private void btnAddVertex_Click(object sender, EventArgs e)
    {
      switchDrawMode(DrawMode.AddVertex);
    }

    private void btnRemoveVertex_Click(object sender, EventArgs e)
    {
      switchDrawMode(DrawMode.RemoveVertex);
    }

    private void btnAddTransition_Click(object sender, EventArgs e)
    {
      switchDrawMode(DrawMode.AddTransition);
    }

    private void btnAddPosition_Click(object sender, EventArgs e)
    {
      switchDrawMode(DrawMode.AddPosition);
    }

    private void btnRemovePosition_Click(object sender, EventArgs e)
    {
      switchDrawMode(DrawMode.RemovePosition);
    }

    private void btnAddEdge_Click(object sender, EventArgs e)
    {
      switchDrawMode(DrawMode.AddEdge);
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void pictureBoxPetriNet_MouseClick(object sender, MouseEventArgs e)
    {
      switch (currentDrawMode)
      {
        case DrawMode.AddVertex:
          Vertex newVertex = new Vertex(e.Location, _vertexCount++);
          _vertices.Add(newVertex);
          newVertex.drawVertex(img);
          break;
        case DrawMode.RemoveVertex:
          break;
        case DrawMode.AddTransition:
          Transition newTransition = new Transition(e.Location);
          _transitions.Add(newTransition);
          newTransition.isVertical = _isVerticalTransition;
          newTransition.drawTransition(img);
          break;
        case DrawMode.AddPosition:
          break;
        case DrawMode.RemovePosition:
          break;
        case DrawMode.AddEdge:
          if (_firstSelectedVertex == null)
          {
            Vertex currentSelectedVertex = getVertexByPoint(e.Location);
            if (currentSelectedVertex == null)
            {
              lblTransitionInfo.Text = "Select first vertex";
            }
            else
            {
              _firstSelectedVertex = currentSelectedVertex;
              currentSelectedVertex.drawVertex(img, true);
              return;
            }
          }

          if (_selectedTransition == null)
          {
            Transition currentSelectedTransition = getTransitionByPoint(e.Location);
            if (currentSelectedTransition == null)
            {
              lblTransitionInfo.Text = "Select transition";
            }
            else
            {
              _selectedTransition = currentSelectedTransition;
              currentSelectedTransition.drawTransition(img, true);
              return;
            }
          }

          if (_secondSelectedVertex == null)
          {
            Vertex currentSelectedVertex = getVertexByPoint(e.Location);
            if (currentSelectedVertex == null)
            {
              lblTransitionInfo.Text = "Select second vertex";
            }
            else
            {
              _secondSelectedVertex = currentSelectedVertex;

              _selectedTransition.addEdge(_firstSelectedVertex, _secondSelectedVertex);
              _selectedTransition.drawTransition(img);

              _firstSelectedVertex = null;
              _secondSelectedVertex = null;
              _selectedTransition = null;
              return;
            }
          }
          break;
      }
    }

    private Vertex getVertexByPoint(Point p)
    {
      foreach (Vertex vertex in _vertices)
      {
        if (vertex.isPointInside(p))
        {
          return vertex;
        }
      }
      return null;
    }

    private Transition getTransitionByPoint(Point p)
    {
      foreach (Transition transition in _transitions)
      {
        if (transition.isPointInside(p))
        {
          return transition;
        }
      }
      return null;
    }

    private void btnCreatePTNet_Click(object sender, EventArgs e)
    {

    }

    private void radBtnHorizontal_CheckedChanged(object sender, EventArgs e)
    {
      _isVerticalTransition = !radBtnHorizontal.Checked;
    }
  }
}
