using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public interface IPurchaseRepository
{
    List<Purchase> List();
    Purchase? GetById(int id);
    Purchase Create(Purchase newPurchase);
    Purchase Update(Purchase updatedPurchase);
    void Delete(int id);
}

public class PurchaseRepository : IPurchaseRepository
{
    private List<Purchase> _cart = new List<Purchase>(); // Banco de dados

    public List<Purchase> List()
    {
        return _cart;
    }

    public Purchase? GetById(int id)
    {
        return _cart.FirstOrDefault(x => x.Id == id);
    }

    public Purchase Create(Purchase newPurchase)
    {
        newPurchase.Id = _cart.Count + 1;
        _cart.Add(newPurchase);
        return newPurchase;
    }

    public Purchase Update(Purchase updatedPurchase)
    {
        var cart = GetById(updatedPurchase.Id);

        if (cart is null)
            throw new Exception("Product not found!");

        cart.ProductId = updatedPurchase.ProductId;
        cart.ProductName = updatedPurchase.ProductName;
        cart. = updatedPurchase.Password;
        return cart;
    }

    public void Delete(int id)
    {
        var user = GetById(id) ?? throw new Exception("User not found!");
        _cart.Remove(user);
    }
}
