using System;
using MediatR;

namespace ApplicationsApp.Applications.Commands.DeleteCommand
{
    public class DeleteApplicationCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
