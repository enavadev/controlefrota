using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Entities;

namespace Veiculos.Data.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo)
                .HasMaxLength(99)
                .IsRequired();

            builder.Property(x => x.Placa)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Chassi)
                .IsRequired();

            builder.Property(x => x.Cor)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Passageiros)
                .IsRequired()
                .HasDefaultValueSql("2");
        }
    }
}
