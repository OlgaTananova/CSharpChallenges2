using System;

namespace SmartDeviceSystem.Core.Devices;

public class SmartThermostat : SmartDeviceBase
{
    private int currentTemperature = 20;

    protected override async Task ExecuteCommandAsync(string command)
    {
        await Task.Delay(2000);
        if (command.StartsWith("SetTemperature:"))
        {
            var commandParts = command.Split(':');
            if (int.TryParse(commandParts[1], out int temp))
            {
                currentTemperature = temp;
                Status = $"Temp: {temp}C";

            }
        }
        else if (command.StartsWith("TurnOn"))
        {
            currentTemperature = 20;
            Status = "Temp: 20C";
        }
        else if (command.StartsWith("TurnOff"))
        {
            Status = "Temp: 20C";
            currentTemperature = 20;

        }


        OnStatusChanged();
    }
}
