using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndRopes.Models
{
  public class Stage
  {
    public int StepNumber { get; set; }
    public ObservableCollection<Player> Players { get; set; }
    public GoTo GoTo { get; set; }
  }
}
