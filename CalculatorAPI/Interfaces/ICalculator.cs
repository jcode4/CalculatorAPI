namespace CalculatorAPI.Interfaces
{
    public interface ICalculator
    {
        public double Add(double x, double y, string location);
        public double Subtract(double x, double y, string location); 
        public double Multiply(double x, double y, string location);
        public double Divide(double x, double y, string location);
    }
}
