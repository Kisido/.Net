using FluentValidation;
using FluentValidation.Results;

namespace filmsRating.WebAPI.Models;

public class UpdateUserRequest
{
    #region Model

    public string Login { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }    
    public string PhoneNumber { get; set; }
    public int IsAdmin { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("Empty string")
                .MaximumLength(80).WithMessage("Length must be less than 80");
            RuleFor(x => x.Nickname).NotEmpty().WithMessage("Empty string")
                .MaximumLength(20).WithMessage("Length must be less than 20");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Empty string")
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Empty string")
                .MaximumLength(20).WithMessage("Length must be less than 20");
            RuleFor(x => x.IsAdmin).InclusiveBetween(0, 1).WithMessage("Value must be 0 or 1");
        }
    }

    #endregion
}

public static class UpdateUserRequestExtension
{
    public static ValidationResult Validate(this UpdateUserRequest model)
    {
        return new UpdateUserRequest.Validator().Validate(model);
    }
}