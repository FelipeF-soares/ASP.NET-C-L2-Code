using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain;

public class Order
{
    public int Id { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public Box BoxId { get; set; }
}
