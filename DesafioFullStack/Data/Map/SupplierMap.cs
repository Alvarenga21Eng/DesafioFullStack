using DesafioFullStack.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFullStack.Data.Map
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.CNPJ);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(15);
            builder.Property(x => x.RG).HasMaxLength(15);
            builder.Property(x => x.Birthday).HasMaxLength(15);
        }
    }
}
