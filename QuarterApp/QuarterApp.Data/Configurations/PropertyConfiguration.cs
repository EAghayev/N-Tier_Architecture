using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuarterApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.FileName).HasMaxLength(100);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.WeeklyPrice).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.MonthlyPrice).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.DailyPrice).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.HasOne(x => x.Category).WithMany(x => x.Properties).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
