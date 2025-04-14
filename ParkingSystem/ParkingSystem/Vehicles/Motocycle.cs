using System;

namespace ParkingSystem.Vehicles;

public class Motocycle : Vehicle
{

    public Motocycle() : base(VehicleType.Motocycle)
    {

    }
    public override int RequiredSpots => 1;

}
