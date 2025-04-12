using System;

namespace ParkingSystem.Vehicles;

public abstract class Vehicle
{

    public required string LicensePlate { get; set; }

    public VehicleType VehicleType { get; set; }

    public Vehicle(VehicleType type)
    {
        VehicleType = type;
    }
}
