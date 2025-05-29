using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain;

public class Box 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Dimensions? Dimensions { get; set; }
}
