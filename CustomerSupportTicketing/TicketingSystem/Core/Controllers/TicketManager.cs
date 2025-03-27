using System;
using System.Collections;
using System.Threading.Tasks;
using TicketingSystem.Core.Tickets;

namespace TicketingSystem.Core.Controllers;

// Creates, updates, closes tickets by invoking hub
public class TicketManager
{
    public List<Ticket> tickets { get; set; } = new List<Ticket>();

    private readonly TicketHub _ticketHub;

    public TicketManager(TicketHub ticketHub)
    {
        _ticketHub = ticketHub;
    }

    public async Task<Ticket?> CreateTicket(string id, string customer, string description, string type, string? bugCode)
    {
        Ticket? ticket = null;
        switch (type)
        {
            case "Bug":
                ticket = new BugReport
                {
                    Id = id,
                    Client = customer,
                    Description = description,
                    CreatedAd = DateTime.Now,
                    BugCode = bugCode ?? "500"
                };
                break;
            case "Feature":
                ticket = new FeatureRequest
                {
                    Id = id,
                    Client = customer,
                    CreatedAd = DateTime.Now,
                    Description = description,
                };
                break;

            case "General":
                ticket = new GeneralEnquiry
                {
                    Id = id,
                    Client = customer,
                    CreatedAd = DateTime.Now,
                    Description = description,
                };
                break;
            default:
                // Handle unknown type
                Console.WriteLine("Unknown ticket type, please specify the ticket type");
                break;
        }

        if (ticket != null)
        {
            tickets.Add(ticket);
            await _ticketHub.SendTicketCreatedCommand(ticket);
        }
        return ticket;
    }

    public async Task UpdateTicket(string ticketId, string update)
    {
        var updatedTicket = tickets.FirstOrDefault(t => t.Id == ticketId);
        if (updatedTicket is null)
        {
            Console.WriteLine("The requested ticket is not found and cannot be updated.");
            return;
        }

        updatedTicket.Update = update;
        updatedTicket.UpdatedAt = DateTime.Now;
        updatedTicket.TicketStatus = Status.Processing;
        await _ticketHub.SendTicketUpdatedCommand(updatedTicket);
    }

    public async Task CloseTicket(string ticketId, string result)
    {
        var closingTicket = tickets.FirstOrDefault(t => t.Id == ticketId);
        if (closingTicket is null)
        {
            Console.WriteLine("The requested ticket is not found and cannot be closed.");
            return;
        }

        closingTicket.Result = result;
        closingTicket.TicketStatus = Status.Closed;
        await _ticketHub.SendTicketClosedCommand(closingTicket);
    }

}
