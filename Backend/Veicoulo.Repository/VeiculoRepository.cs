using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Data.Context;
using Veiculos.Domain.Interfaces.Repositories;

namespace Veicoulo.Repository
{
    public class VeiculoRepository : Base.RepositoryBase<Veiculos.Domain.Entities.Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(BaseContext context) : base(context)
        {
        }
    }
}
