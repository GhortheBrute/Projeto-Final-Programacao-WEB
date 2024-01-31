using Domain.Requests;
using Domain.Responses;
using System.Collections.Generic;

namespace Domain.Validators;

public class ProductValidator : IValidator<BaseProductRequest>
{
    public List<ErrorMessageResponse> Validate(BaseProductRequest product)
    {
        var errors = new List<ErrorMessageResponse>();

        if (string.IsNullOrEmpty(product.Description))
            errors.Add(new ErrorMessageResponse
            {
                Field = "Description",
                Message = "Field is required!"
            });

        if (product.Price < 0)
            errors.Add(new ErrorMessageResponse
            {
                Field = "Price",
                Message = "Field must be above 0,00!"
            });

        return errors;
    }
}
