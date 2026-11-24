using System.ComponentModel.DataAnnotations;
using TicketsApi.Enums;

namespace TicketsApi.DTOs;

public class CreateTicketDto
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [EnumDataType(typeof(TicketPriority))]
    public TicketPriority? Priority { get; set; }
}