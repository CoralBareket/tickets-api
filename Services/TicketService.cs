using Microsoft.EntityFrameworkCore;
using TicketsApi.Data;
using TicketsApi.DTOs;
using TicketsApi.Enums;
using TicketsApi.Mappings;
using TicketsApi.Models;

namespace TicketsApi.Services;

public class TicketService : ITicketService
{
    private readonly AppDbContext _context;

    public TicketService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TicketDto>> GetAllAsync(TicketFilterDto filter)
    {
        IQueryable<Ticket> query = _context.Tickets.AsNoTracking();

        if (filter.Status.HasValue)
        {
            query = query.Where(t => t.Status == filter.Status.Value);
        }

        if (filter.Priority.HasValue)
        {
            query = query.Where(t => t.Priority == filter.Priority.Value);
        }

        var tickets = await query
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

        return tickets.Select(t => t.ToDto()).ToList();
    }

    public async Task<TicketDto?> GetByIdAsync(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        return ticket?.ToDto();
    }

    public async Task<TicketDto> CreateAsync(CreateTicketDto dto)
    {
        var ticket = new Ticket
        {
            Title = dto.Title.Trim(),
            Description = dto.Description.Trim(),
            Priority = dto.Priority!.Value,
            Status = TicketStatus.Open,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return ticket.ToDto();
    }

    public async Task<TicketDto?> UpdateStatusAsync(
        int id, UpdateTicketStatusDto dto)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket is null)
        {
            return null;
        }

        ticket.Status = dto.Status!.Value;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return null;
        }

        return ticket.ToDto();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket is null)
        {
            return false;
        }

        _context.Tickets.Remove(ticket);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }

        return true;
    }
}