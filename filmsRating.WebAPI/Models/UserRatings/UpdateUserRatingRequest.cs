using FluentValidation;
using FluentValidation.Results;

namespace filmsRating.WebAPI.Models;

public class UpdateUserRatingRequest
{
    #region Model

    public int Value { get; set; }
    public string Review { get; set; }
    public int IsEdited { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateUserRatingRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Value).ExclusiveBetween(0, 100).WithMessage("Value must be between 0 and 100");
            RuleFor(x => x.Review).NotEmpty().WithMessage("Empty string")
                .MaximumLength(4000).WithMessage("Length must be less than 4000");
            RuleFor(x => x.IsEdited).InclusiveBetween(0, 1).WithMessage("Value must be 0 or 1");
        }
    }

    #endregion
}

public static class UpdateUserRatingRequestExtension
{
    public static ValidationResult Validate(this UpdateUserRatingRequest model)
    {
        return new UpdateUserRatingRequest.Validator().Validate(model);
    }
}