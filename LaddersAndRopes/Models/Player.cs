using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndRopes.Models
{
  public class Player
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Color Color { get; private set; }
    public Player()
    {
      var random = new Random();
      Color = Color.FromArgb(random.Next(0, 255) , random.Next(0, 255) , random.Next(0, 255));
    }
  }
}
