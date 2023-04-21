using MediatR;

namespace ApplicationsApp.Queries.GetReportList
{
    public class GetApplicationListQuery : IRequest<ApplicationListVm>
    {
        public int UserId { get; set; }
    }
}
