// Create vehicles 

using ParkingSystem.Parking;
using ParkingSystem.Vehicles;

Car car1 = new Car() { LicensePlate = "123SAS" };
Car car2 = new Car() { LicensePlate = "1245SAS" };
Car car3 = new Car() { LicensePlate = "586353DSDF" };
Motocycle motocycle1 = new Motocycle() { LicensePlate = "37465e2" };
Truck truck1 = new Truck() { LicensePlate = "635432" };

ParkingLot parkingLot = new ParkingLot(30);
