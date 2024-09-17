using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class CategoriaPecaMap : IEntityTypeConfiguration<CategoriaPecaModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaPecaModel> builder)
        {
            builder.HasKey(x => x.CategoriaPecaId);
            builder.Property(x => x.CategoriaPecaNome).IsRequired().HasMaxLength(255);
        }
    }
}
