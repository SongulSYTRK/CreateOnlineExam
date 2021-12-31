using CreateOnlineExam.Application.Models.DataTransferObjects;
using FluentValidation;



namespace CreateOnlineExam.Application.Validation.FluentValidation
{
    public class LoginDTOValidation: AbstractValidator<LoginDTO>
    {
        public LoginDTOValidation()
        {

            RuleFor(x => x.UserName).NotEmpty().MaximumLength(20).WithMessage("Enter a username");
            RuleFor(x => x.PassWord).NotEmpty().MaximumLength(20).WithMessage("Enter a password");
        }
    }
}
