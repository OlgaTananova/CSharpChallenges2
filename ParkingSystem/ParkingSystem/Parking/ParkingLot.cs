using System;
using System.Dynamic;
using ParkingSystem.Vehicles;

namespace ParkingSystem.Parking;

public class ParkingLot
{
    public List<ParkingSpot> Spots { get; private set; }

    public ParkingLot(int totalSpots)
    {
        Spots = Enumerable.Range(1, totalSpots).Select(s => new ParkingSpot { SpotId = s }).ToList();
    }

    public async Task<bool> ParkVehicle(Vehicle vehicle)
    {

        var candidateSpots = FindAvaliableSpot(vehicle.RequiredSpots);
        if (candidateSpots.Count != vehicle.RequiredSpots)
        {
            Console.WriteLine($"There are no avaliable spots for the vehicle license plate {vehicle.LicensePlate}");
            return false;
        }

        var success = true;
        foreach (var spot in candidateSpots)
        {
            success &= await spot.TryParkAsync(vehicle);
        }
        if (success)
        {
            Console.WriteLine($"Parked vehicle with license plate {vehicle.LicensePlate} at spots: {string.Join(", ", candidateSpots.Select(s => s.SpotId))}");
            return true;
        }
        else
        {
            foreach (var spot in candidateSpots)
            {
                await spot.TryVacateAsync(vehicle.LicensePlate);
            }
            Console.WriteLine($"Failed to park the vehicle with license plate {vehicle.LicensePlate}");
            return false;
        }
    }

    public async Task<bool> RemoveVehicle(string licensePlate)
    {
        var occupiedSpots = Spots.Where(s => s.Vehicle?.LicensePlate.ToLower() == licensePlate.ToLower()).ToList();

        if (!occupiedSpots.Any())
        {
            Console.WriteLine($"There was not found any vehicle with license plate {licensePlate}");
            return false;
        }

        foreach (var spot in occupiedSpots)
        {
            await spot.TryVacateAsync(licensePlate);
        }
        Console.WriteLine($"The vehicle with licence plate {licensePlate} was removed from spots: {string.Join(", ", occupiedSpots.Select(s => s.SpotId))}");
        return true;

    }


    public List<int>? ShowAvaliableSpots()
    {
        var avalialeSpots = Spots.Where(s => !s.IsOccupied).Select(s => s.SpotId).ToList();
        Console.WriteLine($"AvaliableSpots: {string.Join(", ", avalialeSpots)}");
        return avalialeSpots;
    }


    private List<ParkingSpot> FindAvaliableSpot(int requiredSpots)
    {
        for (int i = 0; i <= Spots.Count - requiredSpots; i++)
        {
            var range = Spots.GetRange(i, requiredSpots);
            if (range.All(s => !s.IsOccupied))
                return range;
        }
        return new List<ParkingSpot>();
    }

}
