using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorModel>
    {
        public void Configure(EntityTypeBuilder<FornecedorModel> builder)
        {
            builder.HasKey(x => x.FornecedorId);
            builder.Property(x => x.FornecedorNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FornecedorCnpj).IsRequired().HasMaxLength(255);
        }
    }
}
