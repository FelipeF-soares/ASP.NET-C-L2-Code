﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.DTOS.Output;

public class OutputDTO
{
    public List<PedidosOutputDTO> pedidos { get; set; }
}
