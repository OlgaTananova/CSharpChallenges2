using System;
using System.Data.Common;
using SmartDeviceSystem.Core.Events;
using SmartDeviceSystem.Core.Interfaces;

namespace SmartDeviceSystem.Core.Controllers;

public class SmartHubContoller
{
    // declare delegate for async handler
    public delegate Task AsyncEventHandler<TEventAgr>(object? sender, TEventAgr e);

    // create event to match this async handler
    public event AsyncEventHandler<DeviceCommandEventArg>? CommandIssued;

    // invoke the event asynchronously
    public async Task SendCommandToDevice(string deviceId, string command)
    {
        if (CommandIssued != null)
        {
            await CommandIssued(this, new DeviceCommandEventArg(deviceId, command));
        }
    }

    public async Task SendCommandToAllDevices(string command)
    {
        if (CommandIssued != null)
        {
            await CommandIssued(this, new DeviceCommandEventArg(null, command));
        }
    }

    public void SubscribeToDeviceStatusChanges(List<ISmartDevice> devices)
    {
        foreach (var device in devices)
        {
            device.StatusChanged += (sender, e) =>
            {
                Console.WriteLine($"Status of the device with id {device.DeviceId} and name {device.Name} has changed to {e.NewStatus}");
            };
        }
    }
}
