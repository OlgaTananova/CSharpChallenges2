using System;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Events;
public class TicketCreatedArg : EventArgs
{
    public Ticket Ticket { get; }

    public DateTime MessageTime { get; }

    public TicketCreatedArg(Ticket ticket, DateTime messageTime)
    {
        Ticket = ticket;
        MessageTime = messageTime;
    }
}

