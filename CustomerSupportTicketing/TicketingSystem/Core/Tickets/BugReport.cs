using System;

namespace TicketingSystem.Core.Tickets;

public class BugReport : Ticket
{
    public required string BugCode { get; set; }
}
