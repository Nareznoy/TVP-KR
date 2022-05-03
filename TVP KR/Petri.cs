using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri_net
{
  class PetriNet
  {
    List<Position> positions = new List<Position>();
    List<Transition> transitions = new List<Transition>();
    RandomTransition randomTransition;
    int lastTick = 0;

    public Graphics Graphics { get; set; }

    public PetriNet(List<Position> positions, List<Transition> transitions, RandomTransition randomTransition)
    {
      foreach (var position in positions)
        this.positions.Add(position);
      foreach (var transition in transitions)
        this.transitions.Add(transition);
      this.randomTransition = randomTransition;
    }
    void Render()
    {
      foreach (var position in positions)
      {
        using (Font colibriFont = new Font("Colibri", 25))
        using (SolidBrush whiteBrush = new SolidBrush(Color.White))
        using (SolidBrush blackBrush = new SolidBrush(Color.Black))
        {
          Graphics.FillRectangle(whiteBrush, new Rectangle(position.Bounds.X - 5, position.Bounds.Y - 5, position.Bounds.Width + 8, position.Bounds.Height + 7));
          Graphics.DrawString(position.ToString(), colibriFont, blackBrush, new PointF(position.Bounds.X - 9, position.Bounds.Y - 10));
        }
      }
    }

    public string DoTick()
    {
      for (int i = lastTick; ; i++)
      {
        if (randomTransition.MakeTransition())
        {
          Render();
          return randomTransition.ToString();
        }

        var transition = transitions[i];
        if (transition.CanMakeTransition)
        {
          transition.MakeTransition();
          Render();
          lastTick = i;
          return transition.ToString();
        }
        if (i == transitions.Count - 1)
          i = -1;
      }
    }

    public override string ToString() => "(" + string.Join(", ", positions.Select(position => position.ToString())) + ")";
  }

  public class Position
  {
    //List<Transition> inputTransitions;
    //List<Transition> outputTransitions;
    Rectangle bounds;
    string name;

    protected int markerCount;

    public Rectangle Bounds => bounds;
    public virtual int MarkerCount
    {
      get => markerCount;
      set => markerCount = value;
    }
    public virtual bool HasMarkers => MarkerCount > 0;

    public Position(string name, Rectangle bounds, int markerCount = 0)
    {
      this.name = name;
      this.bounds = bounds;
      this.markerCount = markerCount;
    }

    public override string ToString() => markerCount.ToString();
  }
  public class EndlessPosition : Position
  {
    public override int MarkerCount
    {
      get => 1;
      set { }
    }
    public override bool HasMarkers => true;

    public EndlessPosition(string name, Rectangle bounds) : base(name, bounds, int.MaxValue) { }

    public override string ToString() => "M";
  }

  public class Transition
  {
    protected List<Position> inputPositions;
    protected List<Position> outputPositions;

    public List<Position> InputPositions
    {
      get
      {
        if (inputPositions == null)
          inputPositions = new List<Position>();
        return inputPositions;
      }
      set => inputPositions = value;
    }
    public List<Position> OutputPositions
    {
      get
      {
        if (outputPositions == null)
          outputPositions = new List<Position>();
        return outputPositions;
      }
      set => outputPositions = value;
    }
    public bool CanMakeTransition
    {
      get
      {
        foreach (var inputPoisiton in inputPositions)
          if (!inputPoisiton.HasMarkers)
            return false;
        return true;
      }
    }
    public string Name { get; set; }

    public virtual bool MakeTransition()
    {
      if (!CanMakeTransition)
        return false;
      foreach (var inputPoisiton in inputPositions)
        inputPoisiton.MarkerCount--;
      foreach (var outputPosition in outputPositions)
        outputPosition.MarkerCount++;
      return true;
    }

    public override string ToString() => Name;
  }
  public class RandomTransition : Transition
  {
    Random random = new Random(0);
    int ticksBeforeTransition = 0;

    void RandomizeTicksBeforeTransition() => ticksBeforeTransition = random.Next(4, 7);

    public override bool MakeTransition()
    {
      if (ticksBeforeTransition == 0)
      {
        base.MakeTransition();
        RandomizeTicksBeforeTransition();
        return true;
      }
      else
        ticksBeforeTransition--;
      return false;
    }
  }
}
