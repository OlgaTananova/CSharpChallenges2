using System;

namespace SmartDeviceSystem.Core.Events;

public class DeviceCommandEventArg : EventArgs
{
    public string? DeviceId { get; set; }
    public string Command { get; set; }

    public DeviceCommandEventArg(string? deviceId, string command)
    {
        DeviceId = deviceId;
        Command = command;
    }
}
