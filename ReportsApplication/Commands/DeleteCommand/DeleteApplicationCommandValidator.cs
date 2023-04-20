using FluentValidation;
using ApplicationsApp.Applications.Commands.DeleteCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsApp.Commands.DeleteCommand
{
    public class DeleteApplicationCommandValidator : AbstractValidator<DeleteApplicationCommand>
    {
        public DeleteApplicationCommandValidator()
        {
            RuleFor(deleteApplicationCommand => deleteApplicationCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
