using System;
using System.Runtime.CompilerServices;
using TicketingSystem.Core.Controllers;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Services;

public interface ITicketService
{
    void SubscribeToTicketEvents(TicketHub hub);
    Task RespondToTicketEvent(Ticket ticket, string eventType);
}
