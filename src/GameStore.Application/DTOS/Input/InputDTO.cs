using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.DTOS.Input;

public class InputDTO
{
    public List<PedidosInputDTO> pedidos { get; set; }
}
