using System;

namespace ParkingSystem.Vehicles;

public class Truck : Vehicle
{
    public Truck() : base(VehicleType.Truck)
    {
    }
    public override int RequiredSpots => 2;
}
