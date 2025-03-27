using System;

namespace TicketingSystem.Core.Tickets;

public abstract class Ticket
{
    public required string Id { get; set; }

    public required string Client { get; set; }

    public required string Description { get; set; }

    public Status TicketStatus { get; set; } = Status.Created;

    public DateTime CreatedAd { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string? Update { get; set; }

    public string? Result { get; set; }

}


public enum Status
{
    Created = 1,
    Processing = 2,
    Closed = 3
}