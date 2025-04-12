using System;

namespace ParkingSystem.Vehicles;

public class Motocycle : Vehicle
{

    public Motocycle(VehicleType type = VehicleType.Motocycle) : base(type)
    {
        VehicleType = type;
    }


}
