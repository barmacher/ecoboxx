using FluentValidation;
using ApplicationsApp.Applications.Commands.UpdateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsApp.Commands.UpdateReport
{
    public class UpdateApplicationCommandValidator : AbstractValidator<UpdateApplicationCommand>
    {
        public UpdateApplicationCommandValidator() 
        {
            RuleFor(updateValidationCommand => updateValidationCommand.UserId).NotEqual(0);
            RuleFor(updateApplicationCommand => updateApplicationCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateApplicationtCommand => updateApplicationtCommand.Description)
                .NotEmpty().MaximumLength(500);
            RuleFor(updateApplicationCommand => updateApplicationCommand.Adress)
                .NotEmpty().MaximumLength(50);
            
        }
    }
}
