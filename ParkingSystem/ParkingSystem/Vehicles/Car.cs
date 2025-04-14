using System;

namespace ParkingSystem.Vehicles;

public class Car : Vehicle
{
    public Car() : base(VehicleType.Car) { }
    public override int RequiredSpots => 1;

}
