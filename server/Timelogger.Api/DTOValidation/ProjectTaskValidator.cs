using FluentValidation;
using Timelogger.Api.Helper;
using Timelogger.BLL.DTO;

namespace TTimelogger.Api.DTOValidation
{
    public class ProjectTaskValidator : AbstractValidator<ProjectTask>
	{
		public ProjectTaskValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).Length(0, 150).WithMessage("Name must be between 0-150 characters");
			RuleFor(x => x.Type).Length(0, 50).WithMessage("Name must be between 0-50 characters");
			RuleFor(x => x.StartDate).Must(ValidatorHelpers.BeNullOrAValidDate).WithMessage("Name must be empty or a valid date");
			RuleFor(x => x.EndDate).Must(ValidatorHelpers.BeNullOrAValidDate).WithMessage("Name must be empty or a valid date");
		}		
	}
}
