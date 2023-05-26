using FluentValidation;

namespace ApplicationsApp.Queries.GetReportDetails
{
    internal class GetApplicationDetailsForBrigadeQueryValidator : AbstractValidator<GetApplicationDetailsForBrigadeQuery>
    {
        public GetApplicationDetailsForBrigadeQueryValidator()
        {
            RuleFor(application => application.Id).NotEqual(Guid.Empty);
            RuleFor(application => application.UserId).NotEqual(0);
        }
    }
}
