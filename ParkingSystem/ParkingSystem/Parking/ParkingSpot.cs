using System;
using System.Reflection.Metadata.Ecma335;
using ParkingSystem.Vehicles;

namespace ParkingSystem.Parking;

public class ParkingSpot
{
    // synchronization primitive to lock the spot when a vehicle tried to park and vacate the spot
    private readonly SemaphoreSlim _slim = new SemaphoreSlim(1, 1);
    public required int SpotId { get; set; }
    public bool IsOccupied => Vehicle != null;
    public Vehicle? Vehicle { get; set; }

    public async Task<bool> TryParkAsync(Vehicle vehicle)
    {
        await _slim.WaitAsync();
        try
        {
            if (IsOccupied) return false;
            Vehicle = vehicle;
            return true;
        }
        finally
        {
            _slim.Release();
        }
    }
    public async Task<bool> TryVacateAsync(string licensePlate)
    {
        await _slim.WaitAsync();
        try
        {
            if (Vehicle?.LicensePlate != licensePlate) return false;
            Vehicle = null;
            return true;

        }
        finally
        {
            _slim.Release();
        }
    }


}
