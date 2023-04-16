﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pikia.Core.Entities.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Repository.Data.Config
{
    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(O => O.ShippingAddress, NP => NP.WithOwner());

            //builder.Property(O => O.Status)
            //    .HasConversion(
            //    OStatus => OStatus.ToString(),
            //    OStatus => (OrderStatus) Enum.Parse(typeof(OrderStatus), OStatus)
            //    );
            builder.HasMany(O => O.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Property(O => O.Total)
              .HasColumnType("decimal(18,2)");

        }
    }
}
