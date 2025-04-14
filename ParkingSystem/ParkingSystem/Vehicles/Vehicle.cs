using System;

namespace ParkingSystem.Vehicles;

public abstract class Vehicle
{

    public required string LicensePlate { get; set; }

    public VehicleType VehicleType { get; }

    protected Vehicle(VehicleType type)
    {
        VehicleType = type;
    }
    public abstract int RequiredSpots { get; }
}
