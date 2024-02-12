namespace BusinessLogic.DTOs
{
    public class OrderSummaryModel
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
