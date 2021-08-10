using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.Entities.IOC
{
    public class ResultadoRequest<TEntity> where TEntity : class
    {
        public TEntity Dados { get; set; }
        public IEnumerable<TEntity> ListDados { get; set; }
        public bool Sucesso { get; set; }
        public string Menssagem { get; set; }

        public ResultadoRequest()
        {
            this.ListDados = new List<TEntity>();
            Sucesso = true;
        }
    }
}
