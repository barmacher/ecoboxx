using ApplicationsApp.Applications.Commands.CreateReport;
using FluentValidation;

namespace ApplicationsApp.Commands.CreateReport
{
    public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator()
        {
            RuleFor(createApplicationCommand => createApplicationCommand.Description).NotEmpty().MaximumLength(500);
            RuleFor(createReportCommand => createReportCommand.UserId).NotEqual(0);
            RuleFor(createApplicationCommand => createApplicationCommand.Number)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone Number is required.");


            //.NotNull().WithMessage("Phone Number is required.")
            //.MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            //.MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            //.Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");
        }
    }
}
