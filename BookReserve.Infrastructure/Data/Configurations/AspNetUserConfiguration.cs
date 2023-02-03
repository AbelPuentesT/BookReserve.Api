﻿using BookReserve.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookReserve.Infrastructure.Data.Configurations
{
    internal class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
    {
        public void Configure(EntityTypeBuilder<AspNetUser> builder)
        {
            builder.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            builder.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            builder.Property(e => e.Email).HasMaxLength(256);
            builder.Property(e => e.NormalizedEmail).HasMaxLength(256);
            builder.Property(e => e.NormalizedUserName).HasMaxLength(256);
            builder.Property(e => e.UserName).HasMaxLength(256);
            builder.Property(e => e.Reserves);
            builder.Property(e => e.Photo).HasColumnType("image");
        }
    }
}

