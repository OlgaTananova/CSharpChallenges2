using System;

namespace SmartDeviceSystem.Core.Events;

public class DeviceStatusChangedEventArg : EventArgs
{
    public string NewStatus { get; }

    public DeviceStatusChangedEventArg(string status)
    {
        NewStatus = status;
    }
}
