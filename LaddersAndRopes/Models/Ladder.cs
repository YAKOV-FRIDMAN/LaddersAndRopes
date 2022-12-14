using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LaddersAndRopes.Models
{
  public class Ladder : GoTo
  {
    public Ladder()
    {
      Image = "/Assets/Ladder.jpg";
    }
    public override string ToString()
    {
      return $"Up to {ToStepNumber}";
    }
  }
}
