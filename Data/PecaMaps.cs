using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class PecaMap : IEntityTypeConfiguration<PecaModel>
    {
        public void Configure(EntityTypeBuilder<PecaModel> builder)
        {
            builder.HasKey(x => x.PecaId);
            builder.Property(x => x.PecaNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.QuantidadeEstoque).IsRequired();
            builder.Property(x => x.FornecedorId).IsRequired();
            builder.Property(x => x.CategoriaPecaId).IsRequired();
        }
    }
}
