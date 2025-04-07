using System;
using TicketingSystem.Core.Controllers;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Services;

public class AnalyticService : ITicketService
{
    public async Task RespondToTicketEvent(Ticket ticket, string eventType)
    {
        await Task.Delay(1000);
        Console.WriteLine($"Analyzing ticket {ticket.Id} {eventType}");
    }

    public void SubscribeToTicketEvents(TicketHub hub)
    {
        hub.TicketClosed += async (sender, e) =>
        {
            await RespondToTicketEvent(e.Ticket, "closed");
        };
    }
}
