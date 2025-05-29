using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.DTOS.Output;

public class CaixasOutputDTO
{
    public string? caixa_id { get; set; } = string.Empty;
    public List<ProdutosOutputDTO> produtos { get; set; }
}
