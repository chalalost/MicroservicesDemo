﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatSignalRR.Models.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(s => s.Admin)
                .WithMany(u => u.Rooms)
                .IsRequired();
        }
    }
}
