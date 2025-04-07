using TicketingSystem.Core.Controllers;
using TicketingSystem.Core.Services;
using TicketingSystem.Core.Tickets;

namespace TicketingSystemTests;

public class TicketingSystemTests
{
    [Fact]
    public async Task NotificationService_ShouldReactToTicketCreated()
    {
        // Arrange
        TicketHub hub = new TicketHub();
        TestableNotificationService notificationService = new TestableNotificationService();
        notificationService.SubscribeToTicketEvents(hub);

        //Act

        BugReport bugreport = new BugReport()
        {
            Id = "ticket-1",
            Client = "client-1",
            Description = "There is a bug in the system",
            BugCode = "500"
        };

        await hub.SendTicketCreatedCommand(bugreport);

        Assert.True(notificationService.Triggered);
        Assert.Equal("ticket-1", notificationService.LastTicketId);
        Assert.Equal("created", notificationService.LastEventType);

    }

    [Fact]
    public async Task NotificationService_ShouldReactToTicketUpdated()
    {
        // Arrange
        TicketHub hub = new TicketHub();
        TicketManager manager = new TicketManager(hub);
        TestableNotificationService notificationService = new TestableNotificationService();
        notificationService.SubscribeToTicketEvents(hub);

        //Act
        await manager.CreateTicket("ticket-2", "client-2", "Feature upate is needed", "Feature", null);
        await manager.UpdateTicket("ticket-2", "This is an update in ticket");

        // Assert
        Assert.True(notificationService.Triggered);
        Assert.Equal("ticket-2", notificationService.LastTicketId);
        Assert.Equal("updated", notificationService.LastEventType);

    }

    [Fact]
    public async Task NotificationService_ShouldReactToTicketClosed()
    {
        // Arrange
        TicketHub hub = new TicketHub();
        TicketManager manager = new TicketManager(hub);
        TestableNotificationService notificationService = new TestableNotificationService();
        notificationService.SubscribeToTicketEvents(hub);

        //Act
        await manager.CreateTicket("ticket-3", "client-3", "This is a general enquiry", "General", null);
        await manager.CloseTicket("ticket-3", "The ticket is sucessfully resolved and closed.");

        // Assert
        Assert.True(notificationService.Triggered);
        Assert.Equal("ticket-3", notificationService.LastTicketId);
        Assert.Equal("closed", notificationService.LastEventType);

    }

    [Fact]

    public async Task TicketManager_ShouldCreateTicket()
    {
        // Arrange
        TicketHub hub = new TicketHub();
        TicketManager manager = new TicketManager(hub);
        TestableNotificationService notificationService = new TestableNotificationService();
        notificationService.SubscribeToTicketEvents(hub);

        // Act
        await manager.CreateTicket("ticket-3", "client-3", "This is a general enquiry", "General", null);

        // Assert
        Assert.Equal("ticket-3", manager.Tickets.Find(t => t.Id == "ticket-3")?.Id);

    }

    [Fact]
    public async Task TicketManager_ShouldUpdateTicket()
    {
        // Arrange
        TicketHub hub = new TicketHub();
        TicketManager manager = new TicketManager(hub);
        TestableNotificationService notificationService = new TestableNotificationService();
        notificationService.SubscribeToTicketEvents(hub);

        // Act
        await manager.CreateTicket("ticket-3", "client-3", "This is a general enquiry", "General", null);
        await manager.UpdateTicket("ticket-3", "This is an update to ticket.");

        // Assert
        Ticket? updatedTicket = manager.Tickets.Find(t => t.Id == "ticket-3");
        Assert.NotNull(updatedTicket);
        Assert.Equal("This is an update to ticket.", updatedTicket.Update);
        Assert.Equal("Processing", updatedTicket.TicketStatus.ToString());
    }

    [Fact]
    public async Task TicketManager_ShouldUpdateCloseTicket()
    {
        // Arrange
        TicketHub hub = new TicketHub();
        TicketManager manager = new TicketManager(hub);
        TestableNotificationService notificationService = new TestableNotificationService();
        notificationService.SubscribeToTicketEvents(hub);

        // Act
        await manager.CreateTicket("ticket-3", "client-3", "This is a general enquiry", "General", null);
        await manager.CloseTicket("ticket-3", "The ticket is closed.");

        // Assert
        Ticket? closedTicket = manager.Tickets.Find(t => t.Id == "ticket-3");
        Assert.NotNull(closedTicket);
        Assert.Equal("The ticket is closed.", closedTicket.Result);
        Assert.Equal("Closed", closedTicket.TicketStatus.ToString());
    }

    private class TestableNotificationService : NotificationService
    {
        public bool Triggered { get; private set; }
        public string? LastEventType { get; private set; }
        public string? LastTicketId { get; private set; }

        public override async Task RespondToTicketEvent(Ticket ticket, string eventType)
        {
            Triggered = true;
            LastEventType = eventType;
            LastTicketId = ticket.Id;
            await Task.CompletedTask;
        }
    }


}