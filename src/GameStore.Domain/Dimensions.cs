using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain;

public abstract class Dimensions
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }
}
