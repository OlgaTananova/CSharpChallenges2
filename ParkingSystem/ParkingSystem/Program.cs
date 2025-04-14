// Create vehicles 

using ParkingSystem.Parking;
using ParkingSystem.Vehicles;

Car car1 = new() { LicensePlate = "123SAS" };
Car car2 = new Car() { LicensePlate = "1245SAS" };
Car car3 = new Car() { LicensePlate = "586353DSDF" };
Motocycle motocycle1 = new Motocycle() { LicensePlate = "37465e2" };
Truck truck1 = new Truck() { LicensePlate = "635432" };

ParkingLot parkingLot = new ParkingLot(10);

parkingLot.ParkVehicle(car1);
parkingLot.ParkVehicle(car2);
parkingLot.ParkVehicle(car3);
parkingLot.ParkVehicle(truck1);

parkingLot.ShowAvaliableSpots();
parkingLot.RemoveVehicle("123SAS");
parkingLot.RemoveVehicle("37465e2");
parkingLot.ShowAvaliableSpots();
