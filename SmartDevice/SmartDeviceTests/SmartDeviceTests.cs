using System;
using SmartDeviceSystem.Core.Controllers;
using SmartDeviceSystem.Core.Devices;
using SmartDeviceSystem.Core.Interfaces;

namespace SmartDeviceTests;

public class SmartDeviceTests
{

    [Fact]
    public async Task SmartLight_ShouldUpdateStatus_OnCommand()
    {
        // Arrange

        var light = new SmartLight
        {
            DeviceId = "light-1",
            Name = "Light",
            Status = "Off"
        };

        var hub = new SmartHubContoller();
        light.SubscribeToHub(hub);
        List<ISmartDevice> devices = [light];
        hub.SubscribeToDeviceStatusChanges(devices);

        // Act
        await hub.SendCommandToDevice("light-1", "TurnOn");

        //  Assert 
        Assert.Equal("TurnedOn", light.Status);

    }

    [Fact]
    public async Task Thermostat_ShouldUpdateStatus_OnCommand()
    {
        // Arrange

        var thermostat = new SmartThermostat
        {
            DeviceId = "thermo-1",
            Name = "Thermostat",
            Status = "Temp: 20C"
        };

        var light = new SmartLight
        {
            DeviceId = "light-1",
            Name = "Light",
            Status = "Off"
        };

        var hub = new SmartHubContoller();
        thermostat.SubscribeToHub(hub);
        light.SubscribeToHub(hub);
        List<ISmartDevice> devices = [thermostat, light];
        hub.SubscribeToDeviceStatusChanges(devices);

        // Act
        await hub.SendCommandToAllDevices("TurnOn");

        //  Assert 
        Assert.Equal("Temp: 20C", thermostat.Status);
        Assert.Equal("TurnedOn", light.Status);

    }

    [Fact]
    public async Task SecurityCamera_ShouldUpdateStatus_OnCommand()
    {
        // Arrange

        var camera = new SecurityCamera
        {
            DeviceId = "camera-1",
            Name = "Camera",
            Status = "TurnedOff"
        };


        var hub = new SmartHubContoller();
        camera.SubscribeToHub(hub);
        List<ISmartDevice> devices = [camera];
        hub.SubscribeToDeviceStatusChanges(devices);

        // Act
        await hub.SendCommandToDevice("camera-1", "StartRecording");

        //  Assert 
        Assert.Equal("Recording", camera.Status);

        await hub.SendCommandToDevice("camera-1", "StopRecording");

        Assert.Equal("Stopped", camera.Status);

    }

    [Fact]
    public async Task SendCommandToAllDevices_ShouldUpdateStatus_OnCommand()
    {
        // Arrange

        var thermostat = new SmartThermostat
        {
            DeviceId = "thermo-1",
            Name = "Thermostat",
            Status = "Temp: 20C"
        };


        var hub = new SmartHubContoller();
        thermostat.SubscribeToHub(hub);
        List<ISmartDevice> devices = [thermostat];
        hub.SubscribeToDeviceStatusChanges(devices);

        // Act
        await hub.SendCommandToDevice("thermo-1", "SetTemperature:23");

        //  Assert 
        Assert.Equal("Temp: 23C", thermostat.Status);

    }

}
