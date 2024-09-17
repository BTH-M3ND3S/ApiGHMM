using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGHMM.Data
{
    public class SetorMap : IEntityTypeConfiguration<SetorModel>
    {
        public void Configure(EntityTypeBuilder<SetorModel> builder)
        {
            builder.HasKey(x => x.SetorId);
            builder.Property(x => x.SetorNome).IsRequired().HasMaxLength(255);
        }
    }
}
