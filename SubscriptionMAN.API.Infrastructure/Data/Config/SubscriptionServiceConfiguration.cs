using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionMAN.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Data.Config;
public class SubscriptionServiceConfiguration : IEntityTypeConfiguration<SubscriptionService>
{
    public void Configure(EntityTypeBuilder<SubscriptionService> builder)
    {
        // Constraint: UserName is required
        builder.Property(ss => ss.UserName)
            .IsRequired()
            .HasMaxLength(256);
    }
}
