using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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
    public async Task ParkVehicle_ShouldReturnTrueSuccessfulParking_When2CarsParked()
    {
        // Arrange

        ParkingLot lot = new(10);

        Car car1 = new Car { LicensePlate = "CAR1" };
        Car car2 = new Car { LicensePlate = "CAR2" };

        var result1 = await lot.ParkVehicle(car1);
        var result2 = await lot.ParkVehicle(car2);



        var avaliableSpots = lot.ShowAvaliableSpots();

        //Assert
        Assert.True(result1);
        Assert.True(result2);
        Assert.Equal(avaliableSpots?.Count, 8);
    }

    [Fact]
    public async Task ParkVehicle_ShouldReturnFalse_WhenNoAvaliableSpots()
    {
        // Arrange

        ParkingLot lot = new(3);

        Car car1 = new Car { LicensePlate = "CAR1" };
        Truck truck = new Truck { LicensePlate = "TRUCK1" };
        Car car2 = new Car { LicensePlate = "CAR1" };


        // Act
        await lot.ParkVehicle(truck);
        await lot.ParkVehicle(car1);

        var result = await lot.ParkVehicle(car2);
        //Assert
        Assert.False(result);
    }

    [Fact]
    public async Task RemoveVehicle_ShouldReturnTrueSuccessfullyRemoveVehicle_WhenItParked()
    {
        // Arrange

        ParkingLot lot = new(5);

        Car car1 = new Car { LicensePlate = "CAR1" };

        // Act
        await lot.ParkVehicle(car1);
        var result = await lot.RemoveVehicle(car1.LicensePlate);

        var avaliableSpots = lot.ShowAvaliableSpots();

        //Assert
        Assert.True(result);
        Assert.Equal(avaliableSpots?.Count, 5);
    }

    [Fact]
    public async Task RemoveVehicle_ShouldReturnFalse_WhenNoVehicleOnParkingLot()
    {
        // Arrange

        ParkingLot lot = new(5);

        Car car1 = new Car { LicensePlate = "CAR1" };
        string licensePlate = "CAR2";

        // Act
        await lot.ParkVehicle(car1);
        var result = await lot.RemoveVehicle(licensePlate);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public async Task ParkTruck_ShouldReturnFalseFail_WhenNoTwoAdjacentSpots()
    {
        // Arrange
        ParkingLot lot = new(4);
        await lot.ParkVehicle(new Car { LicensePlate = "CAR1" });
        await lot.ParkVehicle(new Car { LicensePlate = "CAR2" });
        await lot.ParkVehicle(new Car { LicensePlate = "CAR3" });

        var truck = new Truck { LicensePlate = "TRUCK1" };

        // Act
        var result = await lot.ParkVehicle(truck);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task ParkVehiclesThroughKiosk_ShouldSuccessfullyParkAndVacate()
    {
        // Arrange
        ParkingLot lot = new(5);
        Kiosk kiosk = new Kiosk();
        Kiosk kiosk2 = new Kiosk();

        Car car1 = new Car() { LicensePlate = "CAR1" };
        Truck truck = new Truck() { LicensePlate = "TRUCK1" };

        // Act

        List<Task<bool>> parkingTasks = new List<Task<bool>> {
            kiosk.RunKioskAsync(lot, car1),
            kiosk2.RunKioskAsync(lot,truck)
        };
        var result = await Task.WhenAll(parkingTasks);
        await Task.Delay(1000);
        var avaliableSpots = lot.ShowAvaliableSpots();
        // Assert

        Assert.NotEmpty(result);
        Assert.True(result[0]);
        Assert.True(result[1]);
        Assert.Equal(5, avaliableSpots?.Count);
    }
}
