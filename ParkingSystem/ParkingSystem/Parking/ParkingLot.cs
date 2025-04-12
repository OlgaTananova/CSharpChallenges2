using System;
using System.Dynamic;
using ParkingSystem.Vehicles;

namespace ParkingSystem.Parking;

public class ParkingLot
{
    public List<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();

    private int _totalSpots;
    private int _occupiedSpots;
    private int _avaliableSpots;

    public int AvaliableSpots;

    public ParkingLot(int totalSpots)
    {
        _totalSpots = totalSpots;
        AvaliableSpots = _totalSpots;
        CreateParkingSpots(_totalSpots);
    }

    private void CreateParkingSpots(int numberOfSpots)
    {
        for (int i = 1; i <= numberOfSpots; i++)
        {
            ParkingSpot spot = new ParkingSpot
            {
                SpotId = i
            };
            ParkingSpots.Add(spot);
        }
    }

    public (int, int) ParkVehicle(Vehicle vehicle)
    {
        // check if there are avaliable spots - if not - return 0;
        // if yes assign vehicle to the first unoccupied spot
        var index = GetValiableSpots(vehicle.VehicleType);
        if (index != (-1, -1) && index.Item2 == 0)
        {
            var spot = ParkingSpots[index.Item1];
            spot.Vehicle = vehicle;
            _occupiedSpots++;
            _avaliableSpots = _totalSpots - _occupiedSpots;
            return (spot.SpotId, 0);
        }
        else if (index != (-1, -1) && index.Item2 != 0)
        {
            var spot1 = ParkingSpots[index.Item1];
            var spot2 = ParkingSpots[index.Item2];
            spot1.Vehicle = vehicle;
            spot2.Vehicle = vehicle;
            _occupiedSpots += 2;
            _avaliableSpots = _totalSpots - _occupiedSpots;
            return (spot1.SpotId, spot2.SpotId);
        }
        // decrease the number of avaliable spots
        // return spotID
        return (-1, -1);
    }

    public bool RemoveVehicle(string licensePlate)
    {
        // find a parking spot contaning a vehicle wih the license plate

        var spots = ParkingSpots.FindAll(s => s.Vehicle?.LicensePlate == licensePlate);
        if (spots == null) return false;

        // if found - remove Vehicle from the parking spot (make it null)

        spots.ForEach(s => { s.IsOccupied = false; s.Vehicle = null; });
        _occupiedSpots -= _occupiedSpots - spots.Count;
        _avaliableSpots = _totalSpots - _occupiedSpots;
        return true;
    }

    public (int, int) GetValiableSpots(VehicleType type)
    {
        if (_avaliableSpots == 0) return (-1, -1);
        if (type == VehicleType.Car || type == VehicleType.Motocycle)
        {
            var index = ParkingSpots.FindIndex(s => !s.IsOccupied);
            return (index, 0);
        }
        else if (type == VehicleType.Truck)
        {
            var index = ParkingSpots.FindIndex(s => !s.IsOccupied);
            if (index != -1)
            {
                if (index + 1 < ParkingSpots.Count - 1 && !ParkingSpots[index + 1].IsOccupied)
                {
                    return (index, index + 1);
                }
                else
                {
                    return (-1, -1);
                }
            }
            return (-1, -1);
        }
        return (-1, -1);
    }


}
