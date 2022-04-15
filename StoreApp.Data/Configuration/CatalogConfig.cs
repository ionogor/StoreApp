using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Configuration
{
    public class CatalogConfig : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasKey(x => x.Id);
           // builder.HasMany(x => x.Products).WithOne(x => x.Catalog).HasForeignKey(x => x.Id);
        }
    }
}
