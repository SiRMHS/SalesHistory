public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ItemId { get; set; }
    public DateTime DateTime { get; set; }
    public decimal GrossAmount { get; set; }
    public string CityName { get; set; }
    public int Quantity { get; set; }
}
