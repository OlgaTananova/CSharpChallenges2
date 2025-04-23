using System;
using System.Threading.Channels;
using ParkingSystem.Vehicles;

namespace ParkingSystem.Parking;

public class Kiosk
{
    public int Id { get; set; }

    public async Task<bool> RunKioskAsync(ParkingLot lot, Vehicle vehicle, int maxRetries = 5)
    {
        // Simulate delay when arriving
        await Task.Delay(Random.Shared.Next(100, 500));

        // Try to park the vehicle up to 5 times if the spot is not avaliable;
        for (int i = 0; i < maxRetries; i++)
        {
            if (await lot.ParkVehicle(vehicle))
            {
                // Simulate parking duration
                await Task.Delay(Random.Shared.Next(1000, 3000));
                await lot.RemoveVehicle(vehicle.LicensePlate);
                return true;
            }

            Console.WriteLine($"Retry. Couldn't park the vehicle with the license plate {vehicle.LicensePlate} now.");
            // simulate breaks before the next attempt
            await Task.Delay(Random.Shared.Next(100, 500));
        }

        Console.WriteLine($"{vehicle.LicensePlate} failed to park after {maxRetries} attempts.");
        return false;
    }

    public async Task<string> RunKioskWithQueueAsync(ChannelWriter<VehicleRequest> wwriter, Vehicle vehicle)
    {
        VehicleRequest request = new VehicleRequest { Vehicle = vehicle };
        await wwriter.WriteAsync(request);
        return await request.Completion.Task;
    }

}
