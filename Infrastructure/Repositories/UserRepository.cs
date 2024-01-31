﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories;

public interface IUserRepository
{
    List<User> List();
    User? GetById(int id);
    User Create(User newUser);
    User Update(User updatedUser);
    void Delete(int id);
}

public class UserRepository : IUserRepository
{
    private List<User> _users = []; // Banco de dados

    public List<User> List()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    public User Create(User newUser)
    {
        newUser.Id = _users.Count + 1;
        _users.Add(newUser);
        return newUser;
    }

    public User Update(User updatedUser)
    {
        var user = GetById(updatedUser.Id) ?? throw new Exception("User not found!");
        user.Login = updatedUser.Login;
        user.Name = updatedUser.Name;
        return user;
    }

    public void Delete(int id)
    {
        var user = GetById(id) ?? throw new Exception("User not found!");
        _users.Remove(user);
    }
}
