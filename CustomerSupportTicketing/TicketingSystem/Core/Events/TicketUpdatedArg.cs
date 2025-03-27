using System;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Events;

public class TicketUpdatedArg : EventArgs
{

    public Ticket Ticket { get; }

    public DateTime MessageTime { get; }

    public TicketUpdatedArg(Ticket ticket, DateTime messageTime)
    {
        Ticket = ticket;
        MessageTime = messageTime;
    }

}
