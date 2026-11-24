using System.ComponentModel.DataAnnotations;
using TicketsApi.Enums;

namespace TicketsApi.DTOs;

public class UpdateTicketStatusDto
{
    [Required]
    [EnumDataType(typeof(TicketStatus))]
    public TicketStatus? Status { get; set; }
}