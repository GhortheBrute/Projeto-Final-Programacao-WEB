namespace Domain.Requests;

public class BaseProductRequest
{
    public string Description { get; set; }
    public decimal Price { get; set; }
}

public class UpdateProductRequest : BaseProductRequest
{
    public int Id { get; set; }
}
