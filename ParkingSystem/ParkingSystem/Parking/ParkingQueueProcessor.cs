using System;
using System.Threading.Channels;

namespace ParkingSystem.Parking;

public class ParkingQueueProcessor
{

    private readonly ParkingLot _lot;

    private readonly ChannelReader<VehicleRequest> _reader;

    public ParkingQueueProcessor(ParkingLot lot, Channel<VehicleRequest> reader)
    {
        _lot = lot;
        _reader = reader;
    }

    public async Task StartProcessingAsync()
    {
        await foreach (var request in _reader.ReadAllAsync())
        {
            while (true)
            {
                var success = await _lot.ParkVehicle(request.Vehicle);
                if (success)
                {
                    await Task.Delay(Random.Shared.Next(1000, 3000));
                    await _lot.RemoveVehicle(request.Vehicle.LicensePlate);
                    request.Completion.SetResult($"Success: vehicle with license plate {request.Vehicle.LicensePlate} parked.");
                    break;
                }
                await Task.Delay(500);
            }
        }
    }

}
