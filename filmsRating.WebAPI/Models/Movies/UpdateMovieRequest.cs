using FluentValidation;
using FluentValidation.Results;

namespace filmsRating.WebAPI.Models;

public class UpdateMovieRequest
{
    #region Model

    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateMovieRequest>
    {
        public Validator()
        {
            RuleFor(x => x.ReleaseDate).InclusiveBetween(DateTime.MinValue,DateTime.MaxValue).WithMessage("DateTime must be between DateTime.MinValue and DateTime.MaxValue");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Empty string")
                .MaximumLength(4000).WithMessage("Length must be less than 4000");
            RuleFor(x => x.Director).NotEmpty().WithMessage("Empty string")
                .MaximumLength(80).WithMessage("Length must be less than 80");
        }
    }

    #endregion
}

public static class UpdateMovieRequestExtension
{
    public static ValidationResult Validate(this UpdateMovieRequest model)
    {
        return new UpdateMovieRequest.Validator().Validate(model);
    }
}