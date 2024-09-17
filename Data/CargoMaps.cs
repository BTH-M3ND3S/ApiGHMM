using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGHMM.Data
{
    public class CargoMap : IEntityTypeConfiguration<CargoModel>
    {
        public void Configure(EntityTypeBuilder<CargoModel> builder)
        {
            builder.HasKey(x => x.CargoId);
            builder.Property(x => x.CargoNome).IsRequired().HasMaxLength(255);
        }
    }
}
