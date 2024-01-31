using Domain.Entities;
using Domain.Requests;
using Domain.Responses;

namespace Domain.Mappers;

public static class ProductMapper
{
    public static ProductResponse ToResponse(Product product) => new()
    {
        Id = product.Id,
        Description = product.Description,
        Price = product.Price
    };
    public static Product ToEntity(BaseProductRequest product) => new()
    {
        Description = product.Description,
        Price = product.Price
    };
    public static Product ToEntity(UpdateProductRequest product) => new()
    {
        Id = product.Id,
        Description = product.Description,
        Price = product.Price
    };
}
