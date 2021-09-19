using Core.Dtos.Author;
using FluentValidation;
using System;

namespace Core.Validators.Author
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorValidator()
        {
            RuleFor(a => a.FirstName)
                .NotNull()
                .WithMessage("{PropertyName} can not be null or empty")
                .MinimumLength(3)
                .WithMessage("{PropertyName} must have more than 3 characters")
                .MaximumLength(40)
                .WithMessage("{PropertyName} must have less than 40 characters");

            RuleFor(a => a.LastName)
                .NotNull()
                .WithMessage("{PropertyName} can not be null or empty")
                .MinimumLength(3)
                .WithMessage("{PropertyName} must have more than 3 characters")
                .MaximumLength(40)
                .WithMessage("{PropertyName} must have less than 40 characters");

            RuleFor(a => a.DateOfBirth)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be null or empty")
                .LessThan(DateTime.Now)
                .WithMessage("{PropertyName} must be less than date now");

            RuleFor(a => a.DateOfDeath)
                .GreaterThan(a => a.DateOfBirth)
                .When(a=> a.DateOfDeath != null)
                .WithMessage("{PropertyName} must be higher than date of Birth");
        }
    }
}
