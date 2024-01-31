namespace Domain.Requests;

public class BaseUserRequest
{
    public string Name { get; set; }
    public string Login { get; set; }
    public string Role { get; set; }
}

public class UpdateUserRequest : BaseUserRequest
{
    public int Id { get; set; }
}
