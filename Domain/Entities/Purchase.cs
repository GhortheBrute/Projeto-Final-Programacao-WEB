using System.Numerics;

namespace Domain.Entities;

public class Purchase
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal total { get; set; }

    public Purchase()
    {
        // obter valor do produto
        //total = Quantity * price;
    }
}
