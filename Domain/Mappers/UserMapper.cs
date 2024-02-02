using Domain.Entities;
using Domain.Requests;
using Domain.Responses;

namespace Domain.Mappers;

public static class UserMapper
{
    public static UserResponse ToResponse(User user) => new UserResponse
    {
        Id = user.Id,
        Email = user.Email,
        Name = user.Name,
        Role = user.Role
    };
    public static User ToEntity(BaseUserRequest user) => new User
    {
        Email = user.Email,
        Name = user.Name,
        Password = user.Password,
        Role = user.Role
    };
    public static User ToEntity(UpdateUserRequest user) => new User
    {
        Id = user.Id,
        Email = user.Email,
        Name = user.Name,
        Password = user.Password,
        Role = user.Role
    };
}
