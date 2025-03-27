
// Simulate the smart home work

using SmartDeviceSystem.Core;
using SmartDeviceSystem.Core.Controllers;
using SmartDeviceSystem.Core.Devices;
using SmartDeviceSystem.Core.Interfaces;

// create a hub to control the smart home devices
SmartHubContoller hub = new();

// Create devices

List<ISmartDevice> smartDevices = new List<ISmartDevice>();

SmartLight light = new SmartLight
{
    DeviceId = "light-1",
    Name = "Light",
    Status = "Off"
};

SmartThermostat thermostat = new SmartThermostat
{
    DeviceId = "thermostat-1",
    Name = "Thermostat",
    Status = "Temp: 20C"
};

SmartLock lock_ = new SmartLock
{
    DeviceId = "smartlock-1",
    Name = "SmartLock",
    Status = "Unlocked"
};

SecurityCamera camera = new()
{
    DeviceId = "camera-1",
    Name = "Camera",
    Status = "Stopped"
};

smartDevices.Add(light);
smartDevices.Add(camera);
smartDevices.Add(lock_);
smartDevices.Add(thermostat);

// Subscribe each device to the hub to recieve commands
smartDevices.ForEach(d => d.SubscribeToHub(hub));

// subcribe the hub to the devices to receive updates of their status
hub.SubscribeToDeviceStatusChanges(smartDevices);

// Give commands to devices

await hub.SendCommandToDevice("light-1", "TurnOn");
await hub.SendCommandToDevice("camera-1", "StartRecording");
await hub.SendCommandToDevice("thermostat-1", "SetTemperature:25");