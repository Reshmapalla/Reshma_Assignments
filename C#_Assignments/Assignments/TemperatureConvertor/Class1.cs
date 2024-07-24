namespace TemperatureConvertor
{
    public class Temperature
    {
        public  double  FTC(double temp)
        {
            double C = (temp - 32) * (5.0 / 9.0);
            return C;
            
        }
        public double CTF(double temp)
        {
            double F = (9 / 5) * temp + 32;

            return F;

        }
    }
}
