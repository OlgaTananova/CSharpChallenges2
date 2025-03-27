using System;
using SmartDeviceSystem.Core.Devices;

namespace SmartDeviceSystem.Core;

public class SmartLock : SmartDeviceBase
{
    protected override async Task ExecuteCommandAsync(string command)
    {
        await Task.Delay(500);
        if (command.StartsWith("Lock"))
        {
            Status = "Locked";
        }
        else if (command.StartsWith("Unlock"))
        {
            Status = "Unlocked";
        }
        OnStatusChanged();
    }
}
