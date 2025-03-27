Task: Customer Support Ticketing System
Scenario:
You're building a simple event-driven ticketing system for a customer support platform. Users can create tickets, and support agents or automated services respond to tickets or perform actions based on ticket events.

Key Features:
Tickets can be created, updated, and closed.

An event hub (like a message broker) publishes events like TicketCreated, TicketUpdated, and TicketClosed.

Multiple services subscribe to these events:

NotificationService: sends email alerts.

AnalyticsService: logs and analyzes ticket activity.

AutoResponderService: auto-replies to common issues.

Core Concepts Covered:
OOP: Use of interfaces and inheritance for ticket types and services.

Event-Driven Architecture: Using custom events and event handlers.

Asynchronous Programming: Simulating delay in ticket processing and notification.

Separation of Concerns: Services are decoupled from the main flow.

Objects to Model:
Ticket (base class)

BugReport, FeatureRequest, GeneralInquiry (subclasses)

ITicketService (interface)

Implemented by services like NotificationService, AnalyticsService

TicketingHub

Central event publisher

Exposes events: TicketCreated, TicketUpdated, TicketClosed

TicketManager

Creates, updates, and closes tickets by invoking the hub

Example Flow:
A user creates a new bug ticket.

TicketingHub raises the TicketCreated event.

NotificationService sends an email.

AnalyticsService logs it.

AutoResponderService analyzes the content and sends a canned response (asynchronously).

