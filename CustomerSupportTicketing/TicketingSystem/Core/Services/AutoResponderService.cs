using System;
using TicketingSystem.Core.Controllers;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Services;

public class AutoResponderService : ITicketService
{
    public async Task RespondToTicketEvent(Ticket ticket, string eventType)
    {
        await Task.Delay(1500);
        Console.WriteLine($"Sending out a response to the ticket {ticket.Id} {eventType}");
    }

    public void SubscribeToTicketEvents(TicketHub hub)
    {
        hub.TicketCreated += async (sender, e) =>
        {

            await RespondToTicketEvent(e.Ticket, "created");
        };
    }
}
