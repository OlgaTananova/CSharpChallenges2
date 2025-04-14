using System;
using ParkingSystem.Vehicles;

namespace ParkingSystem.Parking;

public class ParkingSpot
{
    public required int SpotId { get; set; }
    public bool IsOccupied => Vehicle != null;
    public Vehicle? Vehicle { get; set; }

    public void Park(Vehicle vehicle) => Vehicle = vehicle;
    public void Vacate() => Vehicle = null;
}
