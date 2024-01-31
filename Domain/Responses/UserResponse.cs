using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Responses;

public class UserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Role { get; set; } = string.Empty;
}
