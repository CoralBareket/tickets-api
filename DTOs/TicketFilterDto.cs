using System.ComponentModel.DataAnnotations;
using TicketsApi.Enums;

namespace TicketsApi.DTOs;

public class TicketFilterDto
{
    [EnumDataType(typeof(TicketStatus))]
    public TicketStatus? Status { get; set; }

    [EnumDataType(typeof(TicketPriority))]
    public TicketPriority? Priority { get; set; }
}