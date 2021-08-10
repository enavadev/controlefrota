using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Entities;

namespace Veiculos.Domain.Interfaces.Services
{
    public interface IVeiculoService : Base.IBaseService<Domain.Entities.Veiculo>
    {
        Task<bool> AdicionarVeiculo(Veiculo Dados);
    }
}
