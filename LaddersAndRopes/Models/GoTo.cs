using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LaddersAndRopes.Models
{
  public abstract class GoTo
  {
    public int ToStepNumber { get; set; }
    public string Image { get; protected set; }
  }
}
