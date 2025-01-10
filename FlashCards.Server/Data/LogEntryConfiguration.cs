using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FlashCards.Server.Models.Data;

namespace FlashCards.Server.Data
{
    public class LogEntryConfiguration : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Exception)
                .IsRequired(false);

            builder.Property(p => p.Properties)
                .IsRequired(false);

            builder.Property(p => p.LogEvent)
                .IsRequired(false);

            builder.Property(p => p.TimeStamp)
                .HasColumnType("datetime");

            builder.Property(p => p.Level)
                .HasMaxLength(16);
        }
    }
}
