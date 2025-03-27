using System;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Events;

public class TicketClosedArg
{
    public Ticket Ticket { get; }

    public DateTime MessageTime { get; }

    public TicketClosedArg(Ticket ticket, DateTime messageTime)
    {
        Ticket = ticket;
        MessageTime = messageTime;
    }

}
