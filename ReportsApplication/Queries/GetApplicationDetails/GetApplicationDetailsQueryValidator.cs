using FluentValidation;

namespace ApplicationsApp.Queries.GetReportDetails
{
    internal class GetApplicationDetailsQueryValidator : AbstractValidator<GetApplicationDetailsQuery>
    {
        public GetApplicationDetailsQueryValidator()
        {
            RuleFor(application => application.Id).NotEqual(Guid.Empty);
            RuleFor(application => application.UserId).NotEqual(0);
        }
    }
}
