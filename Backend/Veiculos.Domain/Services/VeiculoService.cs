using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces.Repositories;
using Veiculos.Domain.Interfaces.Services;

namespace Veiculos.Domain.Services
{
    public class VeiculoService : Base.BaseService<Domain.Entities.Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        public VeiculoService(IVeiculoRepository repository) : base(repository) => _repository = repository;
        public Task<bool> AdicionarVeiculo(Veiculo dados) => base.Adiciona(dados);

    }
}
