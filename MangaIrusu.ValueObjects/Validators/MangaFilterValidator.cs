using FluentValidation;

namespace MangaIrusu.ValueObjects.Validators;

public class MangaFilterValidator : AbstractValidator<MangaFilter>
{
    public MangaFilterValidator()
    {
        RuleFor(x => x.MinYear)
            .LessThanOrEqualTo(x => x.MaxYear)
            .When(x => x.MinYear.HasValue && x.MaxYear.HasValue)
            .WithMessage("MinYear must be less than or equal to MaxYear");

        RuleFor(x => x.MinRating)
            .InclusiveBetween(0, 10)
            .When(x => x.MinRating.HasValue)
            .WithMessage("MinRating must be between 0 and 10");

        RuleFor(x => x.MaxRating)
            .InclusiveBetween(0, 10)
            .When(x => x.MaxRating.HasValue)
            .WithMessage("MaxRating must be between 0 and 10");

        RuleFor(x => x.MaxRating)
            .GreaterThanOrEqualTo(x => x.MinRating)
            .When(x => x.MinRating.HasValue && x.MaxRating.HasValue)
            .WithMessage("MaxRating must be greater than or equal to MinRating");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .When(x => x.PageSize.HasValue)
            .WithMessage("PageSize must be between 1 and 100");

        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .When(x => x.PageNumber.HasValue)
            .WithMessage("PageNumber must be greater than 0");
    }
} 