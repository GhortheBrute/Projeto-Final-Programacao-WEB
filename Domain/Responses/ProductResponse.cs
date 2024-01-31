namespace Domain.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; } = 0.00M;
}
