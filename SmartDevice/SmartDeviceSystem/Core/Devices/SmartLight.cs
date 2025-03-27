using System;


namespace SmartDeviceSystem.Core.Devices;

public class SmartLight : SmartDeviceBase
{
    private bool IsOn;
    protected override async Task ExecuteCommandAsync(string command)
    {
        await Task.Delay(500);
        if (command == "TurnOn")
        {
            IsOn = true;
            Status = "TurnedOn";
        }
        else if (command == "TurnOff")
        {
            IsOn = false;
            Status = "TurnedOff";
        }

        OnStatusChanged();
    }
}
