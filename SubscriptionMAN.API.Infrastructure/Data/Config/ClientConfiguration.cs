using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionMAN.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Data.Config;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        // First Name is required
        builder.Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(100);

        // Email must be unique
        builder.HasIndex(c => c.Email)
            .IsUnique();

        

        // Index on Name, because a lot of search will be executed upon it
        builder.HasIndex(c => c.FullName);
    }
}
