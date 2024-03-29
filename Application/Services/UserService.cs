﻿using Domain.Exceptions;
using Domain.Mappers;
using Domain.Requests;
using Domain.Responses;
using Domain.Validators;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services;

public interface IUserService
{
    List<UserResponse> List();
    UserResponse? GetById(int id);
    UserResponse Create(BaseUserRequest newUser);
    UserResponse Update(UpdateUserRequest updatedUser);
    void Delete(int id);
}

public class UserService : IUserService
{
    private readonly IValidator<BaseUserRequest> _validator;
    private readonly IUserRepository _repository;
    private readonly IHashingService _hashingService;

    public UserService(IUserRepository repository, IValidator<BaseUserRequest> validator, IHashingService hashingService)
    {
        _validator = validator;
        _repository = repository;
        _hashingService = hashingService;
    }

    public List<UserResponse> List()
    {
        var users = _repository.List();
        var response = users.Select(UserMapper.ToResponse).ToList();
        return response;
    }

    public UserResponse? GetById(int id)
    {
        var user = _repository.GetById(id);

        if (user is null )
            return null;

        return UserMapper.ToResponse(user);
    }

    public UserResponse Create(BaseUserRequest request)
    {
        var errors = _validator.Validate(request);

        if (errors.Any())
            throw new BadRequestException(errors);

        var newUser = UserMapper.ToEntity(request);
        newUser.Password = _hashingService.Hash(newUser.Password!);
        var user = _repository.Create(newUser);
        return UserMapper.ToResponse(user);
    }

    public UserResponse Update(UpdateUserRequest request)
    {
        var errors = _validator.Validate(request);

        if (errors.Any())
            throw new BadRequestException(errors);

        var existingUser = _repository.GetById(request.Id);

        if (existingUser is null)
            throw new NotFoundException("User not found!");

        var updateUser = UserMapper.ToEntity(request);
        updateUser.Password = _hashingService.Hash(updateUser.Password!);

        var user = _repository.Update(updateUser);
        return UserMapper.ToResponse(user);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
