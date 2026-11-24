using Microsoft.EntityFrameworkCore;
using TicketsApi.Enums;
using TicketsApi.Models;

namespace TicketsApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(t => t.Priority)
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.Property(t => t.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.Property(t => t.CreatedAt)
                .IsRequired();

            entity.HasIndex(t => t.Status);
            entity.HasIndex(t => t.Priority);

            // Seed data
            entity.HasData(
                new Ticket
                {
                    Id = 1,
                    Title = "Unable to log in",
                    Description = "User receives an error when attempting to sign in.",
                    Priority = TicketPriority.High,
                    Status = TicketStatus.Open,
                    CreatedAt = new DateTime(2026, 11, 20, 9, 0, 0, DateTimeKind.Utc)
                },
                new Ticket
                {
                    Id = 2,
                    Title = "Dashboard loading slowly",
                    Description = "The dashboard takes several seconds to display data.",
                    Priority = TicketPriority.Medium,
                    Status = TicketStatus.InProgress,
                    CreatedAt = new DateTime(2026, 11, 21, 10, 30, 0, DateTimeKind.Utc)
                },
                new Ticket
                {
                    Id = 3,
                    Title = "Incorrect profile image",
                    Description = "The profile image was not updated after uploading a new one.",
                    Priority = TicketPriority.Low,
                    Status = TicketStatus.Closed,
                    CreatedAt = new DateTime(2026, 11, 22, 14, 0, 0, DateTimeKind.Utc)
                }
            );
        });
    }
}