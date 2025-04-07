# Customer Ticketing System 
A modular, event-driven customer support ticketing system in C#. Supports asynchronous ticket processing, notification services, analytics, and auto-responses using clean architectural patterns. Built to demonstrate OOP, async programming, and event-driven architecture in a real-world scenario.

Key Features:
- Tickets can be created, updated, and closed;
- An event hub (like a message broker) publishes events;
- Multiple services subscribe to these events: NotificationService, AnalyticsService, AutoResponderService;
- Central event publisher - TicketingHub exposes events: TicketCreated, TicketUpdated, TicketClosed;
- TicketManager creates, updates, and closes tickets by invoking the hub;
- Unit tests to test the main logic;
