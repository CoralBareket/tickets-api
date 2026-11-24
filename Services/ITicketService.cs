using TicketsApi.DTOs;

namespace TicketsApi.Services;

public interface ITicketService
{
    Task<List<TicketDto>> GetAllAsync(TicketFilterDto filter);

    Task<TicketDto?> GetByIdAsync(int id);

    Task<TicketDto> CreateAsync(CreateTicketDto dto);

    Task<TicketDto?> UpdateStatusAsync(int id, UpdateTicketStatusDto dto);

    Task<bool> DeleteAsync(int id);
}