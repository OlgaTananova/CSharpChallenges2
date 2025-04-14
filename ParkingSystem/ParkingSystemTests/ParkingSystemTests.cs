using System;
using System.Security.Cryptography.X509Certificates;
using ParkingSystem.Parking;
using ParkingSystem.Vehicles;

namespace ParkingSystemTests;

public class ParkingSystemTests
{

    [Fact]
    public void ShowAvaliableSpots_ShouldReturnCorrectCount_WhenNoVehicles()
    {
        //Arrange

        ParkingLot lot = new ParkingLot(10);

        //Act
        var avaliableSpots = lot.ShowAvaliableSpots();

        //Assert

        Assert.NotNull(avaliableSpots);
        Assert.Equal(10, avaliableSpots?.Count);

    }

    [Fact]
    public void ParkVehicle_ShouldReturnTrueSuccessfulParking_When2CarsParked()
    {
        // Arrange

        ParkingLot lot = new(10);

        Car car1 = new Car { LicensePlate = "CAR1" };
        Car car2 = new Car { LicensePlate = "CAR2" };

        // Act
        var parkedVehicleResult1 = lot.ParkVehicle(car1);
        var parkedVehicleResult2 = lot.ParkVehicle(car2);
        var avaliableSpots = lot.ShowAvaliableSpots();

        //Assert
        Assert.True(parkedVehicleResult1);
        Assert.True(parkedVehicleResult2);
        Assert.Equal(avaliableSpots?.Count, 8);
    }

    [Fact]
    public void ParkVehicle_ShouldReturnFalse_WhenNoAvaliableSpots()
    {
        // Arrange

        ParkingLot lot = new(3);

        Car car1 = new Car { LicensePlate = "CAR1" };
        Truck truck = new Truck { LicensePlate = "TRUCK1" };
        Car car2 = new Car { LicensePlate = "CAR1" };

        // Act
        var parkedVehicleResult1 = lot.ParkVehicle(car1);
        var parkedVehicleResult2 = lot.ParkVehicle(truck);
        var parkedVehicleResult3 = lot.ParkVehicle(car2);
        var avaliableSpots = lot.ShowAvaliableSpots();

        //Assert
        Assert.False(parkedVehicleResult3);
        Assert.Equal(avaliableSpots?.Count, 0);
    }

    [Fact]
    public void RemoveVehicle_ShouldReturnTrueSuccessfullyRemoveVehicle_WhenItParked()
    {
        // Arrange

        ParkingLot lot = new(5);

        Car car1 = new Car { LicensePlate = "CAR1" };

        // Act
        lot.ParkVehicle(car1);
        var result = lot.RemoveVehicle(car1.LicensePlate);

        var avaliableSpots = lot.ShowAvaliableSpots();

        //Assert
        Assert.True(result);
        Assert.Equal(avaliableSpots?.Count, 5);
    }

    [Fact]
    public void RemoveVehicle_ShouldReturnFalse_WhenNoVehicleOnParkingLot()
    {
        // Arrange

        ParkingLot lot = new(5);

        Car car1 = new Car { LicensePlate = "CAR1" };
        string licensePlate = "CAR2";

        // Act
        lot.ParkVehicle(car1);
        var result = lot.RemoveVehicle(licensePlate);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void ParkTruck_ShouldReturnFalseFail_WhenNoTwoAdjacentSpots()
    {
        // Arrange
        ParkingLot lot = new(4);
        lot.ParkVehicle(new Car { LicensePlate = "CAR1" }); 
        lot.ParkVehicle(new Car { LicensePlate = "CAR2" }); 
        lot.ParkVehicle(new Car { LicensePlate = "CAR3" }); 

        var truck = new Truck { LicensePlate = "TRUCK1" };

        // Act
        var result = lot.ParkVehicle(truck);

        // Assert
        Assert.False(result);
    }
}
