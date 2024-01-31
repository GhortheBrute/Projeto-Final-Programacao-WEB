using Domain.Entities;
using Domain.Requests;
using Domain.Responses;

namespace Domain.Mappers;

public static class UserMapper
{
    public static UserResponse ToResponse(User user) => new UserResponse
    {
        Id = user.Id,
        Login = user.Login,
        Name = user.Name,
        Role = user.Role
    };
    public static User ToEntity(BaseUserRequest user) => new User
    {
        Login = user.Login,
        Name = user.Name,
        Role = user.Role
    };
    public static User ToEntity(UpdateUserRequest user) => new User
    {
        Id = user.Id,
        Login = user.Login,
        Name = user.Name,
        Role = user.Role
    };
}
