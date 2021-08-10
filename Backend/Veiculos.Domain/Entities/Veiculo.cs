using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.Entities
{
    public partial class Veiculo
    {
        private byte _passageiros;
        public int Id { get; set; }
        [Required(ErrorMessage = "O Tipo do veículo é obrigatório.")]
        public byte Tipo { get; set; } // 1 - Caminão | 2 - Ônibos | N>2 - Outro
        [Required(ErrorMessage = "A Placa do veículo é obrigatório.")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O Número do Chassí é obrigatório.")]
        public string Chassi { get; set; }
        [Required(ErrorMessage = "A Cor do veículo é obrigatório.")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O Número de Passageiros do veículo é obrigatório.")]
        public byte Passageiros
        {
            get => (byte)(Tipo == 1 ? 2 : (Tipo == 2 ? 42 : _passageiros));
            set => _passageiros = value;
        }
    }
}
