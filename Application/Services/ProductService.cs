using Domain.Exceptions;
using Domain.Requests;
using Domain.Responses;
using Domain.Validators;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Repositories;
using Domain.Mappers;

namespace Application.Services;

public interface IProductService
{
    List<ProductResponse> List();
    ProductResponse? GetById(int id);
    ProductResponse Create(BaseProductRequest newProduct);
    ProductResponse Update(UpdateProductRequest updatedProduct);
    void Delete(int id);
}

public class ProductService : IProductService
{
    private readonly IValidator<BaseProductRequest> _validator;
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository, IValidator<BaseProductRequest> validator)
    {
        _validator = validator;
        _repository = repository;
    }

    public List<ProductResponse> List()
    {
        var products = _repository.List();
        var response = products.Select(ProductMapper.ToResponse).ToList();
        return response;
    }

    public ProductResponse? GetById(int id)
    {
        var product = _repository.GetById(id);
        return product is null ? null : ProductMapper.ToResponse(product);
    }

    public ProductResponse Create(BaseProductRequest productRequest)
    {
        var errors = _validator.Validate(productRequest);

        if (errors.Any())
            throw new BadRequestException(errors);

        var newProduct = ProductMapper.ToEntity(productRequest);
        var product = _repository.Create(newProduct);
        return ProductMapper.ToResponse(product);
    }

    public ProductResponse Update(UpdateProductRequest productRequest)
    {
        var errors = _validator.Validate(productRequest);

        if (errors.Any())
            throw new BadRequestException(errors);

        var updateProduct = ProductMapper.ToEntity(productRequest);
        var product = _repository.Update(updateProduct);
        return ProductMapper.ToResponse(product);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
