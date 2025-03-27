using System;
using SmartDeviceSystem.Core.Controllers;
using SmartDeviceSystem.Core.Events;

namespace SmartDeviceSystem.Core.Interfaces;

public interface ISmartDevice
{
    string DeviceId { get; set; }
    string Name { get; set; }
    string Status { get; set; }
    void SubscribeToHub(SmartHubContoller hub);
    event EventHandler<DeviceStatusChangedEventArg> StatusChanged;
}
