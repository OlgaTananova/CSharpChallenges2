using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        TemperatureSensor sensor = new(60.00D);

        TempLogger logger = new();
        logger.SubscribeToTempSensor(sensor);

        sensor.UpdateTemperature(75.00D);
        sensor.UpdateTemperature(50.00D);
        sensor.UpdateTemperature(80.00D);
    }

}


public class TemperatureSensor
{
    private double _lastReportedTemp = 0.00D;
    public double Temperature { get; private set; }
    public event EventHandler<double>? TemperatureExceeded;
    public double Threshold { get; set; }

    public TemperatureSensor(double threshold)
    {

        if (threshold <= 0) throw new ArgumentException("The temp threshold cannot be less or equal to 0.");
        Threshold = threshold;
    }



    public void UpdateTemperature(double newTemp)
    {

        Temperature = newTemp;

        if (Temperature >= Threshold && newTemp != _lastReportedTemp)
        {
            TemperatureExceeded?.Invoke(this, Temperature);
            _lastReportedTemp = Temperature;
        }
    }
}

public class TempLogger
{
    public void SubscribeToTempSensor(TemperatureSensor sensor)
    {
        if (sensor is not null)
        {
            sensor.TemperatureExceeded += TempChangeHandler;
        }


    }

    public void TempChangeHandler(object? sender, double temp)
    {
        Console.WriteLine($"Warning! The temperature has changed, new temp is {temp} F at time {DateTime.Now}");
    }
}
