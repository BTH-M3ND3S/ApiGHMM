using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class FabricanteMap : IEntityTypeConfiguration<FabricanteModel>
    {
        public void Configure(EntityTypeBuilder<FabricanteModel> builder)
        {
            builder.HasKey(x => x.FabricanteId);
            builder.Property(x => x.FabricanteNome).IsRequired().HasMaxLength(255);
        }
    }
}
