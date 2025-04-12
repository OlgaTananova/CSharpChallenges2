using System;
using ParkingSystem.Vehicles;

namespace ParkingSystem.Parking;

public class ParkingSpot
{
    public required int SpotId { get; set; }
    public bool IsOccupied { get; set; } = false;
    public Vehicle? Vehicle { get; set; }
}
