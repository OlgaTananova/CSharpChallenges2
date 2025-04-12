using System;

namespace ParkingSystem.Vehicles;

public class Truck : Vehicle
{
    public Truck(VehicleType type = VehicleType.Truck) : base(type)
    {
        VehicleType = type;
    }
}
