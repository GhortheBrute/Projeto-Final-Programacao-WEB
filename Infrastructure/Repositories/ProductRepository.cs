using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    List<Product> List();
    Product? GetById(int id);
    Product Create(Product newProduct);
    Product Update(Product updatedProduct);
    void Delete(int id);
}

public class ProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>();

    public List<Product> List()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(x => x.Id == id);
    }

    public Product Create(Product newProduct)
    {
        newProduct.Id = _products.Count + 1;
        _products.Add(newProduct);
        return newProduct;
    }

    public Product Update(Product updatedProduct)
    {
        var user = GetById(updatedProduct.Id);

        if (user is null)
            throw new Exception("User not found!");

        user.Description = updatedProduct.Description;
        user.Price = updatedProduct.Price;
        return user;
    }

    public void Delete(int id)
    {
        var user = GetById(id);

        if (user is null)
            throw new Exception("User not found!");

        _products.Remove(user);
    }
}
