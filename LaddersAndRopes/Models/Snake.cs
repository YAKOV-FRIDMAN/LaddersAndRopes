using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LaddersAndRopes.Models
{
  public class Snake : GoTo
  {
    public Snake()
    {
      var s = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
      Image = new BitmapImage(new Uri(s.Split("LaddersAndRopes")[0] + @"LaddersAndRopes\LaddersAndRopes\Assets\Sanke.png"));
    }

    public override string ToString()
    {
      return $"down to {ToStepNumber}";
    }
  }
}
