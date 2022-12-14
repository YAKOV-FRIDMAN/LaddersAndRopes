using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LaddersAndRopes.Models
{
  public class Gold : GoTo
  {
    public Gold()
    {
      Image = "/Assets/gold.png";
    }
    public override string ToString()
    {
      return $"Switch places \n with the  \n leading player"; 
    }
  }
}
