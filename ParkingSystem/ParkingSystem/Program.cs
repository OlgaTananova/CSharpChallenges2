// Create vehicles 

using ParkingSystem.Parking;
using ParkingSystem.Vehicles;

// vehicles
Car car1 = new() { LicensePlate = "123SAS" };
Car car2 = new Car() { LicensePlate = "1245SAS" };
Car car3 = new Car() { LicensePlate = "586353DSDF" };
Motocycle motocycle1 = new Motocycle() { LicensePlate = "37465e2" };
Truck truck1 = new Truck() { LicensePlate = "635432" };

ParkingLot parkingLot = new ParkingLot(10);

// 2 kiosks operate at the parking lot
Kiosk kiost1 = new Kiosk() { Id = 1 };
Kiosk kiost2 = new Kiosk() { Id = 2 };

// simulate driving the vehicles throught the kiosks asynchronously
List<Task<bool>> tasks = new List<Task<bool>>
{
    kiost1.RunKioskAsync(parkingLot, car1),
    kiost2.RunKioskAsync(parkingLot, car2),
    kiost1.RunKioskAsync(parkingLot, truck1),
    kiost1.RunKioskAsync(parkingLot, motocycle1)

};

await Task.WhenAll(tasks);
