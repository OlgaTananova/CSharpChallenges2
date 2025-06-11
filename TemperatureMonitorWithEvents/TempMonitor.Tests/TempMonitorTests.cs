using System;

namespace TempMonitor.Tests;

public class TempMonitorTests
{
    [Fact]
    public void UpdateTemperature_WhenTempExceedsThreshold_RaisesEvent()
    {
        //Arrange 

        TemperatureSensor sensor = new(threshold: 70.00D);
        double? recievedTemp = 0;
        sensor.TemperatureExceeded += (sender, temp) => recievedTemp = temp;

        // Act 

        sensor.UpdateTemperature(75.00D);

        //Assert 

        Assert.Equal(75.00D, recievedTemp);

    }

    [Fact]
    public void UpdateTemperature_WhenTempDoesNotExceedThreshol_DoesNotRaiseEvent()
    {
        //Arrange 

        TemperatureSensor sensor = new(threshold: 70.00D);
        bool wasRaised = false;
        sensor.TemperatureExceeded += (sender, temp) => wasRaised = true; ;

        // Act 

        sensor.UpdateTemperature(65.00D);

        //Assert 

        Assert.False(wasRaised);

    }


}
