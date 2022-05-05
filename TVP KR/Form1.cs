using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_KR
{
  public enum DrawMode
  {
    AddVertex,
    RemoveVertex,
    AddTransition,
    RemoveTransition,
    AddPosition,
    RemovePosition,
    AddEdge,
    None
  }

  public partial class Form1 : Form
  {
    List<Tuple<String, String, String>> graphVizVerticesByVerticesByTransIndex = new List<Tuple<string, string, string>>();

    private const String SERIALIZIBLE_FILE_NAME = "SeverinGraph.dat";

    private DrawMode currentDrawMode = DrawMode.None;
    private bool _isVerticalTransition = false;

    Graphics img;
    private int _vertexCount = 0;
    private int _transitionCount = 0;

    //private List<Vertex> _vertices = new List<Vertex>();
    //private List<Transition> _transitions = new List<Transition>();
    private PetriNet ptNet;

    private Vertex _firstSelectedVertex;
    private Vertex _secondSelectedVertex;
    private Transition _selectedTransition;

    public Form1()
    {
      InitializeComponent();
      img = pictureBoxPetriNet.CreateGraphics();

      ptNet = new PetriNet();
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
        case DrawMode.RemoveTransition:
          btnRemoveTransition.Enabled = false;
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
          case DrawMode.RemoveTransition:
            btnRemoveTransition.Enabled = true;
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
            btnAddVertex.Enabled = true;
            btnRemoveVertex.Enabled = true;
            btnAddTransition.Enabled = true;
            btnRemoveTransition.Enabled = true;
            btnAddPosition.Enabled = true;
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

    private void btnRemoveTransition_Click(object sender, EventArgs e)
    {
      switchDrawMode(DrawMode.RemoveTransition);
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
      Stack<PetriNet> stack = new Stack<PetriNet>();
      stack.Push(ptNet);

      int i = 0;
      while (i < 4)
      {
        PetriNet petriNet = new PetriNet(stack.Pop());
        List<int> possibleTransitionsIndexes = new List<int>();

        for (int j = 0; j < petriNet.transitions.Count; j++)
        {
          if (petriNet.transitions[j].isTransitionPossible())
          {
            possibleTransitionsIndexes.Add(j);
          }
        }

        foreach (int possibleTransitionIndex in possibleTransitionsIndexes)
        {
          PetriNet tempPT = new PetriNet(petriNet);
          tempPT.doTransitionByIndex(possibleTransitionIndex);
          graphVizVerticesByVerticesByTransIndex.Add(new Tuple<string, string, string>(petriNet.ToString(), tempPT.ToString(), possibleTransitionIndex.ToString()));
          stack.Push(tempPT);
        }

        i++;
      }

      String format = @"{0}->{1}[label=""{2}""];";
      StringBuilder ReacheabilityGraphString = new StringBuilder();
      foreach (Tuple<String, String, String> transitionInfo in graphVizVerticesByVerticesByTransIndex)
      {
        ReacheabilityGraphString.Append(String.Format(format
          , transitionInfo.Item1
          , transitionInfo.Item2
          , transitionInfo.Item3));
      }

      ReacheabilityGraphString.Append('}');

      String GraphVizPrefixString = @"digraph g {ratio = fill; node[style = filled] label = ""Andre van Dun "";";
      //String ReacheabilityGraphString = @"
      //      InitialInitial->AwaitingAnalysis[label =""manual""];
      //      AwaitingAnalysis->AwaitingDevelopment[label =""manual""];
      //      AwaitingDevelopment->InDevelopment[label =""manual""];
      //      AwaitingDevelopment->AwaitingDelivery[label =""manual""];
      //      InDevelopment->AwaitingDelivery[label =""manual""];}";

      String GraphVizBuildString = GraphVizPrefixString + ReacheabilityGraphString.ToString();



      pictureBoxPetriNet.Image = GraphVizDraw.Graphviz.RenderImage(GraphVizBuildString, "jpg");
    }

    private void pictureBoxPetriNet_MouseClick(object sender, MouseEventArgs e)
    {
      switch (currentDrawMode)
      {
        case DrawMode.AddVertex:
          Vertex newVertex = new Vertex(e.Location, ++_vertexCount);
          //_vertices.Add(newVertex);
          //newVertex.drawVertex(img);
          ptNet.addVertex(newVertex);
          ptNet.drawPetriNet(img);
          break;
        case DrawMode.RemoveVertex:
          Vertex vertexToRemove = ptNet.getVertexByPoint(e.Location);
          ptNet.removeVertex(vertexToRemove);
          ptNet.drawPetriNet(img);
          break;
        case DrawMode.AddTransition:
          Transition newTransition = new Transition(e.Location, ++_transitionCount);
          //_transitions.Add(newTransition);
          newTransition.isVertical = _isVerticalTransition;
          //newTransition.drawTransition(img);
          ptNet.addTransition(newTransition);
          ptNet.drawPetriNet(img);
          break;
        case DrawMode.RemoveTransition:
          Transition transitionToRemove = ptNet.getTransitionByPoint(e.Location);
          ptNet.removeTransition(transitionToRemove);
          ptNet.drawPetriNet(img);
          break;
        case DrawMode.AddPosition:
          Vertex vertexToAddPositions = ptNet.getVertexByPoint(e.Location);
          if (vertexToAddPositions != null)
          {
            vertexToAddPositions.addPosition();
            reDrawPTNet();
          }
          break;
        case DrawMode.RemovePosition:

          break;
        case DrawMode.AddEdge:
          if (_firstSelectedVertex == null)
          {
            Vertex currentSelectedVertex = ptNet.getVertexByPoint(e.Location);
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
            Transition currentSelectedTransition = ptNet.getTransitionByPoint(e.Location);
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
            Vertex currentSelectedVertex = ptNet.getVertexByPoint(e.Location);
            if (currentSelectedVertex == null)
            {
              lblTransitionInfo.Text = "Select second vertex";
            }
            else
            {
              _secondSelectedVertex = currentSelectedVertex;

              _selectedTransition.addEdge(_firstSelectedVertex, _secondSelectedVertex);
              //_selectedTransition.drawTransition(img);
              reDrawPTNet();

              _firstSelectedVertex = null;
              _secondSelectedVertex = null;
              _selectedTransition = null;
              return;
            }
          }
          break;
      }
    }

    private void reDrawPTNet()
    {
      img = pictureBoxPetriNet.CreateGraphics();
      img.Clear(Color.White);

      //ptNet = new PetriNet(_vertices, _transitions);
      ptNet.drawPetriNet(img);
    }

    private void radBtnHorizontal_CheckedChanged(object sender, EventArgs e)
    {
      _isVerticalTransition = !radBtnHorizontal.Checked;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      reDrawPTNet();
    }

    private void btnSimulate_Click(object sender, EventArgs e)
    {
      if (ptNet == null)
      {
        return;
      }

      while (true)
      {
        int acitveTransition = ptNet.doStep();
        reDrawPTNet();
        ptNet.transitions[acitveTransition].drawTransition(img, true);

        Thread.Sleep(500);
      }
    }

    private void btnDoStep_Click(object sender, EventArgs e)
    {
      String oldNetState = ptNet.ToString();
      int acitveTransition = ptNet.doStep();
      String newNetState = ptNet.ToString();

      

      graphVizVerticesByVerticesByTransIndex.Add(new Tuple<string, string, string>(oldNetState, newNetState, acitveTransition.ToString()));

      reDrawPTNet();
      ptNet.transitions[acitveTransition].drawTransition(img, true);
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      // создаем объект BinaryFormatter
      BinaryFormatter formatter = new BinaryFormatter();
      // получаем поток, куда будем записывать сериализованный объект
      using (FileStream fs = new FileStream(SERIALIZIBLE_FILE_NAME, FileMode.OpenOrCreate))
      {
        formatter.Serialize(fs, ptNet);
      }
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      // создаем объект BinaryFormatter
      BinaryFormatter formatter = new BinaryFormatter();
      // десериализация из файла people.dat
      using (FileStream fs = new FileStream(SERIALIZIBLE_FILE_NAME, FileMode.OpenOrCreate))
      {
        ptNet = (PetriNet)formatter.Deserialize(fs);
        reDrawPTNet();
      }
    }
  }
}