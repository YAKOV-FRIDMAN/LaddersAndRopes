using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndRopes.Models
{
  public class Stage : INotifyPropertyChanged
  {
    public int StepNumber { get; set; }
    public ObservableCollection<Player> Players { get; set; }
    private GoTo goTo;

    public GoTo GoTo
    {
      get { return goTo; }
      set { goTo = value; OnPropertyChanged(nameof(GoTo)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string nameProperty)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
  }
}
