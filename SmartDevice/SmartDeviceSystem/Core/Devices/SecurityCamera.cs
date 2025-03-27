using System;

namespace SmartDeviceSystem.Core.Devices;

public class SecurityCamera : SmartDeviceBase
{
    private DateTime? RecordingStart;
    private DateTime? RecordingStop;
    private TimeSpan? RecordingTime;
    protected override async Task ExecuteCommandAsync(string command)
    {
        await Task.Delay(1500);
        if (command.StartsWith("StartRecording") || command.StartsWith("TurnOn"))
        {
            RecordingStart = DateTime.Now;
            Status = "Recording";
        }
        else if (command.StartsWith("StopRecording") || command.StartsWith("TurnOff"))
        {
            RecordingStop = DateTime.Now;
            if (RecordingStart <= RecordingStop)
            {
                RecordingTime = RecordingStop - RecordingStart;
                RecordingStart = null;
                RecordingStop = null;
                RecordingTime = null;
                Status = "Stopped";
            }
        }
        OnStatusChanged();
    }
}
