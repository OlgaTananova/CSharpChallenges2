using TicketingSystem.Core.Controllers;
using TicketingSystem.Core.Services;

TicketHub hub = new();
TicketManager manager = new(hub);
NotificationService notificationService = new NotificationService();
notificationService.SubscribeToTicketEvents(hub);

await manager.CreateTicket("ticket-1", "customer-1", "There is a bug in the system", "Bug", "400");
await Task.Delay(1000);
await manager.UpdateTicket("ticket-1", "Ticket is updated");
await Task.Delay(500);
await manager.CloseTicket("ticket-1", "Ticket is closed");