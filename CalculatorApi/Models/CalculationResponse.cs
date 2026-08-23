namespace CalculatorApi.Models
{
    public class CalculationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal Result { get; set; }
    }
}
