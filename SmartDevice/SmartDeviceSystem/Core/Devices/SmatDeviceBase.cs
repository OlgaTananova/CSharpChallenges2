using System;
using System.Data.Common;
using System.Threading.Tasks;
using SmartDeviceSystem.Core.Controllers;
using SmartDeviceSystem.Core.Events;
using SmartDeviceSystem.Core.Interfaces;
using static SmartDeviceSystem.Core.Controllers.SmartHubContoller;

namespace SmartDeviceSystem.Core.Devices;

public abstract class SmartDeviceBase : ISmartDevice
{
    public required string DeviceId { get; set; }
    public required string Name { get; set; }
    public required string Status { get; set; }

    public event EventHandler<DeviceStatusChangedEventArg>? StatusChanged;

    private AsyncEventHandler<DeviceCommandEventArg>? _hubHandler;

    // event handler to do actions in response to an event
    public void SubscribeToHub(SmartHubContoller hub)
    {
        _hubHandler = async (object? sender, DeviceCommandEventArg e) => 
        {
            if (e.DeviceId == null || e.DeviceId == DeviceId)
            {
                try
                {
                    await ExecuteCommandAsync(e.Command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Device '{DeviceId}' failed to execute command: {ex.Message}");
                }
            }

        }; 
        hub.CommandIssued += _hubHandler;
    }
    public void UnsubscribeFromHub(SmartHubContoller hub)
    {
        if (_hubHandler != null)
        {
            hub.CommandIssued -= _hubHandler;
            _hubHandler = null;
        }

    }

    protected void OnStatusChanged()
    {
        StatusChanged?.Invoke(this, new DeviceStatusChangedEventArg(Status));
    }

    protected abstract Task ExecuteCommandAsync(string command);

}
