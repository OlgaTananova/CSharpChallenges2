using System;
using TicketingSystem.Core.Controllers;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Services;

public class NotificationService : ITicketService
{
    public virtual async Task RespondToTicketEvent(Ticket ticket, string eventType)
    {
        Console.WriteLine($"Sending email about ticket {ticket.Id} {eventType}");
        await Task.Delay(2000);
        Console.WriteLine($"Email about ticket {ticket.Id} {eventType} was sent.");

    }

    public void SubscribeToTicketEvents(TicketHub hub)
    {
        hub.TicketCreated += async (sender, e) =>
        {
            await RespondToTicketEvent(e.Ticket, "created");
        };

        hub.TicketUpdated += async (sender, e) =>
        {
            await RespondToTicketEvent(e.Ticket, "updated");
        };

        hub.TicketClosed += async (sender, e) =>
        {
            await RespondToTicketEvent(e.Ticket, "closed");
        };
    }

}
