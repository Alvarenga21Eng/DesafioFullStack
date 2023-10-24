using DesafioFullStack.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFullStack.Data.Map
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CNPJ);
            builder.Property(x => x.TradeName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(12);
        }
    }
}
