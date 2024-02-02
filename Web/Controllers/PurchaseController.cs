using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class PurchaseController : Controller
{
    private readonly UserController _userController;
    private readonly ProductController _productController;

    public PurchaseController(UserController userController, ProductController productController)
    {
        _userController = userController;
        _productController = productController;
    }


}
