using LaddersAndRopes.Commands;
using LaddersAndRopes.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaddersAndRopes.ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
    private ObservableCollection<Stage> stages;

    public ObservableCollection<Stage> Stages
    {
      get { return stages; }
      set { stages = value; OnPropertyChanged(nameof(Stages)); }
    }

    public ObservableCollection<GoTo> GoTosCategories { get; set; } = new ObservableCollection<GoTo>
    {
      new Ladder (),
      new Snake()
    };

    private GoTo newGoTo;

    public GoTo NewGoTo
    {
      get { return newGoTo; }
      set { newGoTo = value; OnPropertyChanged(nameof(NewGoTo)); }
    }
    private int newStepForGoTo;

    public int NewStepForGoTo
    {
      get { return newStepForGoTo; }
      set { newStepForGoTo = value; OnPropertyChanged(nameof(NewStepForGoTo)); }
    }
    private int newGoToStepForGoTo;

    public int NewGoToStepForGoTo
    {
      get { return newGoToStepForGoTo; }
      set { newGoToStepForGoTo = value; OnPropertyChanged(nameof(NewGoToStepForGoTo)); }
    }
    public RelayCommand AddPlayer { get; set; }
    public RelayCommand Next { get; set; }
    public RelayCommand StartGame { get; set; }
    public RelayCommand AddGoTo { get; set; }
    public RelayCommand SetAutoLadderAndSnake { get; set; }
    private string newNamePlayer;

    public string NewNamePlayer
    {
      get { return newNamePlayer; }
      set { newNamePlayer = value; OnPropertyChanged(nameof(NewNamePlayer)); }
    }
    private int fateNumber;

    public int FateNumber
    {
      get { return fateNumber; }
      set { fateNumber = value; OnPropertyChanged(nameof(fateNumber)); }
    }

    int numPlayer = 1;
    int playerTurn = 1;
    public MainViewModel()
    {

      Start(null);
      StartGame = new RelayCommand(Start);
      AddPlayer = new RelayCommand(AddPlayerClick);
      Next = new RelayCommand(NextClick);
      AddGoTo = new RelayCommand(AddGoToClick);
      SetAutoLadderAndSnake = new RelayCommand(SetAutoLadderAnSnakeClick);
    }

    private void SetAutoLadderAnSnakeClick(object obj)
    {
      // add ladder and snake
      Stages[4].GoTo = new Ladder { ToStepNumber = 10 };
      Stages[9].GoTo = new Ladder { ToStepNumber = 13 };
      Stages[20].GoTo = new Ladder { ToStepNumber = 51 };
      Stages[60].GoTo = new Ladder { ToStepNumber = 17 };
      Stages[80].GoTo = new Ladder { ToStepNumber = 60 };

      Stages[23].GoTo = new Snake { ToStepNumber = 2 };
      Stages[55].GoTo = new Snake { ToStepNumber = 6 };
      Stages[78].GoTo = new Snake { ToStepNumber = 35 };
      Stages[95].GoTo = new Snake { ToStepNumber = 48 };
      Stages[46].GoTo = new Snake { ToStepNumber = 8 };
    }

    private void AddGoToClick(object obj)
    {
      Stages[NewStepForGoTo].GoTo = NewGoTo is Ladder ? new Ladder() { ToStepNumber = NewGoToStepForGoTo}  : new Snake() { ToStepNumber = NewGoToStepForGoTo };
      NewStepForGoTo = 0;
      NewGoToStepForGoTo = 0;
    }

    private void Start(object obj)
    {
      Stages = new ObservableCollection<Stage>();
      for (int i = 1; i <= 100; i++)
      {
        var stage = new Stage
        {
          StepNumber = i,
          Players = new ObservableCollection<Player>()
        };
        Stages.Add(stage);
      }

     

      Stages[73].GoTo = new Gold();
      Stages[27].GoTo = new Gold();

      numPlayer = 1;
      playerTurn = 1;
    }

    private void NextClick(object obj)
    {
      var random = new Random();
      foreach (var item in Stages)
      {
        var p = item.Players.FirstOrDefault(_ => _.Id == playerTurn);
        if (p != null)
        {
          FateNumber = random.Next(1, 12);
          var s = item.StepNumber + FateNumber;
          s--;
          if (s >= 99)
          {
            // cureent player winer
            Start(null);
            return;
          }
          Stages[s].Players.Add(p);
          Stages[item.StepNumber - 1].Players.Remove(p);
          if (Stages[s].GoTo != null)
          {
            if (numPlayer > 2)
              if (Stages[s].GoTo is Gold)
              {
                var stage = Stages.LastOrDefault(_ => _.Players.Count >= 1 && _.Players.All(c => c != p));
                if (stage != null && stage.StepNumber > item.StepNumber)
                {
                  var theleadingActor = stage.Players[0];
                  item.Players.Add(theleadingActor);
                  stage.Players.Add(p);
                  stage.Players.Remove(theleadingActor);
                }
                break;
              }

            Stages[Stages[s].GoTo.ToStepNumber].Players.Add(p);
            Stages[s].Players.Remove(p);
          }

          break;
        }
      }
      if (playerTurn + 1 == numPlayer)
      {
        playerTurn = 1;
      }
      else
      {
        playerTurn++;
      }
    }

    private void AddPlayerClick(object obj)
    {
      if (!string.IsNullOrEmpty(NewNamePlayer))
      {
        var player = new Player()
        {
          Name = NewNamePlayer,
          Id = numPlayer
        };
        Stages[0].Players.Add(player);
        numPlayer++;
        NewNamePlayer = "";
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string nameProperty)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
  }
}
