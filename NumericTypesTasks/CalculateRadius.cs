public static class CalculateRadius
{

    public static decimal CalculateRadiusMethod(float radius)
    {

        double area = Math.Sqrt(radius) * Math.PI;

        return (decimal)area;
    }
}