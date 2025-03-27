🔌 SmartDeviceSystem – Event-Driven Smart Home Simulator
SmartDeviceSystem is a simple, event-driven simulation of a smart home system built in C#. It demonstrates key software design principles including:

✅ Object-Oriented Programming (OOP) with device abstraction and polymorphism

📡 Event-Driven Architecture using a custom async event delegate

⏱ Asynchronous Programming with real-world command delays

The system includes a central SmartHubController that issues commands to various smart devices (light, thermostat, camera, lock), each reacting independently through subscribed async event handlers.
