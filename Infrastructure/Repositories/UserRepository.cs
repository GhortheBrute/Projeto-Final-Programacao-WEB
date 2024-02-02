using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public interface IUserRepository
{
    List<User> List();
    User? GetById(int id);
    User? FindByEmail(string email);
    User Create(User newUser);
    User Update(User updatedUser);
    void Delete(int id);
}

public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>(); // Banco de dados

    public List<User> List()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    public User? FindByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email);
    }

    public User Create(User newUser)
    {
        newUser.Id = _users.Count + 1;
        _users.Add(newUser);
        return newUser;
    }

    public User Update(User updatedUser)
    {
        var user = GetById(updatedUser.Id);

        if (user is null)
           throw new Exception("User not found!");
        
        user.Email = updatedUser.Email;
        user.Name = updatedUser.Name;
        user.Password = updatedUser.Password;
        return user;
    }

    public void Delete(int id)
    {
        var user = GetById(id) ?? throw new Exception("User not found!");
        _users.Remove(user);
    }
}
