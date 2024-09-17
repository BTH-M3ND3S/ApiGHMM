using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class RelatorioMap : IEntityTypeConfiguration<RelatorioModel>
    {
        public void Configure(EntityTypeBuilder<RelatorioModel> builder)
        {
            builder.HasKey(x => x.RelatorioId);
            builder.Property(x => x.RelatorioConteudo).IsRequired();
            builder.Property(x => x.FuncionarioId).IsRequired();
        }
    }
}
