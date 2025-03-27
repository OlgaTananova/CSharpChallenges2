using System;
using System.Threading.Tasks;
using TicketingSystem.Core.Events;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Controllers;

public class TicketHub
{

    public delegate Task AsyncEventHandler<TEventAgr>(object? sender, TEventAgr e);
    public event AsyncEventHandler<TicketCreatedArg>? TicketCreated;
    public event AsyncEventHandler<TicketUpdatedArg>? TicketUpdated;

    public event AsyncEventHandler<TicketClosedArg>? TicketClosed;


    public async Task SendTicketCreatedCommand(Ticket ticket)
    {
        if (TicketCreated != null)
        {
            await TicketCreated(this, new TicketCreatedArg(ticket, DateTime.Now));
        }
    }

    public async Task SendTicketUpdatedCommand(Ticket ticket)
    {
        if (TicketUpdated != null)
        {
            await TicketUpdated(this, new TicketUpdatedArg(ticket, DateTime.Now));
        }
    }

    public async Task SendTicketClosedCommand(Ticket ticket)
    {
        if (TicketClosed != null)
        {
            await TicketClosed(this, new TicketClosedArg(ticket, DateTime.Now));
        }
    }
}
