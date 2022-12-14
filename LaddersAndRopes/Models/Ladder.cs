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
      var s = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
      Image = new BitmapImage(new Uri(s.Split("LaddersAndRopes")[0] + @"LaddersAndRopes\LaddersAndRopes\Assets\Ladder.jpg"));
    }
    public override string ToString()
    {
      return $"Up to {ToStepNumber}";
    }
  }
}
