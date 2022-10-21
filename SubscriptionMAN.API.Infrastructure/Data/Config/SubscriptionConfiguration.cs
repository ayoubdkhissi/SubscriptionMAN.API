using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionMAN.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Data.Config;
public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {

        // Integrity Constraint: A Subscription belongs to one subscription Service
        builder.HasOne(s => s.SubscriptionService)
            .WithMany(ss => ss.Subscriptions)
            .HasForeignKey(s => s.SubscriptionServiceId);

        // Integrity Constraint: A Subscription has one Client
        builder.HasOne(s => s.Client)
            .WithMany(Client => Client.Subscriptions)
            .HasForeignKey(s => s.ClientId);

        // Constraint: SubscriptionServiceId is required
        builder.Property(s => s.SubscriptionServiceId)
            .IsRequired();

        // Constraint: ClientId is required
        builder.Property(s => s.ClientId)
            .IsRequired();

        // Constraint: StartDate is required
        builder.Property(s => s.StartDate)
            .IsRequired();

        // Constraint: EndDate is required
        builder.Property(s => s.EndDate)
            .IsRequired();

        // Constraint: The Amount is required
        builder.Property(s => s.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

    }
}
