using System;
using ParkingSystem.Vehicles;

namespace ParkingSystem.Parking;

public class VehicleRequest
{

    public required Vehicle Vehicle { get; set; }
    public TaskCompletionSource<string> Completion { get; set; } = new();

}
